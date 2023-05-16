using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Catalog.Common.Enum;

namespace Catalog.Service.EventHandlers
{
    public class ProducInStockUpdateStockEventHandler :
        INotificationHandler<ProducInStockUpdateStockCommand>
    {

        private readonly ILogger<ProducInStockUpdateStockEventHandler> _logger;
        private readonly ApplicationDbContext _context;
        public ProducInStockUpdateStockEventHandler(
            ApplicationDbContext context,
            ILogger<ProducInStockUpdateStockEventHandler> logger
            )
        {
            _context = context;
            _logger = logger;
        }
        public async Task Handle(ProducInStockUpdateStockCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- ProducInStockUpdateStockCommand Comienza");

            //selecciona los Id productos de las listas 
            var products = notification.Items.Select(x => x.ProductId);
            var stocks = await  _context.Stocks.Where(x => products.Contains(x.ProductId)).ToListAsync();

            _logger.LogInformation("--- Obtuvo productos de la Base de datos");

            //se iteran los productos que se reciben
            foreach (var item in notification.Items)
            {
                //SingleOrDefault puede que el producto no tenga stock
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);

                //si la accion es substraer se descontara del stock
                if (item.Action == ProductInStockAction.Substract)
                {
                    if (entry == null || item.Stock > entry.Stock)
                    {

                        _logger.LogError($"Producto Id: {entry.ProductId} no tiene suficiente inventario");
                        throw new Exception($"Producto Id: {entry.ProductId} no tiene suficiente inventario");
                    }

                    entry.Stock -= item.Stock;

                    _logger.LogInformation($"--Substrae  Producto con el Id: {entry.ProductId} el nuevo stock es: {entry.Stock}");

                }
                else
                {
                    // en caso contrario seria agregar
                    if (entry == null)
                    {
                        entry = new Domain.ProductInStock
                        {
                            ProductId = item.ProductId,
                        };

                        await _context.AddAsync(entry);
                        _logger.LogInformation($"Nuevo stock fue creado con el ID {entry.ProductId} porque no tenia stock");
                    }

                    entry.Stock += item.Stock;
                    _logger.LogInformation($"--- Agregar stock del  Producto con el Id:  {entry.ProductId} la cantidad de productos es: {entry.Stock}");

                }
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation("--- ProducInStockUpdateStockCommand Final");
        }
    }
}

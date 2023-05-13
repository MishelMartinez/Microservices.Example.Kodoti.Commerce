using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.EventHandlers
{
    public class ProductCreateEvenHandler: INotificationHandler<ProductCreateCommand>
    {

        private readonly ApplicationDbContext _context;

        public ProductCreateEvenHandler(ApplicationDbContext context) {
        
            _context = context;
        }

        //desencadena el evento

        public async Task Handle(ProductCreateCommand command, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Product
            {
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
            });

            //guardar cambios

            await _context.SaveChangesAsync();
        }

    }
}

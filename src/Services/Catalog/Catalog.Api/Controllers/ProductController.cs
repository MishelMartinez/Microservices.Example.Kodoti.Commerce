using Catalog.Service.EventHandlers.Commands;
using Catalog.Services.Queries.DTOs;
using Catalog.Services.Queries.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Common.Collection;

namespace Catalog.Api.Controllers
{
    
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IProductQueryService _productQueryService;
        private readonly IMediator _mediator;
        public ProductController(ILogger<ProductController> logger,
                                 IProductQueryService productQueryService,
                                 IMediator mediator)
        {
            _logger = logger;
            _productQueryService = productQueryService;
            _mediator = mediator;
        }


        [HttpGet]

        public async Task<DataCollection<ProductDto>>GetAll()
        {
            IEnumerable<int> products = null;

            /*
            if(!string.IsNullOrEmpty(ids))
            {
                products = ids.Split(',').Select(x=>Convert.ToInt32(x));

            }
            */
            return await _productQueryService.GetAllAsync(1,10,null);
        }


        [HttpGet("{id}")]

        public async Task<ProductDto> Get (int id)
        {
            return await _productQueryService.GetAsync(id);
        }


        //create Product

        [HttpPost()]

        public async Task<IActionResult> CreateProduct(ProductCreateCommand command)
        {
            //desencadenar el evento con nugget mediaTR y mediTR.extension.DependencyInjection

            //publica el comando

             await _mediator.Publish (command);

            return Ok();
        }
    }

}

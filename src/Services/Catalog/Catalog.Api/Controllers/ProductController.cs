using Catalog.Services.Queries.DTOs;
using Catalog.Services.Queries.Interfaces;
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

        public ProductController(ILogger<ProductController> logger,
                                 IProductQueryService productQueryService)
        {
            _logger = logger;
            _productQueryService = productQueryService;
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
    }

}

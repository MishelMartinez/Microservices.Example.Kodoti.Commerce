﻿using Catalog.Service.EventHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("stocks")]
    [ApiController]
    public class ProductInStockController : ControllerBase
    {

        private readonly ILogger<ProductInStockController> _logger;
        private readonly IMediator _mediator;

        public ProductInStockController(
            ILogger<ProductInStockController> logger,
            IMediator mediator
            )
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpPut]
        public async Task<IActionResult> UpdateStock(ProducInStockUpdateStockCommand command)
        {
            await _mediator.Publish(command);
            return NoContent();
        }
    }
}

using CQRSMediaTRNetCore.Commands;
using CQRSMediaTRNetCore.Handlers;
using CQRSMediaTRNetCore.Notifications;
using CQRSMediaTRNetCore.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediaTRNetCore.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public ProductsController(ISender sender , IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _sender.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product= await _sender.Send(new GetProductByIdQuery(id));
            return Ok(product);

        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody]Product product)
        {
            var productToReturn = await _sender.Send(new AddProductCommand(product));
            await _publisher.Publish(new ProductAddedNotification(productToReturn));
            return CreatedAtRoute("GetProductById", new { id = productToReturn.Id}, productToReturn);
        }

    }
}

using Basket.API.Entities;
using Basket.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        private readonly ILogger<BasketController> _logger;

        public BasketController(IBasketRepository repository, ILogger<BasketController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await _repository.GetBasket(userName);
            return Ok(basket ?? new ShoppingCart(userName));
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            var updatedBasket = await _repository.UpdateBasket(basket);
            return Ok(updatedBasket);
        }

        [HttpDelete("{userName}")]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _repository.DeleteBasket(userName);
            return Ok();
        }




    }
}

using cacheImplementation.Data;
using cacheImplementation.Models;
using cacheImplementation.Repository.InterfaceRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace cacheImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMemoryCache _cache;

        public OrderController(IOrderRepository orderRepository, IMemoryCache cache)
        {
            _orderRepository = orderRepository;
            _cache = cache;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderRepository.GetOrders();
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            var createdOrder = await _orderRepository.CreateOrder(order);
            return Ok(CreatedAtRoute("GetOrder", new { id = createdOrder.order_id }, createdOrder));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            var order = await _orderRepository.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _orderRepository.DeleteOrder(id);
            return NoContent();
        }


        //[HttpGet("MostSoldProduct")]
        //public async Task<ActionResult<Product>> GetMostSoldProduct()
        //{
        //    var product = await _orderRepository.GetMostSoldProduct();
        //    if (product == null)
        //    {
        //        return NotFound(); // No orders found
        //    }
        //    return product;
        //}

        [HttpGet("MostSoldProduct")]
        public async Task<ActionResult<Product>> GetMostSoldProduct()
        {
            const string cacheKey = "MostSoldProduct";

            var product = await _cache.GetOrCreateAsync(cacheKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10); 

                return _orderRepository.GetMostSoldProduct();
            });

            if (product == null)
            {
                return NotFound(); 
            }

            return product;
        }

    }
}

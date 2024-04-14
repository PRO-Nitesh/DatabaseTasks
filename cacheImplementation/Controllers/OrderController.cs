using cacheImplementation.Data;
using cacheImplementation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cacheImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly combineContext _context;

        public OrderController(combineContext context)
        {
            _context=context;
        }

        //creating a GET method
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            //return await _context.Orders.ToListAsync();

            var orderes = await _context.Orders.ToListAsync();
            if(orderes == null)
            {
                return NotFound();
            }
            return Ok(orderes); 
        }

        //creating a post method
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrders(Order order)
        {

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetOrder", new { id = order.order_id }, order);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

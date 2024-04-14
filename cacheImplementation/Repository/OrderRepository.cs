using cacheImplementation.Data;
using cacheImplementation.Models;
using cacheImplementation.Repository.InterfaceRepository;
using Microsoft.EntityFrameworkCore;

namespace cacheImplementation.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly combineContext _context;

        public OrderRepository(combineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrder(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order> CreateOrder(Order order)
        {
            order.order_id = Guid.NewGuid();
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrder(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
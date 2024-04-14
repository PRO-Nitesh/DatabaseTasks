using cacheImplementation.Models;

namespace cacheImplementation.Repository.InterfaceRepository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(Guid id);
        Task<Order> CreateOrder(Order order);
        Task DeleteOrder(Guid id);
        Task<Product> GetMostSoldProduct();
    }
}
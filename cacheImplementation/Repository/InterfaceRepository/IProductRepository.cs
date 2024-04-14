using cacheImplementation.Models;

namespace cacheImplementation.Repository.InterfaceRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(Guid id);
        Task<Product> CreateProduct(Product product);
        Task DeleteProduct(Guid id);
    }
}
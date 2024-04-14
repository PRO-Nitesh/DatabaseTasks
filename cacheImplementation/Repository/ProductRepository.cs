using cacheImplementation.Data;
using cacheImplementation.Models;
using cacheImplementation.Repository.InterfaceRepository;
using Microsoft.EntityFrameworkCore;

namespace cacheImplementation.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly combineContext _context;

        public ProductRepository(combineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProduct(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            product.product_id = Guid.NewGuid();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
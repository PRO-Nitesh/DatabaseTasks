using cacheImplementation.Models;
using Microsoft.EntityFrameworkCore;

namespace cacheImplementation.Data
{
    public class combineContext: DbContext
    {
        public combineContext(DbContextOptions<combineContext> options) : base(options) 
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }



    }
}

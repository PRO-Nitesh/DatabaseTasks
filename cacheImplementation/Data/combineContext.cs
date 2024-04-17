using ApiProject.Models;
using cacheImplementation.Models;
using Microsoft.EntityFrameworkCore;

namespace cacheImplementation.Data
{
    public class combineContext: DbContext
    {
        internal object UserInfo;

        public combineContext(DbContextOptions<combineContext> options) : base(options) 
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public DbSet<UserInfo> UserInformation { get; set; }
    }
}

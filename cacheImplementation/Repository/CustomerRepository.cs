using cacheImplementation.Data;
using cacheImplementation.Models;
using cacheImplementation.Repository.InterfaceRepository;
using Microsoft.EntityFrameworkCore;

namespace cacheImplementation.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly combineContext _context;

        public CustomerRepository(combineContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            customer.customer_id = Guid.NewGuid();
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomer(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
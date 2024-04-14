using cacheImplementation.Models;

namespace cacheImplementation.Repository.InterfaceRepository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(Guid id);
        Task<Customer> CreateCustomer(Customer customer);
        Task DeleteCustomer(Guid id);
    }
}
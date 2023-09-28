using System.Collections.Generic;
using System.Threading.Tasks;
using OrderApi.Domain.Entities;

namespace OrderApi.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int customerId);
        Task<int> AddCustomerAsync(Customer customer);
        Task UpdateAsync(Customer existingCustomer);
        Task DeleteAsync(Customer existingCustomer);
        // Add other customer-related methods as needed
    }
}

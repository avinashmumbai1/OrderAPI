using System.Collections.Generic;
using System.Threading.Tasks;
using OrderApi.Application.DTOs;

namespace OrderApi.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(int customerId);
        Task<int> CreateCustomerAsync(CustomerDto customerDto);
        Task UpdateCustomerAsync(int customerId, CustomerDto customerDto);
        Task DeleteCustomerAsync(int customerId);
    }
}

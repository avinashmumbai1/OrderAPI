using System.Collections.Generic;
using System.Threading.Tasks;
using OrderApi.Domain.Entities;

namespace OrderApi.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync(int page, int pageSize);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<int> AddOrderAsync(Order order);
        // Add other data access methods as needed
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using OrderApi.Application.DTOs;

namespace OrderApi.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrdersAsync(int page, int pageSize);
        Task<OrderDto> GetOrderByIdAsync(int orderId);
        Task<int> PlaceOrderAsync(OrderDto orderDto);
        // Add other order-related methods as needed
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;

namespace OrderApi.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders; // Simulated in-memory data store
        private int _nextOrderId = 1;

        public OrderRepository()
        {
            _orders = new List<Order>();
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(int page, int pageSize)
        {
            return _orders.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return _orders.FirstOrDefault(o => o.Id == orderId);
        }

        public async Task<int> AddOrderAsync(Order order)
        {
            order.Id = _nextOrderId++;
            _orders.Add(order);
            return order.Id;
        }

        // Implement other data access methods as needed
    }
}

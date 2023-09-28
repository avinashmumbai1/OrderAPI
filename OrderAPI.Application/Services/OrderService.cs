using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;

namespace OrderApi.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        private OrderDto MapToDto(Order order)
        {
            return _mapper.Map<OrderDto>(order);
        }

        private Order MapToEntity(OrderDto orderDto)
        {
            return _mapper.Map<Order>(orderDto);
        }

        private decimal CalculateTotalPrice(IEnumerable<OrderItem> orderItems)
        {
            decimal totalPrice = 0;
            foreach (var orderItem in orderItems)
            {
                totalPrice += orderItem.GetTotalPrice();
            }
            return totalPrice;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync(int page, int pageSize)
        {
            // Implement logic to fetch orders from the repository based on pagination
            var orders = await _orderRepository.GetOrdersAsync(page, pageSize);
            return orders.Select(order => MapToDto(order));
        }

        public async Task<OrderDto> GetOrderByIdAsync(int orderId)
        {
            // Implement logic to fetch a single order by ID from the repository
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            return order != null ? MapToDto(order) : null;
        }

        public async Task<int> PlaceOrderAsync(OrderDto orderDto)
        {
            // Simulated validation (you can replace this with your validation logic)
            if (orderDto.CustomerId <= 0)
            {
                throw new ArgumentException("Invalid customer ID.");
            }

            // Map the DTO to an order entity
            var order = MapToEntity(orderDto);

            // Implement logic to place the order in the repository
            var orderId = await _orderRepository.AddOrderAsync(order);

            return orderId;
        }
    }
}

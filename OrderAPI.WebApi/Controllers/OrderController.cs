//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace OrderAPI.WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrderController : ControllerBase
//    {
//    }
//} 

using Microsoft.AspNetCore.Mvc;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderApi.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders(int page, int pageSize)
        {
            var orders = await _orderService.GetOrdersAsync(page, pageSize);
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<int>> PlaceOrder(OrderDto orderDto)
        {
            var orderId = await _orderService.PlaceOrderAsync(orderDto);
            return CreatedAtAction(nameof(GetOrderById), new { orderId }, orderId);
        }

        // Implement other CRUD operations as needed
    }
}


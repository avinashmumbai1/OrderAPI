using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;

namespace OrderApi.WebApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customers = await _customerService.GetCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCustomer(CustomerDto customerDto)
        {
            var customerId = await _customerService.CreateCustomerAsync(customerDto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customerId }, customerId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (id != customerDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _customerService.UpdateCustomerAsync(id,customerDto);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

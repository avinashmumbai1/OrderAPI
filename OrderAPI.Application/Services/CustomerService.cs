using AutoMapper;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;

namespace OrderApi.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
        {
            var customers = await _customerRepository.GetCustomersAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                throw new Exception($"Customer with ID {customerId} not found.");
            }

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<int> CreateCustomerAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerRepository.AddCustomerAsync(customer);
            return customer.Id;
        }

        public async Task UpdateCustomerAsync(int customerId, CustomerDto customerDto)
        {
            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (existingCustomer == null)
            {
                throw new Exception($"Customer with ID {customerId} not found.");
            }

            _mapper.Map(customerDto, existingCustomer);
            await _customerRepository.UpdateAsync(existingCustomer);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(customerId);
            if (existingCustomer == null)
            {
                throw new Exception($"Customer with ID {customerId} not found.");
            }

            await _customerRepository.DeleteAsync(existingCustomer);
        }
    }
}

////using System.Collections.Generic;
////using System.Linq;
////using System.Threading.Tasks;
////using Microsoft.EntityFrameworkCore;
////using OrderApi.Application.Interfaces;
////using OrderApi.Domain.Entities;

////namespace OrderApi.Infrastructure.Persistence.Repositories
////{
////    public class CustomerRepository : ICustomerRepository
////    {
////        private readonly ApplicationDbContext _context;

////        public CustomerRepository(ApplicationDbContext context)
////        {
////            _context = context;
////        }

////        public async Task<IEnumerable<Customer>> GetCustomersAsync()
////        {
////            return await _context.Customers.ToListAsync();
////        }

////        public async Task<Customer> GetCustomerByIdAsync(int customerId)
////        {
////            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
////        }

////        public async Task<int> AddCustomerAsync(Customer customer)
////        {
////            _context.Customers.Add(customer);
////            await _context.SaveChangesAsync();
////            return customer.Id;
////        }

////        // Implement other data access methods as needed
////    }
////}  

//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using OrderApi.Application.Interfaces;
//using OrderApi.Domain.Entities;

//namespace OrderApi.Infrastructure.Persistence.Repositories
//{
//    public class CustomerRepository : ICustomerRepository
//    {
//        private readonly List<Customer> _customers; // Simulated in-memory data store
//        private int _nextCustomerId = 1;

//        public CustomerRepository()
//        {
//            _customers = new List<Customer>();
//        }

//        public async Task<IEnumerable<Customer>> GetCustomersAsync()
//        {
//            return _customers.ToList();
//        }

//        public async Task<Customer> GetCustomerByIdAsync(int customerId)
//        {
//            return _customers.FirstOrDefault(c => c.Id == customerId);
//        }

//        public async Task<int> AddCustomerAsync(Customer customer)
//        {
//            customer.Id = _nextCustomerId++;
//            _customers.Add(customer);
//            return customer.Id;
//        }

//        public async Task UpdateAsync(Customer customer)
//        {
//            // Find the existing customer by ID
//            var existingCustomer = await _customers.FirstOrDefault(c => c.Id == customer.Id);

//            if (existingCustomer != null)
//            {
//                // Update customer properties
//                existingCustomer.FirstName = customer.FirstName;
//                existingCustomer.LastName = customer.LastName;
//                existingCustomer.Email = customer.Email;
//                // Update other properties as needed

//                await _context.SaveChangesAsync(); // Save changes to the database
//            }
//        }

//        public Task DeleteAsync(Customer existingCustomer)
//        {
//            throw new NotImplementedException();
//        }

//        // Implement other data access methods as needed
//    }
//}


using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;

namespace OrderApi.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context; // Inject your DbContext here

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
        }

        public async Task<int> AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }

        public async Task UpdateAsync(Customer customer)
        {
            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id);
            if (existingCustomer == null)
            {
                throw new Exception($"Customer with ID {customer.Id} not found.");
            }

            // Update customer properties
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            // Update other properties as needed

            await _context.SaveChangesAsync(); // Save changes to the database
        }

        public async Task DeleteAsync(Customer existingCustomer)
        {
            _context.Customers.Remove(existingCustomer);
            await _context.SaveChangesAsync();
        }

        // Implement other data access methods as needed
    }
}

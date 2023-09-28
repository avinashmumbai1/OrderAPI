using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;
using OrderApi.Infrastructure.Persistence.Repositories;
using Xunit;

namespace OrderApi.Tests.Repositories
{
    public class CustomerRepositoryTests
    {
        [Fact]
        public async Task GetCustomersAsync_ShouldReturnAllCustomers()
        {
            // test code for GetCustomersAsync
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com" },
                new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com" }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Customer>>();
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customers.Provider);
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customers.Expression);
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customers.ElementType);
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(() => customers.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Customers).Returns(mockDbSet.Object);

            var repository = new CustomerRepository(mockContext.Object);

            // Act
            var result = await repository.GetCustomersAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetCustomerByIdAsync_ShouldReturnCustomerById()
        {
            // test code for GetCustomerByIdAsync
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com" },
                new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com" }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Customer>>();
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customers.Provider);
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customers.Expression);
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customers.ElementType);
            mockDbSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(() => customers.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Customers).Returns(mockDbSet.Object);

            var repository = new CustomerRepository(mockContext.Object);

            // Act
            var result = await repository.GetCustomerByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John", result.FirstName);
        }

        // Add more test methods for other repository operations like AddCustomerAsync, UpdateAsync, DeleteAsync, etc.
    }
}

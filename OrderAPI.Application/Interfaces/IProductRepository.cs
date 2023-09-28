using OrderApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderApi.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<int> AddProductAsync(Product product);
        // Add other product-related data access methods as needed
    }
}

using OrderApi.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderApi.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<int> AddProductAsync(ProductDto productDto);
        // Add other product-related methods as needed
    }
}

using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using OrderApi.Domain.Entities;

namespace OrderApi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            // Implement logic to retrieve and map products from the repository
            var products = await _productRepository.GetProductsAsync();
            // Map products to DTOs and return
            var productDtos = new List<ProductDto>(); // You should create a ProductDto class
            foreach (var product in products)
            {
                productDtos.Add(MapToDto(product));
            }
            return productDtos;
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            // Implement logic to retrieve and map a product by ID from the repository
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product == null)
            {
                return null; // Handle the case where the product doesn't exist
            }
            return MapToDto(product);
        }

        public async Task<int> AddProductAsync(ProductDto productDto)
        {
            // Implement logic to add a new product to the repository
            var product = MapToEntity(productDto); // Create a method to map from ProductDto to Product
            var productId = await _productRepository.AddProductAsync(product);
            return productId;
        }

        // Add other product-related methods as needed

        private ProductDto MapToDto(Product product)
        {
            // Implement the mapping logic from Product to ProductDto
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                // Map other properties
            };
        }

        private Product MapToEntity(ProductDto productDto)
        {
            // Implement the mapping logic from ProductDto to Product
            return new Product
            {
                Name = productDto.Name,
                // Map other properties
            };
        }

        // Implement additional mapping methods and product-related methods
    }
}

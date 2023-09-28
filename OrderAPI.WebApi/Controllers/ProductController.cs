//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace OrderAPI.WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ProductController : ControllerBase
//    {
//    }
//}  

using Microsoft.AspNetCore.Mvc;
using OrderApi.Application.DTOs;
using OrderApi.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderApi.WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            try
            {
                var products = await _productService.GetProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                // Log the exception here using your preferred logging mechanism
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int productId)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(productId);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                // Log the exception here using your preferred logging mechanism
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProduct(ProductDto productDto)
        {
            try
            {
                var productId = await _productService.AddProductAsync(productDto);
                return CreatedAtAction(nameof(GetProduct), new { productId }, productId);
            }
            catch (Exception ex)
            {
                // Log the exception here using your preferred logging mechanism
                return StatusCode(500, "Internal server error");
            }
        }

        // Implement other product-related endpoints as needed
    }
}


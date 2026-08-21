using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Data;
using StoreAPI.DTOs;
using StoreAPI.Models;
using StoreAPI.Services;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO product)
        {
            var newProduct = await _productService.CreateProductAsync(product);
            return Ok(newProduct);
        }
         
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDTO product)
        {
            var existingProduct = await _productService.UpdateProductAsync(id, product);
            if (existingProduct == null)
            {
                return NotFound();
            }
            return Ok(existingProduct);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.DeleteProductAsync(id);
            if (!product)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
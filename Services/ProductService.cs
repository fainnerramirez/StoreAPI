using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Data;
using StoreAPI.DTOs;
using StoreAPI.Models;

namespace StoreAPI.Services
{
    public class ProductService : IProductService
    {

        private readonly StoreDbContext _db;

        public ProductService(StoreDbContext db)
        {
            _db = db;
        }

        public async Task<ProductResponseDTO> CreateProductAsync(ProductDTO product)
        {
            var newProduct = new Product
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Stock = product.Stock
            };

            _db.Products.Add(newProduct);
            await _db.SaveChangesAsync();

            return new ProductResponseDTO
            {
                ProductName = newProduct.ProductName,
                Price = newProduct.Price,
                Stock = newProduct.Stock
            };
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var existingProduct = await _db.Products.FindAsync(id);
            if(existingProduct == null)
            {
                return false;
            }

            _db.Products.Remove(existingProduct);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync()
        {
            return _db.Products.Select(p => new ProductResponseDTO
            {
                ProductName = p.ProductName,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task<Product?> UpdateProductAsync(int id, ProductDTO product)
        {
            var existingProduct = await _db.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.ProductName = product.ProductName;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
            await _db.SaveChangesAsync();
            return existingProduct;
        }
    }
}
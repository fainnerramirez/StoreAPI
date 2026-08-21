using StoreAPI.DTOs;
using StoreAPI.Models;

namespace StoreAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<ProductResponseDTO> CreateProductAsync(ProductDTO product);
        Task<Product?> UpdateProductAsync(int id, ProductDTO product);
        Task<bool> DeleteProductAsync(int id);
    }
}
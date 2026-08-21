namespace StoreAPI.DTOs
{
    public class ProductResponseDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
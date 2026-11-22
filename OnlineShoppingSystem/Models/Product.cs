namespace OnlineShoppingSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; } = "";
    }
}

using System.Data;
using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Controllers
{
    public class ProductController
    {
        private readonly ProductRepository _repository = new ProductRepository();

        public DataTable GetProducts() => _repository.GetAll();

        public DataTable SearchProducts(string keyword) => _repository.Search(keyword.Trim());

        public void AddProduct(Product product)
        {
            Validate(product);
            _repository.Insert(product);
        }

        public void EditProduct(Product product)
        {
            if (product.ProductId <= 0)
                throw new ArgumentException("Select a product before updating.");
            Validate(product);
            _repository.Update(product);
        }

        public void RemoveProduct(int productId)
        {
            if (productId <= 0)
                throw new ArgumentException("Select a product before deleting.");
            _repository.Delete(productId);
        }

        private static void Validate(Product product)
        {
            if (product.ProductName == "")
                throw new ArgumentException("Product name is required.");
            if (product.CategoryId <= 0)
                throw new ArgumentException("Choose a category.");
            if (product.Price <= 0)
                throw new ArgumentException("Price must be greater than 0.");
            if (product.Quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");
        }
    }
}

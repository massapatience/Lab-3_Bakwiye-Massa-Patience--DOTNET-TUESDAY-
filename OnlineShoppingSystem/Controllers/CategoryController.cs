using System.Data;
using OnlineShoppingSystem.Models;

namespace OnlineShoppingSystem.Controllers
{
    public class CategoryController
    {
        private readonly CategoryRepository _repository = new CategoryRepository();

        public DataTable GetCategories() => _repository.GetAll();

        public DataTable SearchCategories(string keyword) => _repository.Search(keyword.Trim());

        public void AddCategory(Category category)
        {
            Validate(category);
            _repository.Insert(category);
        }

        public void EditCategory(Category category)
        {
            if (category.CategoryId <= 0)
                throw new ArgumentException("Select a category before updating.");
            Validate(category);
            _repository.Update(category);
        }

        public void RemoveCategory(int categoryId)
        {
            if (categoryId <= 0)
                throw new ArgumentException("Select a category before deleting.");
            _repository.Delete(categoryId);
        }

        private static void Validate(Category category)
        {
            if (category.CategoryName == "")
                throw new ArgumentException("Category name is required.");
        }
    }
}

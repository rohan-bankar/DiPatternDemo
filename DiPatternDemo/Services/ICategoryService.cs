using DiPatternDemo.Models;

namespace DiPatternDemo.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        public int AddCategory(Category category);
        public int UpdateCategory(Category category);
        public int DeleteCategory(int id);
    }
}

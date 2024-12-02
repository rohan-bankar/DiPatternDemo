using DiPatternDemo.Models;

namespace DiPatternDemo.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        public int AddCategory(Category category);
        public int UpdateCategory(Category category);
        public int DeleteCategory(int id);
    }
}

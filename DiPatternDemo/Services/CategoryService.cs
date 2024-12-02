using DiPatternDemo.Models;
using DiPatternDemo.Repositories;

namespace DiPatternDemo.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repo;
        public CategoryService(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        public int AddCategory(Category category)
        {
            return repo.AddCategory(category);
        }

        public int DeleteCategory(int id)
        {
           return repo.DeleteCategory(id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return repo.GetCategories();
        }

        public Category GetCategoryById(int id)
        {
            return repo.GetCategoryById(id);
        }

        public int UpdateCategory(Category category)
        {
           return repo.UpdateCategory(category);
        }
    }
}

using DiPatternDemo.Data;
using DiPatternDemo.Models;

namespace DiPatternDemo.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext db;
        public CategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddCategory(Category category)
        {
            int result = 0;
            db.Categories.Add(category);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteCategory(int id)
        {
            int result = 0;
            var res = db.Categories.Where(x => x.Categoryid == id).FirstOrDefault();
            if(res != null)
            {
                db.Categories.Remove(res);
             
            }
            result = db.SaveChanges();
            return result;
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories?.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories.Where(x => x.Categoryid == id).SingleOrDefault();
        }

        public int UpdateCategory(Category category)
        {
            int result = 0;
            var res = db.Categories.Where(x=>x.Categoryid == category.Categoryid).FirstOrDefault();
            if(res != null)
            {
                res.Categoryname = category.Categoryname;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}

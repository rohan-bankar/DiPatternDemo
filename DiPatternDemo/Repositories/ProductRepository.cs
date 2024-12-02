using DiPatternDemo.Data;
using DiPatternDemo.Models;

namespace DiPatternDemo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;
        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddProduct(Product product)
        {
            int result = 0;
            var res = db.products.Add(product);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;
            var res = db.products.Where(x=>x.ProductId == id).FirstOrDefault();
            if(res != null)
            {
                db.products.Remove(res);
                result = db.SaveChanges();
            }
            return result;
        }

        public Product GetProductById(int id)
        {
            var res = (from p in db.products
                       join c in db.Categories on p.CategoryId equals c.Categoryid
                       where p.ProductId == id
                       select new Product
                       {
                           ProductId = p.ProductId,
                           ProductName = p.ProductName,
                           Price = p.Price,
                           CategoryId = c.Categoryid,
                           CategoryName = c.Categoryname,
                           ImageUrl = p.ImageUrl
                       }).FirstOrDefault();
            return res;
        }

        public IEnumerable<Product> GetProducts()
        {
            var result = (from p in db.products
                         join c in db.Categories on p.CategoryId equals c.Categoryid
                         select new Product
                         {
                             ProductId = p.ProductId,
                             ProductName = p.ProductName,
                             Price = p.Price,
                             CategoryId = c.Categoryid,
                             CategoryName = c.Categoryname,
                             ImageUrl = p.ImageUrl
                         }).ToList();

            return result;     
        }

        public int UpdateProduct(Product product)
        {
            int result = 0;
            var res = db.products.Where(x => x.ProductId == product.ProductId).SingleOrDefault();
            if(res != null)
            {
                res.ProductName = product.ProductName;
                res.Price = product.Price;
                res.CategoryId= product.CategoryId;
                res.ImageUrl = product.ImageUrl;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}

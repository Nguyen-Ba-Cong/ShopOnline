using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        ShopDbContext db = null;
        public ProductDao()
        {
            this.db = new ShopDbContext();
        }
        public List<Product> ListProductByCategory(long id, ref int totalRecord, int page = 1, int pageSize = 5)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == id).Count();
            var model = db.Products.Where(x => x.CategoryID == id).OrderByDescending(x=>x.CreatedDate).Skip((page-1) * 2).Take(pageSize).ToList();
            return model;
        }
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public Product Detail(long id)
        {
            return db.Products.Find(id);
        }
        public List<Product> ListRelatedProduct(long productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != productId && x.CategoryID == product.CategoryID).ToList();
        }
    }
}

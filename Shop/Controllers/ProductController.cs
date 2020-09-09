using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var dao = new ProductCategoryDao();
            var model = dao.ListAll();
            return PartialView(model);
        }
        public ActionResult Category(long cateid, int page = 1, int pageSize = 5)
        {
            var dao = new CategoryDao();
            var category = dao.ViewDetail(cateid);
            ViewBag.Category = category;
            int totalRecord = 0;
            var products = new ProductDao().ListProductByCategory(cateid,ref totalRecord,page,pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.page = page;
            int maxPage = 5;
            int totalPage =(int)(Math.Ceiling((double)(totalRecord / pageSize)));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(products);
        }
        public ActionResult Detail(long DetailId)
        {

            var product = new ProductDao().Detail(DetailId);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryID.Value);
            ViewBag.RelatedProduct = new ProductDao().ListRelatedProduct(DetailId);
            return View(product);
        }
    }
}
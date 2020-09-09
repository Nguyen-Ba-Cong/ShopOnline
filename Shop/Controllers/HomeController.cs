using Model.Dao;
using Shop.Common;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var slide = new SlideDao();
            ViewBag.Slides = slide.ListAll();
            var product = new ProductDao();
            ViewBag.NewProducts = product.ListNewProduct(7);
            ViewBag.FeatureProduct = product.ListFeatureProduct(6);
            return View();
        }
        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var dao = new MenuDao();
            var model=dao.ListByGroupId(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
        public ActionResult TopMenu()
        {
            var dao = new MenuDao();
            var model = dao.ListByGroupId(2);
            return PartialView(model);
        }
        public ActionResult Footer1()
        {
            var dao = new FooterDao();
            var model = dao.GetFooter("1");
            return PartialView(model);
        }
        public ActionResult Footer2()
        {
            var dao = new FooterDao();
            var model = dao.GetFooter("2");
            return PartialView(model);
        }
    }
}
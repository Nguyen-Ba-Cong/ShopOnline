using Model.Dao;
using Model.EF;
using Shop.Common;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Configuration;
using Common;

namespace Shop.Controllers
{
    public class CartController : BaseController
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public JsonResult DeleteAll()
        {
            Session[CommonConstant.CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Delete(long id)
        {
            var cart = (List<CartItem>)Session[CommonConstant.CartSession];
            cart.RemoveAll(x => x.Product.ID == id);
            Session[CommonConstant.CartSession] = cart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(String cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CommonConstant.CartSession];
            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CommonConstant.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });

        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(String ShipName, String Mobile, String Address, String Email)
        {
            try
            {
                var order = new Order();
                order.ShipName = ShipName;
                order.ShipMobile = Mobile;
                order.ShipAddess = Address;
                order.ShipEmail = Email;
                long id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CommonConstant.CartSession];
                var orderDetailDao = new OrderDetailDao();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Price = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    orderDetailDao.Insert(orderDetail);
                    total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                }
                String content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Client/template/NewOrder.html"));
                content = content.Replace("{{Customer}}", ShipName);
                content = content.Replace("{{Phone}}", Mobile);
                content = content.Replace("{{Email}}", Email);
                content = content.Replace("{{Address}}", Address);
                content = content.Replace("{{Toltal}}", total.ToString("N0"));
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                new MailHelper().Sendmail(toEmail, "Đơn hàng mới", content);
                new MailHelper().Sendmail(Email, "Đơn hàng mới", content);
                return RedirectToAction("Success");
            }
            catch (Exception)
            {
                return RedirectToAction("Payment");
            }
           
        }
        public ActionResult AddItem(long productId, int quantity)
        {
            var product = new ProductDao().Detail(productId);
            var cart = Session[CommonConstant.CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Product.ID == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var Item = new CartItem();
                    Item.Product = product;
                    Item.Quantity = quantity;
                    list.Add(Item);
                }
                Session[CommonConstant.CartSession] = list;
            }
            else
            {
                var Item = new CartItem();
                Item.Product = product;
                Item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(Item);
                Session[CommonConstant.CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}
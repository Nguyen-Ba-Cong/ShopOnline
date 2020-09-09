using Model.Dao;
using Shop.Areas.Admin.Models;
using Shop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var Dao = new UserDao();
                var result = Dao.Login(model.UserName, Encryptor.MD5Hash(model.Password),true);
                if (result==1)
                {
                    var User = Dao.FindByID(model.UserName);
                    var UserSession = new UserLogin();
                    UserSession.UserID = User.ID;
                    UserSession.UserName = User.Name;
                    Session.Add(CommonConstant.UserSession, UserSession);
                    return RedirectToAction("Index","Home");
                }
                else if(result==0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");

                }
                else if(result ==-1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Bạn không có quyền đăng nhập");
                }
            }
            return View("Index");
        }
    }
}
using Model.Dao;
using Model.EF;
using Shop.Common;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Logout()
        {
            Session[CommonConstant.UserSession] = null;
            return Redirect("/");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(login.UserName, Encryptor.MD5Hash(login.Password));
                if(result==1)
                {
                    var user = dao.FindByID(login.UserName);
                    var userSession = new UserLogin();
                    userSession.UserID = user.ID;
                    userSession.UserName = user.UserName;
                    Session.Add(CommonConstant.UserSession, userSession);
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");

                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
            }
            return View(login);
        }
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();
                if(dao.CheckName(model.UserName))
                {
                    ModelState.AddModelError("", "UserName is already");
                }
                else if(dao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email is already");
                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    String Md5 = model.Password;
                    user.Password = Encryptor.MD5Hash(Md5);
                    user.Name = model.Name;
                    user.Phone = model.Phone;
                    user.Address = model.Address;
                    user.Email = model.Email;
                    user.CreatedDay = DateTime.Now;
                    user.Status = true;
                    var result = dao.Insert(user);
                    if(result>0)
                    {
                        ViewBag.Success = "Sign Up Successful";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Sign Up Fail");
                    }
                }
            }
            return View(model);
        }
    }
}
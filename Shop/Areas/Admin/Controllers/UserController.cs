using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using Shop.Common;
using PagedList;
namespace Shop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(String SearchString, int page=1,int pageSize=2)
        {
            var dao = new UserDao();
            var model = dao.ListAll(SearchString,page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
           if(ModelState.IsValid)
            {
                var dao = new UserDao();
                String Md5 = user.Password;
                user.Password = Encryptor.MD5Hash(Md5);
                long id = dao.Insert(user);
                if(id>0)
                {
                    SetAlert("Thêm mới thành công", "success");
                    return RedirectToAction("Index","User");
                }
                else
                {
                    SetAlert("Thêm mới thất bại", "error");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dao = new UserDao();
            var user = dao.ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if(!String.IsNullOrEmpty(user.Password))
                {
                    String Md5 = user.Password;
                    user.Password = Encryptor.MD5Hash(Md5);
                }
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Cập nhật thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {

                    SetAlert("Cập nhật thất bại", "error");
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var dao = new UserDao();
            dao.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var dao = new UserDao();
            var result = dao.ChangeStatus(id);
            return Json(new
            {
                status = result
            }) ;
        }
    }
}
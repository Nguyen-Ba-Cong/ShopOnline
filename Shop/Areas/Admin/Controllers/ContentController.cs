using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
namespace Shop.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
         public ActionResult Index(int page=1, int pagesize=2)
        {
            var dao = new ConTentDao();
            var model = dao.ListAll(page, pagesize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create (ConTent content)
        {
            if(ModelState.IsValid)
            {
                var dao = new ConTentDao();
                long id = dao.Insert(content);
                if(id>0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("","Thêm mới thất bại");
                }
            }
            SetViewBag();
            return View();
        }
        public void SetViewBag(long? selectedId=null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
    }
}
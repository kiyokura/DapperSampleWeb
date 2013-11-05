using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperSampleWeb.Controllers
{
    public class BasicCRUDController : Controller
    {

        public ActionResult List()
        {
            var users = new Models.Users();
            return View(users.GetList());
        }

        
        public ActionResult Details(int id)
        {
            var users = new Models.Users();
            return View(users.GetDetail(id));
        }

        public ActionResult Count()
        {
            var users = new Models.Users();
            ViewBag.Count = users.GetCount();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.UserEntity data)
        {
            try
            {
                var users = new Models.Users();
                users.Create(data);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            var users = new Models.Users();
            return View(users.GetDetail(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.UserEntity data)
        {
            try
            {
                var users = new Models.Users();
                users.Update(data);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            var users = new Models.Users();
            return View(users.GetDetail(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Models.UserEntity data)
        {
            try
            {
                var users = new Models.Users();
                users.Delete(id);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperSampleWeb.Controllers
{
    public class StoredProcController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OutputByReturn()
        {
            var users = new Models.StoredProcUsers();
            ViewBag.Count = users.GetCountByReturn();
            return View();
        }

        public ActionResult OutputByOutParam()
        {
            var users = new Models.StoredProcUsers();
            ViewBag.Count = users.GetCountByOutParam();
            return View();
        }

        public ActionResult OutputByRecord()
        {
            var users = new Models.StoredProcUsers();
            return View(users.GetListByRecord());
        }
    }
}

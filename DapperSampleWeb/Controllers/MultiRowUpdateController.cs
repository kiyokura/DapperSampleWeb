using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperSampleWeb.Controllers
{
    public class MultiRowUpdateController : Controller
    {
        //
        // GET: /MultiRowUpdate/

        public ActionResult Index()
        {
            var users = new Models.MultiRowUpdateUsers();
            return View(users.GetList());
        }

        public ActionResult Insert()
        {
            var users = new Models.MultiRowUpdateUsers();
            users.InsertMultiRow();
            return RedirectToAction("Index");
        }

        public ActionResult Update()
        {
            var users = new Models.MultiRowUpdateUsers();
            users.UpdateMultiRow();
            return RedirectToAction("Index");
        }

        
    }
}

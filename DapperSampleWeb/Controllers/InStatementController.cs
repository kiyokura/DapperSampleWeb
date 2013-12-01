using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperSampleWeb.Controllers
{
    public class InStatementController : Controller
    {
        public ActionResult Index()
        {
            var users = new Models.InStatementUsers();
            return View(users.GetList());
        }

    }
}

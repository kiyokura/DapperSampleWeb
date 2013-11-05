using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperSampleWeb.Controllers
{
    public class DynamicController : Controller
    {
        public ActionResult Index()
        {
            var dynamicUser = new Models.DynamicUsers();
            return View(dynamicUser.GetList());
        }
    }
}

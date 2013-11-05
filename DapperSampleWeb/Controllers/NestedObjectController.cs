using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperSampleWeb.Controllers
{
    public class NestedObjectController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sample1()
        {
            var model = new Models.NestedObjectModels();
            return View(model.GetRecords1());
        }

        public ActionResult Sample2()
        {
            return View();
        }


    }
}

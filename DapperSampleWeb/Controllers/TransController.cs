using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperSampleWeb.UserTransController
{
    public class TransController : Controller
    {
        public ActionResult Index()
        {
            var users = new Models.TransUsers();
            return View(users.GetList());
        }

        public ActionResult Edit(int id)
        {
            var users = new Models.TransUsers();
            return View(users.GetDetail(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.UserEntity data, string submitButtonOK, string submitButtonNG)
        {
            // ボタンで振り分け。本来は属性つくって振り分けるのがいいけど、今回はそこは主題では無いのでパス。
            try
            {
                var users = new Models.TransUsers();
                if (!string.IsNullOrEmpty(submitButtonOK) && submitButtonOK == "Save（正常にコミットされるパターン）")
                {
                    users.UpdateCommitOK(data);
                }
                else if (!string.IsNullOrEmpty(submitButtonNG) && submitButtonNG == "Save（Rollbackされるパターン）")
                {
                    users.UpdateCommitNG(data);
                }
                else
                {
                    throw new Exception("想定外");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

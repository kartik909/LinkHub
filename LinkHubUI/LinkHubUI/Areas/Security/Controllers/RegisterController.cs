using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class RegisterController : BaseSecurityController
    {
        // GET: Security/Register
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(tbl_User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.Role = "U";
                    obj.userBs.Insert(user);
                    TempData["Msg"] = "user Registered";
                    return RedirectToAction("Index");
                }

                else
                {
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Registration Failed" +e1;
                return RedirectToAction("Index");

            }
                       

        }
    }
}
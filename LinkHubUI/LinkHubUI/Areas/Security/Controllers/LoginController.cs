using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LinkHubUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: Security/Login
        public ActionResult Login(tbl_User user)
        {
            try
            {
                if (Membership.ValidateUser(user.UserEmail, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }

                else
                {
                    TempData["Msg"] = "Login Failed";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Login Failed" + e1.Message;
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common"});
        }
    }
}
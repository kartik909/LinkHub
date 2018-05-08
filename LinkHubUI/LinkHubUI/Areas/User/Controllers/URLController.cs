using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
    [Authorize(Roles ="A,U")]
    public class URLController : BaseUserController
    {       
        // GET: User/URL
        public ActionResult Index()
        {

            ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetALL().ToList(), "CategoryId", "CategoryName");
            return View();
        }

        // POST: User/URL
        [HttpPost]
        public ActionResult Create(tbl_Url myUrl)
        {
            try
            {
                myUrl.IsApproved = "P";
                myUrl.UserId = objBs.userBs.GetALL().Where(x => x.UserEmail == User.Identity.Name).FirstOrDefault().UserId;
                
                    objBs.urlBs.Insert(myUrl);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");                              
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed :" + e1;
                return RedirectToAction("Index");
            }
            
        }

    }
}
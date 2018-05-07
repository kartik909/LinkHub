using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
    public class URLController : Controller
    {
        private UrlBs objBs;
        private CategoryBs objCatBs;
        private UserBs objUserBs;

        public URLController()
        {
            objBs = new UrlBs();
            objCatBs = new CategoryBs();
            objUserBs = new UserBs();

        }

        // GET: User/URL
        public ActionResult Index()
        {

            ViewBag.CategoryId = new SelectList(objCatBs.GetALL().ToList(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(objUserBs.GetALL().ToList(), "UserId", "UserEmail");
            return View();
        }


        // POST: User/URL
        [HttpPost]
        public ActionResult Create(tbl_Url myurl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objBs.Insert(myurl);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }

                else
                {
                    ViewBag.CategoryId = new SelectList(objCatBs.GetALL().ToList(), "CategoryId", "CategoryName");
                    ViewBag.UserId = new SelectList(objUserBs.GetALL().ToList(), "UserId", "UserEmail");
                    return RedirectToAction("Index");
                }

            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed :" + e1;
                return RedirectToAction("Index");
            }
            
        }

    }
}
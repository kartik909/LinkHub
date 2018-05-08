using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ApproveURLsController : BaseAdminController
    {
        // GET: Admin/ApproveURLs
        public ActionResult Index(string Status)
        {
            ViewBag.Status = (Status == null ? "P" : Status);
            if (Status == null)
            {
                var urls = obj.urlBs.GetALL().Where(x => x.IsApproved == "P").ToList();
                return View(urls);
            }
            else
            {
                var urls = obj.urlBs.GetALL().Where(x => x.IsApproved == Status).ToList();
                return View(urls);
            }
            
        }

        public ActionResult Approve(int id)
        {
            try
            {
                var myUrl = obj.urlBs.GetByID(id);
                myUrl.IsApproved = "A";
                obj.urlBs.Update(myUrl);
                TempData["Msg"] = "Approved";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Not Approved" +e1;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Reject(int id)
        {
            try
            {
                var myUrl = obj.urlBs.GetByID(id);
                myUrl.IsApproved = "R";
                obj.urlBs.Update(myUrl);
                TempData["Msg"] = "Rejected";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Not Approved" + e1;
                return RedirectToAction("Index");
            }
        }
    }
}
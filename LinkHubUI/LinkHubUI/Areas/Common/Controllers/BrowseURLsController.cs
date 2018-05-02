using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    public class BrowseURLsController : Controller
    {
        UrlBs objBs;

        public BrowseURLsController()
        {
            objBs = new UrlBs();
        }
        // GET: Common/BrowseURL
        public ActionResult Index()
        {
            var Urls = objBs.GetALL().Where(x=>x.IsApproved == "A").ToList();  
            return View(Urls);
        }
    }
}
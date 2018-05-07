using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    public class BrowseURLsController : BaseCommonController
    {
       
        // GET: Common/BrowseURL
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;

            var Urls = objBs.urlBs.GetALL().Where(x=>x.IsApproved == "A");

            switch (SortBy)
            {

                case "UrlTitle":

                    switch (SortOrder)
                    {
                        case "Asc":
                            Urls = Urls.OrderBy(x => x.UrlTitle).ToList();
                            break;

                        case "Desc":
                            Urls = Urls.OrderByDescending(x => x.UrlTitle).ToList();
                            break;

                        default:
                            break;
                    }
                    break;

                case "Url":

                    switch (SortOrder)
                    {
                        case "Asc":
                            Urls = Urls.OrderBy(x => x.Url).ToList();
                            break;

                        case "Desc":
                            Urls = Urls.OrderByDescending(x => x.Url).ToList();
                            break;

                        default:
                            break;
                    }
                    break;
                case "UrlDesc":

                    switch (SortOrder)
                    {
                        case "Asc":
                            Urls = Urls.OrderBy(x => x.UrlDesc).ToList();
                            break;

                        case "Desc":
                            Urls = Urls.OrderByDescending(x => x.UrlDesc).ToList();
                            break;

                        default:
                            break;
                    }
                    break;
                case "CategoryName":

                    switch (SortOrder)
                    {
                        case "Asc":
                            Urls = Urls.OrderBy(x => x.tbl_Category.CategoryName).ToList();
                            break;

                        case "Desc":
                            Urls = Urls.OrderByDescending(x => x.tbl_Category.CategoryName).ToList();
                            break;

                        default:
                            break;
                    }
                    break;
                default:
                    Urls = Urls.OrderBy(x => x.UrlTitle).ToList();
                    break;
}
            ViewBag.TotalPages = Math.Ceiling(objBs.urlBs.GetALL().Where(x => x.IsApproved == "A").Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            Urls = Urls.Skip((page - 1) * 10).Take(10); 
            return View(Urls);
        }
    }
    
}
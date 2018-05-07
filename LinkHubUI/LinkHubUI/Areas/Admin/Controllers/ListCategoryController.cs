using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class ListCategoryController : BaseAdminController
    {
       
        // GET: Admin/ListCategory
        public ActionResult Index(string SortOrder, string SortBy)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var categories = obj.categoryBs.GetALL();

            switch (SortBy)
            {
                case "CategoryName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            categories = obj.categoryBs.GetALL().OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "Desc":
                            categories = obj.categoryBs.GetALL().OrderByDescending(x => x.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "CategoryDesc":
                    switch (SortOrder)
                    {
                        case "Asc":
                            categories = obj.categoryBs.GetALL().OrderBy(x => x.CategoryDesc).ToList();
                            break;
                        case "Desc":
                            categories = obj.categoryBs.GetALL().OrderByDescending(x => x.CategoryDesc).ToList();
                            break;
                        default:
                            obj.categoryBs.GetALL();
                            break;
                    }
                    break;
                default:
                    break;
            }
            return View(categories);
        }

        public ActionResult Delete(int Id)
        {
            try {
                TempData["Msg"] = "Deleted Successfully";
                obj.categoryBs.Delete(Id);
                return RedirectToAction("Index");
            }
            catch (Exception e1) {
                TempData["Msg"] = "Delete Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
            
        }
    }
}
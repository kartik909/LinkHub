using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ListUserController : BaseAdminController
    {
        // GET: Admin/ListUser
        public ActionResult Index(string SortOrder, string SortBy)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var users = obj.userBs.GetALL();

            switch(SortBy)
            {
                case "UserEmail":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.UserEmail).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.UserEmail).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "UserPassword":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.Password).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.Password).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "UserRole":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.Role).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.Role).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
            }

            
            return View(users);
        }
    }
}
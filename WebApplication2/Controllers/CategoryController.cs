using Business;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LHS.Controllers
{
    public class CategoryController : Controller
    {
        private DBContext db = new DBContext();
        private UsersBusiness userBusiness = new UsersBusiness();
        // GET: Category/SMTH
        public ActionResult Index(string cat)
        {
            if (cat == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<User> list = userBusiness.Get(cat);
            if (list.Capacity == 0)
            {
                return HttpNotFound();
            }
            ViewData["category"] = cat;
            return View(list);
        }
    }
}
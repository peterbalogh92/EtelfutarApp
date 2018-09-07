using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Etelfutar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product(string category, string filter)
        {
            ViewData["category"] = category;
            ViewData["filter"] = filter;
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotebookCloud.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Security()
        {
            ViewBag.Message = "Your application security page.";

            return View();
        }

        public ActionResult FreeTrial()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
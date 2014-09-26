using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotebookCloud.Src;

namespace NotebookCloud.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (this.Request.IsFromEU())
            {
                ViewBag.AcademicCloudPrice1 = "€25/user/quarter";
                ViewBag.AcademicCloudPrice2 = "€100/user/year";
                ViewBag.BusinessCloudPrice1 = "€150/user/quarter";
                ViewBag.BusinessCloudPrice2 = "€540/user/year";
                ViewBag.BusinessCloudPrice3 = "€135/user/quarter";
                ViewBag.BusinessCloudPrice4 = "€486 /user/year";
                ViewBag.BusinessCloudPrice5 = "€122/user/quarter";
                ViewBag.BusinessCloudPrice6 = "€437/user/year";
            }
            else
            {
                ViewBag.AcademicCloudPrice1 = "$30/user/quarter";
                ViewBag.AcademicCloudPrice2 = "$120/user/year";
                ViewBag.BusinessCloudPrice1 = "$180/user/quarter";
                ViewBag.BusinessCloudPrice2 = "$648/user/year";
                ViewBag.BusinessCloudPrice3 = "$162/user/quarter";
                ViewBag.BusinessCloudPrice4 = "$583 /user/year";
                ViewBag.BusinessCloudPrice5 = "$146/user/quarter";
                ViewBag.BusinessCloudPrice6 = "$525/user/year";
            }

            ViewBag.Country = Request.GetCountry();
            
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
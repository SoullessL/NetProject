using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocAndAop.Core;

namespace IocAndAop.Controllers
{
    public class HomeController : Controller
    {
        readonly iSendEmail outlook;

        public HomeController(iSendEmail outlook)
        {
            this.outlook = outlook;
        }

        public ActionResult About()
        {

            var t = outlook.SendEmail();
            ViewBag.Message = t;

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
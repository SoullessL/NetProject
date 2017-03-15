using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IocAndAop.Core;
using log4net;
using System.Reflection;
using System.Diagnostics;

namespace IocAndAop.Controllers
{
    public class HomeController : Controller
    {
        readonly OutlookEmail outlook;
        readonly ILog ilog;

        public HomeController(OutlookEmail outlook, ILog ilog)
        {
            this.outlook = outlook;
            this.ilog = ilog;
        }

        [HttpGet]
        public ActionResult About()
        {

            var t = outlook.SendEmail();
            ViewBag.Message = t;
            //ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            //log.Info("This is log5 net log.");

            this.ilog.Info("This is log4 net log.");
            Debug.WriteLine("Process request");
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
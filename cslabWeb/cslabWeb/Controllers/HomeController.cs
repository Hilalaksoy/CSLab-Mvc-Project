using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cslabWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {         
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public  ActionResult Lab1001()
        {
            return View();
        }
        public ActionResult Lab1003()
        {
            return View();
        }
        public ActionResult Lab1101()
        {
            return View();
        }
    }
}
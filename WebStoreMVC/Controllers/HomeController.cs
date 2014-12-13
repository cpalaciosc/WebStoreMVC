using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebStoreMVC.Models;
    

namespace WebStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private WebStoreDBEntities db = new WebStoreDBEntities();
        
        public ActionResult Index()
        {
            return RedirectToAction("Catalog", "ShoppingCart");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ProjectDetails()
        {
            ViewBag.Message = "Características implementadas";

            return View();
        }
    }
}
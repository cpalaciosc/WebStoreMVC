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


        // GET: Producto/Edit/5
        /*
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }
         * */

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
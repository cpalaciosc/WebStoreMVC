using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebStoreMVC.Helpers;
using WebStoreMVC.Models;
using WebStoreMVC.Models.ShoppingCart;

namespace WebStoreMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private WebStoreDBEntities db = new WebStoreDBEntities();

        public ActionResult Catalog()
        {
            return View(db.Producto.ToList());
        }

        [HttpPost]
        public ActionResult Search(FormCollection form)
        {
            String producto = form["srch-term"].ToString();
            ViewBag.Message = producto;
            var productos = from prod in db.Producto
                            where prod.nombre.Contains(producto)
                            select prod;



            return View("Catalog", productos.ToList());
        }

        // GET: ShoppingCart/ViewProduct/5
        [HttpGet]
        public ActionResult ViewProduct(int? id)
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        // POST: ShoppingCart/Checkout
        public ActionResult Checkout([ModelBinder(typeof(ItemModelBinder))] Item item)
        {
            ViewBag.ShoppingCart = UpdateShoppingCart(item);
            return View();
        }

        [Authorize]
        // GET: ShoppingCart/Checkout
        public ActionResult Checkout()
        {
            ViewBag.ShoppingCart = UpdateShoppingCart();
            return View();
        }

        private ShoppingCart UpdateShoppingCart(Item item = null)
        {
            ShoppingCart shoppingCart = Session.GetDataFromSession<ShoppingCart>("shoppingCart");
            if(item!=null)
            {
                shoppingCart.Add(item);
            }

            var groupedShopiingCart = shoppingCart.GroupBy(i => i.item);
            
            Session.SetDataToSession<ShoppingCart>("shoppingCart", shoppingCart);

            return shoppingCart;
        }

    }
}
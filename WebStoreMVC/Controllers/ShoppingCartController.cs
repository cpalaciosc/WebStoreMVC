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
            string purchaseResult = Request.QueryString["result"];
            if (purchaseResult != null)
                ViewBag.ResultadoCompra = purchaseResult;
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
            ViewBag.ShoppingCart = AddToShoppingCart(item);
            return View();
        }

        [Authorize]
        // GET: ShoppingCart/Checkout
        public ActionResult Checkout()
        {
            ViewBag.ShoppingCart = AddToShoppingCart();
            return View();
        }

        [Authorize]
        // GET: ShoppingCart/Checkout
        public ActionResult Purchase()
        {
            bool resultado = SaveShoppingCart();
            return RedirectToAction("Catalog", new { result = resultado.ToString()});
        }

        // GET: ShoppingCart/Delete/5
        [Authorize]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RemoveFromShoppingCart(id);

            return RedirectToAction("Checkout");
        }

        private ShoppingCart AddToShoppingCart(Item item = null)
        {
            ShoppingCart shoppingCart = Session.GetDataFromSession<ShoppingCart>("shoppingCart");
            if (item != null)
            {
                shoppingCart.AddItem(item);
            }

            Session.SetDataToSession<ShoppingCart>("shoppingCart", shoppingCart);

            return shoppingCart;
        }

        private void RemoveFromShoppingCart(int? itemId)
        {
            ShoppingCart shoppingCart = Session.GetDataFromSession<ShoppingCart>("shoppingCart");
            if (itemId != null)
            {
                shoppingCart.RemoveAll(itemRemove => itemRemove.item.id == itemId);
            }

            Session.SetDataToSession<ShoppingCart>("shoppingCart", shoppingCart);

        }

        private Boolean SaveShoppingCart()
        {
            ShoppingCart shoppingCart = Session.GetDataFromSession<ShoppingCart>("shoppingCart");
            shoppingCart.username = User.Identity.Name;
            return shoppingCart.Save();
        }

    }
}
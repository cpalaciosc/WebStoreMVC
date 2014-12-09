using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebStoreMVC.Models.ShoppingCart
{
    public class ItemModelBinder : DefaultModelBinder
    {

        private WebStoreDBEntities db = new WebStoreDBEntities();

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new InvalidOperationException("Error MB");

            var request = controllerContext.HttpContext.Request;

            int idProducto = Convert.ToInt32(request.Form.Get("id"));
            Producto item = this.ProductoSeleccionado(idProducto);
            int cantidad = Convert.ToInt32(request.Form.Get("quantity"));

            return new Item { item = item, cantidad = cantidad };
        }

        private Producto ProductoSeleccionado(int id)
        {
            if (id == null)
            {
                throw new InvalidOperationException("Id del producto seleccionado no puede ser null");
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                throw new InvalidOperationException("Producto no encontrado");
            }
            return producto;
        }
    }
}
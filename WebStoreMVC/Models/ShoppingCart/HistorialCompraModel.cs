using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreMVC.Models.ShoppingCart
{
    public class HistorialCompraModel
    {
        public Compra Compra { get; set; }
        public CompraDetalle Detalle { get; set; }
        public Producto Producto { get; set; }
    }
}
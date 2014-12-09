using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStoreMVC.Models.ShoppingCart
{
    public class ShoppingCart : List<Item>
    {
        public int cantidad
        {
            get
            {
                int cantidad = 0;
                foreach (Item item in this)
                {
                    cantidad += (item.cantidad);
                }
                return cantidad;
            }
        }

        public decimal total
        {
            get
            {
                decimal total = 0;
                foreach(Item item in this)
                {
                    total += (item.item.precio * item.cantidad);
                }
                return total;
            }
        }
    }
}
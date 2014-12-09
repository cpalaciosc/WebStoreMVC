using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStoreMVC.Models.ShoppingCart
{
    public class Item
    {
        [Required]
        public int cantidad { get; set; }

        [Required]
        public Producto item { get; set; }

        public decimal total
        {
            get
            {
                return this.cantidad * this.item.precio;
            }
            
        }

    }
}
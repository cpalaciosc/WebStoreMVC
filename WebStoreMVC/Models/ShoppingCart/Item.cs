using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebStoreMVC.Models.ShoppingCart
{
    public class Item : IEquatable<Item>
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

        public bool Equals(Item other)
        {
            if(other==null)
            {
                return false;
            }
            return this.item.id == other.item.id;
        }

    }
}
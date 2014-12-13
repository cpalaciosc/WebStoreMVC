using System;
using System.Collections.Generic;
using System.Linq;

namespace WebStoreMVC.Models.ShoppingCart
{
    public class ShoppingCart : List<Item>
    {
        public void AddItem(Item item)
        {
            if(this.Exists(i=>i.item.id == item.item.id))
            {
                Item existing = this.Find(i => i.item.id == item.item.id);
                existing.cantidad = existing.cantidad + item.cantidad;
            }
            else
            {
                this.Add(item);
            }
        }

        public string username { get; set; }

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

        public Boolean empty
        {
            get
            {
                return this.ToList().Count == 0;
            }
        }

        public Boolean Save()
        {
            try 
            {
                WebStoreDBEntities db = new WebStoreDBEntities();

                Compra compra = new Compra();
                compra.username = this.username;
                compra.fecha = DateTime.Now;

                compra = db.Compra.Add(compra);
                db.SaveChanges();

                foreach (Item item in this)
                {
                    CompraDetalle compraDetalle = new CompraDetalle();
                    compraDetalle.id_compra = compra.id;
                    compraDetalle.id_producto = item.item.id;
                    compraDetalle.cantidad = item.cantidad;

                    db.CompraDetalle.Add(compraDetalle);
                    db.SaveChanges();
                }

                this.Clear();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
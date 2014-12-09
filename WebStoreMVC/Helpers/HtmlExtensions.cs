using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStoreMVC.Models.ShoppingCart;

namespace WebStoreMVC.Helpers
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString Image(this HtmlHelper html, byte[] image, string cssClass)
        {
            var img = "";
            if(image!=null)
            {
                img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
                
            }
            else
            {
                img = "../../images/no_image.jpg"; 
            }

            return new MvcHtmlString("<img src='" + img + "' class='" + cssClass + "' />");

        }

        public static MvcHtmlString Quantity(this HtmlHelper html, string cssClass)
        {
            string quatityCombo = "<select name='quantity' autocomplete='off' id='quantity' class='" + cssClass + "'>";
            quatityCombo += "<option value='1' selected=''>1</option>";
            for(int i=2; i<=10; i++)
            {
                quatityCombo += "<option value='"+i+"'>"+i+"</option>";
            }
            quatityCombo += "</select>";

            return new MvcHtmlString(quatityCombo);
        }

        public static MvcHtmlString ShoppingCartSummary(this HtmlHelper html, string cssClass)
        {
            ShoppingCart shoppingCart = (ShoppingCart)(HttpContext.Current.Session["shoppingCart"]);
            string shoppingCartHtml = "<a href='/ShoppingCart/Checkout'><span class='glyphicon glyphicon-shopping-cart'></span>Cesta<span class='badge'>" + shoppingCart.cantidad + "</span></a>";
            return new MvcHtmlString(shoppingCartHtml);
        }

        public static MvcHtmlString CheckoutButton(this HtmlHelper html, string message)
        {
            ShoppingCart shoppingCart = (ShoppingCart)(HttpContext.Current.Session["shoppingCart"]);
            int cantidad = shoppingCart.cantidad;

            string display = "";

            if(cantidad==0)
            {
                display = "hidden";
            }

            string stringHtml = "<button type='submit' class='btn btn-primary " + display + "' role='button'>" +
                          "<span class='glyphicon glyphicon-shopping-cart'></span>"+message+
                          "</button>";

            return new MvcHtmlString(stringHtml);
        }


    }
}
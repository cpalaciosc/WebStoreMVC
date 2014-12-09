﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebStoreMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "ProductPreview",
                 url: "ShoppingCart/ViewProduct/{id}",
                 defaults: new { controller = "ShoppingCart", action = "ViewProduct", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ShoppingCart", action = "Catalog", id = UrlParameter.Optional }
            );
        }
    }
}

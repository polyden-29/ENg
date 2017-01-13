using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Okoone_Assignment
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Page", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Page",
               url: "{Page}/{action}/{id}",
               defaults: new { controller = "Page", action = "Register", id = UrlParameter.Optional }
           );
        }
    }
}
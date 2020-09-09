using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "About",
               url: "about-us",
               defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "Shop.Controllers" }
           );
            routes.MapRoute(
                name: "Product Category",
                url: "san-pham/{metatitle}-{cateid}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "Shop.Controllers" }
            );
            routes.MapRoute(
               name: "Product Detail",
               url: "chi-tiet/{metatitle}-{DetailId}",
               defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
               namespaces: new[] { "Shop.Controllers" }
           );
            routes.MapRoute(
             name: "Add Cart",
             url: "them-gio-hang",
             defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
             namespaces: new[] { "Shop.Controllers" }
         );
            routes.MapRoute(
             name: "Cart",
             url: "gio-hang",
             defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
             namespaces: new[] { "Shop.Controllers" }
         );
            routes.MapRoute(
            name: "Payment",
            url: "thanh-toan",
            defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
            namespaces: new[] { "Shop.Controllers" }
        );
            routes.MapRoute(
              name: "Contact",
              url: "lien-he",
              defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "Shop.Controllers" }

          );
            routes.MapRoute(
             name: "Register",
             url: "dang-ky",
             defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
             namespaces: new[] { "Shop.Controllers" }

         );
            routes.MapRoute(
           name: "Login",
           url: "dang-nhap",
           defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional },
           namespaces: new[] { "Shop.Controllers" }

       );
            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "Shop.Controllers" }
          );
        }
    }
}

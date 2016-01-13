using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AAWebhookHandler
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "Index",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Webhook Handler",
                url: "WebhookHandler",
                defaults: new { controller = "Home", action = "WebhookHandler" }
            );
        }
    }
}
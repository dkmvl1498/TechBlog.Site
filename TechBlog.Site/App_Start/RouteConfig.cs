using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TechBlog.Site
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
        protected void Configure(HttpConfiguration configuration)
        {
            var routes = configuration.Routes;
            //routes.MapHttpRoute(
            //"VillageHouseExternalAPI",
            //"api/villagehouse/External/{action}",
            //new { controller = "Home" });

            var route = routes.MapHttpRoute(
            "VillageHouseAPI",
            "api/villagehouse/{controller}/{action}");

        }
    }
}

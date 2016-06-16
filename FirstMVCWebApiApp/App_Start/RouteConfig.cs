using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstMVCWebApiApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    name:"finding",
            //    url:"find/trouve",
            //    defaults: new {controller= "Home", action="index",id=UrlParameter.Optional}
            //);


            //routes.MapRoute(
            //    name: "student",
            //    url: "depart",
            //    defaults: new { controller = "Student", action = "GetAll", id = UrlParameter.Optional }
            //);


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

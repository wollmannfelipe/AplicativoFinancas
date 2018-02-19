using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WepApiFinancas
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            

        //config.MapHttpAttributeRoutes();
        //config.Routes.MapHttpRoute(
        //    name: "DefaultApi",
        //    routeTemplate: "api/{controller}/{action}/{id}",
        //    defaults: new { id = RouteParameter.Optional }                

        // Web API configuration and services

        // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            

//            var politicas = new EnableCorsAttribute(
  //              origins: "*",
    //            methods: "*",
      //          headers: "*"
        //        );
        //
            config.EnableCors();
        }
    }    
}

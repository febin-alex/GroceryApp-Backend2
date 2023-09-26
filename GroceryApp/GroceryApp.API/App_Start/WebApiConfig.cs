﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GroceryApp.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //var corsAttr = new EnableCorsAttribute("http://localhost:60901/", "*", "*");
            //config.EnableCors(corsAttr);
        }
    }
}

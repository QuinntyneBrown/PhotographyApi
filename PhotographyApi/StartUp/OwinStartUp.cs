using System;
using System.Threading.Tasks;
using System.Web.Http;
using Common.OAuth;
using Common.StartUp;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Unity.WebApi;

[assembly: OwinStartup(typeof(Common.StartUp.OwinStartUp))]

namespace PhotographyApi.StartUp
{
    public class OwinStartUp
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            app.UseWebApi(config);
        }
    }
}
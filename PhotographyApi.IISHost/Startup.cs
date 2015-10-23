using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Unity.WebApi;

[assembly: OwinStartup(typeof(PhotographyApi.IISHost.Startup))]

namespace PhotographyApi.IISHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(PhotographyApi.UnityConfiguration.GetContainer());

            GlobalConfiguration.Configure(config => PhotographyApi.ApiConfiguration.Install(config, app));
        }
    }
}

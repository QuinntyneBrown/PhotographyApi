using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using PhotographyApi.API;

[assembly: OwinStartup(typeof(PhotographyApi.IISHost.Startup))]

namespace PhotographyApi.IISHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(config => PhotographyApi.ApiConfiguration.Install(config, app));
        }
    }
}

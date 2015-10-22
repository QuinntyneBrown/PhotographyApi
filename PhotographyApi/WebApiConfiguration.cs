using System.Net.Http.Headers;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using Unity.WebApi;

namespace PhotographyApi.API
{
    public class WebApiConfiguration
    {
        public static void Configure(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            ConfigureFormatters(config);
            EnableCors(config);

        }

        private static void ConfigureFormatters(HttpConfiguration config)
        {
            var jSettings = new JsonSerializerSettings();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings = jSettings;
            jSettings.NullValueHandling = NullValueHandling.Ignore;
            jSettings.Formatting = Formatting.Indented;
            jSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/vnd.issue+json"));
        }

        public static void ConfigureUnity(HttpConfiguration config)
        {
            config.DependencyResolver = new UnityDependencyResolver(UnityConfig.GetContainer());
        }

        public static void EnableCors(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}
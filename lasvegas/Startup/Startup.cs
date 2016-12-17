using Microsoft.Owin;
using Owin;
using Swashbuckle.Application;
using System.Web.Http;

[assembly: OwinStartup(typeof(Lasvegas.Startup.Bootstrap))]

namespace Lasvegas.Startup
{
    public class Bootstrap
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWebApi();
            app.UseNancy();
        }
    }

    internal static class IAppBuilderExtension
    {
        public static void UseWebApi(this IAppBuilder app)
        {
            var config = new HttpConfiguration();

            // WebAPIs
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("apis", "api/v1/{controller}/{id}", new { id = RouteParameter.Optional });

            // SwaggerUI, index page: /docs/index
            config
                .EnableSwagger("docs/{apiVersion}/swagger", c =>
                {
                    c.SingleApiVersion("v1", "API Docs");
                    c.ApiKey("apiKey")
                        .Description("API Key Authentication")
                        .Name("apiKey")
                        .In("header");
                })
                .EnableSwaggerUi("docs/{*assetPath}", c =>
                {
                    c.DocExpansion(DocExpansion.List);
                    c.EnableApiKeySupport("apiKey", "header");
                });

            app.UseWebApi(config);
        }
    }
}

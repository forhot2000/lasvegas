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
            var httpCongiguration = new HttpConfiguration();

            // WebAPIs
            httpCongiguration.MapHttpAttributeRoutes();
            httpCongiguration.Routes.MapHttpRoute("apis", "api/v1/{controller}/{id}", new { id = RouteParameter.Optional });

            // SwaggerUI, index page: /docs/index
            httpCongiguration
                .EnableSwagger("docs/{apiVersion}/swagger", c => c.SingleApiVersion("v1", "API Docs"))
                .EnableSwaggerUi("docs/{*assetPath}");

            app.UseWebApi(httpCongiguration);

            // Nancy
            app.UseNancy();
        }
    }
}

using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Lasvegas.Startup.Bootstrap))]

namespace Lasvegas.Startup
{
    public class Bootstrap
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("apis", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            app.UseWebApi(config);

            app.UseNancy();
        }
    }
}

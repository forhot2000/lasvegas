using Nancy;

namespace Lasvegas.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => "Hello world";
        }
    }
}

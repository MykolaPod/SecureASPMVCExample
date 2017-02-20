using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoLogOutSample.Services;

namespace AutoLogOutSample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            WebBackgrounderSetup.Start();
        }

        protected void Application_End()
        {
            WebBackgrounderSetup.Shutdown();
        }
    }
}

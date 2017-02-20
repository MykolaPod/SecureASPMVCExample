using System;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoLogOutSample.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

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

        protected void Session_Start(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

                HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            }
        }
    }
}

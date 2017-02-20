using System;
using System.Web;
using System.Web.Mvc;

namespace AutoLogOutSample.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class NoCacheAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            try
            {
                filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
                filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                filterContext.HttpContext.Response.Cache.SetNoStore();
                filterContext.HttpContext.Response.Cache.SetMaxAge(TimeSpan.Zero);
                filterContext.HttpContext.Response.Cache.SetVaryByCustom("*");
            }
            catch (Exception e)
            {
                //nothing
            }

            base.OnResultExecuting(filterContext);
        }
    }
}
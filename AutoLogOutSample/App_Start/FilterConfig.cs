using System.Web;
using System.Web.Mvc;
using AutoLogOutSample.Attributes;

namespace AutoLogOutSample
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new NoCacheAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}

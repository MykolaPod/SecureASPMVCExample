using System.Collections.Concurrent;
using System.Net;
using System.Web.Mvc;
using AutoLogOutSample.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace AutoLogOutSample.Controllers
{
    public abstract class BaseController:Controller
    {
        public static ConcurrentDictionary<string, PingObject> UsersPingResult = new ConcurrentDictionary<string, PingObject>();
        
        protected IAuthenticationManager AuthenticationManager { get; }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            var urlReferrer = Request.UrlReferrer?.LocalPath;
            var isLogin = urlReferrer == null ? false : urlReferrer.Contains("Login");

            PingObject.SessionTimeoutMin = Session.Timeout;
            if (!isLogin && (UsersPingResult.ContainsKey(Session.SessionID) && !UsersPingResult[Session.SessionID].PingStatus) && User.Identity.IsAuthenticated)
            {
                if (UsersPingResult.ContainsKey(Session.SessionID) && UsersPingResult[Session.SessionID].IsSessionAllowed == false)
                {
                    PingObject value;
                    UsersPingResult.TryRemove(Session.SessionID, out value);

                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    Session.Clear();
                    Session.Abandon();

                    filterContext.Result = RedirectToAction("Login", "Account");
                    return;
                }
            }

            base.OnAuthorization(filterContext);

        }

        public ActionResult PingPage(bool isClosing)
        {
            UsersPingResult.AddOrUpdate(Session.SessionID, new PingObject() { PingStatus = isClosing, IsSessionAllowed = true }, (s, b) => new PingObject() { PingStatus = isClosing, IsSessionAllowed = true });

            return new EmptyResult();

        }

    }
}
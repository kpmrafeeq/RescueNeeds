using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RescueNeeds.App_Start
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public string Role { get; set; }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/account/login");
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var roles = Role.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var role = httpContext.Session["Role"];
            if (httpContext.Session["Logged"] == "true" && roles.Any(x => x == (string)role))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

     

    }
}
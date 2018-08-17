using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RescueNeeds.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (username == ConfigurationManager.AppSettings["username"] && password == ConfigurationManager.AppSettings["password"])
            {
                Session["Logged"] = "true";
                return RedirectToAction("index", "home");
            }
            else
            {
                Session["Logged"] = "false";
                return RedirectToAction("login", "account");
            }
        }
    }
}
using RescueNeeds.Service;
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
        private RescueNeedsEntities db = new RescueNeedsEntities();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Session["SuperAdmin"] = "false";
            Session["CampAdmin"] = "false";
            Session["CampAdminID"] = "";
            if (username == ConfigurationManager.AppSettings["username"] && password == ConfigurationManager.AppSettings["password"])
            {
                Session["Logged"] = "true";
                Session["SuperAdmin"] = "true";
                Session["CampAdmin"] = "false";
                return RedirectToAction("index", "home");
            }

            int personId;
            int.TryParse(username, out personId);

            var users = db.Persons.FirstOrDefault(x => x.PersonID == personId && x.Password == password);
            if (users != null)
            {
                Session["CampAdminID"] = personId;
                Session["Logged"] = "true";
                Session["SuperAdmin"] = "false";
                Session["CampAdmin"] = "true";

                return RedirectToAction("index", "home");
            }
            else
            {
                Session["Logged"] = "false";
                return RedirectToAction("login", "account");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
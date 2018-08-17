using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RescueNeeds.Service;
using RescueNeeds.Models;

namespace RescueNeeds.Controllers
{
    public class HomeController : Controller
    {
        private RescueNeedsEntities db = new RescueNeedsEntities();

        // GET: Home
        public ActionResult Index(string district, string place)
        {
            
            var districts = db.Districts.ToList();
            var places = db.Places.ToList();
            CampRequirementHomeViewModel model = new CampRequirementHomeViewModel()
            {
                Data = new  List<Camp>(),
                District=districts,
                Places=places
            };
            int districtId,placeId;
            if(!string.IsNullOrEmpty(district) &&  int.TryParse(district, out districtId))
            {
                var campRequirements = db.Camps;
                model.Data = campRequirements.Where(x => x.DistrictID == districtId);
            }

            if (!string.IsNullOrEmpty(place) && int.TryParse(place, out placeId))
            {
                model.Data = model.Data.Where(x => x.PlaceID == placeId);
            }
            return View(model);
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<CampRequirement> campRequirement = db.CampRequirements.Where(x => x.CampsID.Value == id).ToList();
            if (campRequirement == null)
            {
                return HttpNotFound();
            }
            return View(campRequirement);
        }

        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult Disclaimer()
        {
            return View();
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

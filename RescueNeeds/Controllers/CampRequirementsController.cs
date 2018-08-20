using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RescueNeeds.Service;
using RescueNeeds.App_Start;

namespace RescueNeeds.Controllers
{
    [AuthorizeUser(Role = "Admin,CampAdmin")]
    public class CampRequirementsController : Controller
    {
        private RescueNeedsEntities db = new RescueNeedsEntities();

        // GET: CampRequirements
        public ActionResult Index()
        {
            var campRequirements = db.CampRequirements.Include(c => c.Camp).Include(c => c.Item);
            
            if (Session["CampAdmin"] == "true")
            {
                var id = (int)Session["CampAdminID"];
                var camp = db.CampInCharges.Where(x => x.PersonID == id).Select(y => y.CampsID);
                campRequirements = campRequirements.Where(x => camp.Contains(x.CampsID));
                return View(campRequirements.ToList());
            }
            else
            {
                return View(campRequirements.ToList());
            }
            
        }

        // GET: CampRequirements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampRequirement campRequirement = db.CampRequirements.Find(id);
            if (campRequirement == null)
            {
                return HttpNotFound();
            }
            return View(campRequirement);
        }

        // GET: CampRequirements/Create
        public ActionResult Create()
        {
            if (Session["CampAdmin"] == "true")
            {
                var id = (int)Session["CampAdminID"];
                var camp = db.CampInCharges.Where(x => x.PersonID == id).Select(y => y.CampsID);
                var camps = db.Camps.Where(x => camp.Contains(x.CampsID));
                ViewBag.CampsID = camps.ToList();
            }
            else
            {
                ViewBag.CampsID = db.Camps.ToList();
            }

            
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name");
            return View();
        }

        // POST: CampRequirements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CampRequirementID,CampsID,ItemID,Need,Recieved")] CampRequirement campRequirement)
        {
            if (ModelState.IsValid)
            {
                db.CampRequirements.Add(campRequirement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (Session["CampAdmin"] == "true")
            {
                var id = (int)Session["CampAdminID"];
                var camp = db.CampInCharges.Where(x => x.PersonID == id).Select(y => y.CampsID);
                var camps = db.Camps.Where(x => camp.Contains(x.CampsID));
                ViewBag.CampsID = camps.ToList();
            }
            else
            {
                ViewBag.CampsID = db.Camps.ToList();
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", campRequirement.ItemID);
            return View(campRequirement);
        }

        // GET: CampRequirements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampRequirement campRequirement = db.CampRequirements.Find(id);
            if (campRequirement == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampsID = new SelectList(db.Camps, "CampsID", "Name", campRequirement.CampsID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", campRequirement.ItemID);
            return View(campRequirement);
        }

        // POST: CampRequirements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampRequirementID,CampsID,ItemID,Need,Recieved")] CampRequirement campRequirement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campRequirement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampsID = new SelectList(db.Camps, "CampsID", "Name", campRequirement.CampsID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", campRequirement.ItemID);
            return View(campRequirement);
        }

        // GET: CampRequirements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampRequirement campRequirement = db.CampRequirements.Find(id);
            if (campRequirement == null)
            {
                return HttpNotFound();
            }
            return View(campRequirement);
        }

        // POST: CampRequirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CampRequirement campRequirement = db.CampRequirements.Find(id);
            db.CampRequirements.Remove(campRequirement);
            db.SaveChanges();
            return RedirectToAction("Index");
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

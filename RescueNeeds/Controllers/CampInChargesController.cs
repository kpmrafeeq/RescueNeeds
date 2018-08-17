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
    [AuthorizeUser]
    public class CampInChargesController : Controller
    {
        private RescueNeedsEntities db = new RescueNeedsEntities();

        // GET: CampInCharges
        public ActionResult Index()
        {
            var campInCharges = db.CampInCharges.Include(c => c.District).Include(c => c.Person).Include(c => c.Place);
            return View(campInCharges.ToList());
        }

        // GET: CampInCharges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampInCharge campInCharge = db.CampInCharges.Find(id);
            if (campInCharge == null)
            {
                return HttpNotFound();
            }
            return View(campInCharge);
        }

        // GET: CampInCharges/Create
        public ActionResult Create()
        {
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "Name");
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "LastName");
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Name");
            return View();
        }

        // POST: CampInCharges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CampsID,Name,Address1,PlaceID,DistrictID,PersonID")] CampInCharge campInCharge)
        {
            if (ModelState.IsValid)
            {
                db.CampInCharges.Add(campInCharge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "Name", campInCharge.DistrictID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "LastName", campInCharge.PersonID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Name", campInCharge.PlaceID);
            return View(campInCharge);
        }

        // GET: CampInCharges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampInCharge campInCharge = db.CampInCharges.Find(id);
            if (campInCharge == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "Name", campInCharge.DistrictID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "LastName", campInCharge.PersonID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Name", campInCharge.PlaceID);
            return View(campInCharge);
        }

        // POST: CampInCharges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampsID,Name,Address1,PlaceID,DistrictID,PersonID")] CampInCharge campInCharge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campInCharge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistrictID = new SelectList(db.Districts, "DistrictID", "Name", campInCharge.DistrictID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "LastName", campInCharge.PersonID);
            ViewBag.PlaceID = new SelectList(db.Places, "PlaceID", "Name", campInCharge.PlaceID);
            return View(campInCharge);
        }

        // GET: CampInCharges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampInCharge campInCharge = db.CampInCharges.Find(id);
            if (campInCharge == null)
            {
                return HttpNotFound();
            }
            return View(campInCharge);
        }

        // POST: CampInCharges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CampInCharge campInCharge = db.CampInCharges.Find(id);
            db.CampInCharges.Remove(campInCharge);
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

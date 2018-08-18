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
using RescueNeeds.Models;

namespace RescueNeeds.Controllers
{
    [AuthorizeUser(Role = "Admin")]
    public class CampInChargesController : Controller
    {
        private RescueNeedsEntities db = new RescueNeedsEntities();

        // GET: CampInCharges
        public ActionResult Index()
        {
            var campInCharges = db.CampInCharges.Include(c => c.Camp).Include(c => c.Person);
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
            ViewBag.CampsID = db.Camps.Include(d=>d.District).ToList(); ;

            //ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "LastName");
            return View();
        }

        // POST: CampInCharges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CampInChargeID,CampsID,PersonID,LastName,FirstName,Address,Cell,Email,Password")] CampInChargeViewModel campInCharge)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person()
                {
                    PersonID = campInCharge.PersonID,
                    Address = campInCharge.Address,
                    Cell = campInCharge.Cell,
                    Email = campInCharge.Email,
                    FirstName = campInCharge.FirstName,
                    LastName = campInCharge.LastName,
                    Password=campInCharge.Password
                };
                db.Persons.Add(person);
                var updatedPErson = db.SaveChanges();

                CampInCharge data = new CampInCharge()
                {
                    PersonID = person.PersonID,
                    CampInChargeID = campInCharge.CampInChargeID,
                    CampsID = campInCharge.CampsID
                };
                db.CampInCharges.Add(data);
                db.SaveChanges();

                return RedirectToAction("Index");

            }

            ViewBag.CampsID = new SelectList(db.Camps, "CampsID", "Name", campInCharge.CampsID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "LastName", campInCharge.PersonID);
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
            ViewBag.CampsID = new SelectList(db.Camps, "CampsID", "Name", campInCharge.CampsID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "LastName", campInCharge.PersonID);
            return View(campInCharge);
        }

        // POST: CampInCharges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampInChargeID,CampsID,PersonID")] CampInCharge campInCharge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campInCharge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampsID = new SelectList(db.Camps, "CampsID", "Name", campInCharge.CampsID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "LastName", campInCharge.PersonID);
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

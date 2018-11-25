using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CCApp.Models;

namespace CCApp.Controllers
{
    public class SeshesController : Controller
    {
        private CCDBEntities db = new CCDBEntities();

        // GET: Seshes
        public ActionResult Index()
        {
            var datenow = "25-Nov-18";
            var seshes = db.Seshes.Where(s => s.Date != datenow);
            return View(seshes);
        }

        public ActionResult PastSesh ()
        {
            var datenow = "25-Nov-18";
            var seshes = db.Seshes.Where(s => s.Date == datenow);
            return View(seshes);
        }

        // GET: Seshes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sesh = new DetailsViewModel();
            sesh.Seshes = db.Seshes.Find(id);
            sesh.Shouter = db.Shouts.Where(s => s.SeshToShout == id);
            if (sesh == null)
            {
                return HttpNotFound();
            }
            return View(sesh);
        }

        // GET: Seshes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seshes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeshID,Date,Time,Venue")] Sesh sesh)
        {
            if (ModelState.IsValid)
            {
                db.Seshes.Add(sesh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sesh);
        }

        // GET: Seshes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sesh sesh = db.Seshes.Find(id);
            if (sesh == null)
            {
                return HttpNotFound();
            }
            return View(sesh);
        }

        // POST: Seshes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeshID,Date,Time,Venue")] Sesh sesh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sesh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sesh);
        }

        // GET: Seshes/PastEdit/5
        public ActionResult PastEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sesh sesh = db.Seshes.Find(id);
            if (sesh == null)
            {
                return HttpNotFound();
            }
            return View(sesh);
        }

        // POST: Seshes/PastEdit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PastEdit([Bind(Include = "SeshID,Date,Time,Venue")] Sesh sesh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sesh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sesh);
        }

        // GET: Seshes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sesh sesh = db.Seshes.Find(id);
            if (sesh == null)
            {
                return HttpNotFound();
            }
            return View(sesh);
        }

        // POST: Seshes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sesh sesh = db.Seshes.Find(id);
            db.Seshes.Remove(sesh);
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

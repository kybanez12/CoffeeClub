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
    public class ShoutsController : Controller
    {
        private CCDBEntities db = new CCDBEntities();

        // GET: Shouts
        public ActionResult Index()
        {
            var shouts = db.Shouts.Include(s => s.Member).Include(s => s.Sesh);
            return View(shouts.ToList());
        }

        // GET: Shouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shout shout = db.Shouts.Find(id);
            if (shout == null)
            {
                return HttpNotFound();
            }
            return View(shout);
        }

        // GET: Shouts/Create
        public ActionResult Create()
        {
            ViewBag.Shouter = new SelectList(db.Members, "Email", "Email");
            ViewBag.SeshToShout = new SelectList(db.Seshes, "SeshID", "SeshID");
            return View();
        }

        // POST: Shouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeshToShout,Shouter,Amount")] Shout shout)
        {
            if (ModelState.IsValid)
            {
                db.Shouts.Add(shout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Shouter = new SelectList(db.Members, "Email", "Email", shout.Shouter);
            ViewBag.SeshToShout = new SelectList(db.Seshes, "SeshID", "Date", shout.SeshToShout);
            return View(shout);
        }

        // GET: Shouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shout shout = db.Shouts.Find(id);
            if (shout == null)
            {
                return HttpNotFound();
            }
            ViewBag.Shouter = new SelectList(db.Members, "Email", "Email", shout.Shouter);
            ViewBag.SeshToShout = new SelectList(db.Seshes, "SeshID", "Date", shout.SeshToShout);
            return View(shout);
        }

        // POST: Shouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SeshToShout,Shouter,Amount")] Shout shout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Shouter = new SelectList(db.Members, "Email", "Email", shout.Shouter);
            ViewBag.SeshToShout = new SelectList(db.Seshes, "SeshID", "Date", shout.SeshToShout);
            return View(shout);
        }

        // GET: Shouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shout shout = db.Shouts.Find(id);
            if (shout == null)
            {
                return HttpNotFound();
            }
            return View(shout);
        }

        // POST: Shouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shout shout = db.Shouts.Find(id);
            db.Shouts.Remove(shout);
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

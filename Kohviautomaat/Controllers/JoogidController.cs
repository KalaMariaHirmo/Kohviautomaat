using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kohviautomaat.Models;

namespace Kohviautomaat.Controllers
{
    public class JoogidController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
		public ActionResult LisaJook()
		{
			return View();
		}
		public ActionResult Haldusleht()
		{
			return View(db.Joogids.ToList());
		}
		// GET: Joogid
		public ActionResult Index()
        {
            return View(db.Joogids.ToList());
        }

        // GET: Joogid/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joogid joogid = db.Joogids.Find(id);
            if (joogid == null)
            {
                return HttpNotFound();
            }
            return View(joogid);
        }

        // GET: Joogid/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Joogid/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,jooginimi,topsepakis,topsejuua")] Joogid joogid)
        {
            if (ModelState.IsValid)
            {
                db.Joogids.Add(joogid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(joogid);
        }

        // GET: Joogid/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joogid joogid = db.Joogids.Find(id);
            if (joogid == null)
            {
                return HttpNotFound();
            }
            return View(joogid);
        }

        // POST: Joogid/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,jooginimi,topsepakis,topsejuua")] Joogid joogid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(joogid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(joogid);
        }

        // GET: Joogid/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Joogid joogid = db.Joogids.Find(id);
            if (joogid == null)
            {
                return HttpNotFound();
            }
            return View(joogid);
        }

        // POST: Joogid/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Joogid joogid = db.Joogids.Find(id);
            db.Joogids.Remove(joogid);
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

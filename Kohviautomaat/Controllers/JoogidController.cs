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
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LisaJook([Bind(Include = "id,jooginimi,topsepakis,topsejuua")] Joogid joogid)
		{
			if (ModelState.IsValid)
			{
				db.Joogids.Add(joogid);
				db.SaveChanges();
				return RedirectToAction("Haldusleht");
			}

			return View(joogid);
		}
		public ActionResult Haldusleht()
		{
			var model = db.Joogids
				.Select(u => new JoogidViewModel
				{
					id = u.id,
					jooginimi = u.jooginimi,
					topsejuua = u.topsejuua,
					topsepakis = u.topsepakis
				})
				.ToList();
				
			return View(model);
		}

		public ActionResult Taida(int id)
		{
			Joogid jook = db.Joogids.Find(id);
			if (jook == null)
			{
				return HttpNotFound();
			}
			// Kas masinas on piisavalt ruumi?
			if (jook.topsejuua <= jook.topsepakis)
			{
				jook.topsejuua += jook.topsepakis;
				db.Entry(jook).State = EntityState.Modified;
				db.SaveChanges();
			}
			else
			{
				//midagi kui masin on liiga täis
				return Content("<script language='javascript' type='text/javascript'>alert('Täitepakk ei mahu masinasse.');</script>");
			}
			return RedirectToAction("Haldusleht");
		}
		// GET: Joogid/Kustuta/5
		public ActionResult Kustuta(int? id)
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

		// POST: Joogid/Kustuta/5
		[HttpPost, ActionName("Kustuta")]
		[ValidateAntiForgeryToken]
		public ActionResult KustutaConfirmed(int id)
		{
			Joogid joogid = db.Joogids.Find(id);
			db.Joogids.Remove(joogid);
			db.SaveChanges();
			return RedirectToAction("Index");
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

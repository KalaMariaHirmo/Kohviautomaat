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

	public class HomeController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();
		public ActionResult Index()
		{
			var model = db.Joogids
				.OrderBy(u=>u.jooginimi)
				.Select(u => new JoogidJoomiseksViewModel
				{
					id = u.id,
					jooginimi = u.jooginimi,
					topsejuua = u.topsejuua
				})
				.ToList();

			return View(model);
		}
		public ActionResult tellimus(int id)
		{
			Joogid jook = db.Joogids.Find(id);
			if (jook == null)
			{
				return HttpNotFound();
			}
			// Kas masinas on piisavalt ruumi?
			if (jook.topsejuua > 0)
			{
				jook.topsejuua -= 1;
				db.Entry(jook).State = EntityState.Modified;
				db.SaveChanges();
			}
			else
			{
				//midagi kui masin on liiga täis
				return Content("<script language='javascript' type='text/javascript'>alert('Jook on otsas.');</script>");
			}
			return RedirectToAction("Index");
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}
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
				.Select(u => new JoogidJoomiseksViewModel
				{
					id = u.id,
					jooginimi = u.jooginimi,
					topsejuua = u.topsejuua
				})
				.ToList();

			return View(model);
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
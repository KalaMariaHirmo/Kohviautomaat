using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kohviautomaat.Models
{
	public class JoogidJoomiseksViewModel
	{
		public int id { get; set; }
		[Display(Name = "Joogid Nimi")]
		public string jooginimi { get; set; }
		[Display(Name = "Joogi saadavus (Topse)")]
		public int topsejuua { get; set; }
	}
}
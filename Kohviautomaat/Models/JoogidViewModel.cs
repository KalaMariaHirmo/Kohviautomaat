using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kohviautomaat.Models
{
	public class JoogidViewModel
	{
		public int id { get; set; }
		[Display(Name = "Joogid Nimi")]
		public string jooginimi { get; set; }
		[Range(0, 1000000)]
		[Display(Name = "Topse Pakis")]
		public int topsepakis { get; set; }
		[Display(Name = "Topse Juua")]
		public int topsejuua { get; set; } = 0;
	}
}
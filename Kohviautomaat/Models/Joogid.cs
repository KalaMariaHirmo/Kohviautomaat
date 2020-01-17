using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kohviautomaat.Models
{
	public class Joogid
	{
		public int id { get; set; }
		public string jooginimi { get; set; }
		[Range(0, 1000000)]
		public int topsepakis { get; set; }
		public int topsejuua { get; set; } = 0;
	}
}
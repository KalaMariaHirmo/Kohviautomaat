using System;
using System.Collections.Generic;
using Kohviautomaat.Controllers;
using Kohviautomaat.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kohvimasin.Tests.Features
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestJoogidViewModel()
		{
			JoogidViewModel viewModel = new JoogidViewModel();
			viewModel.id = 1;
			viewModel.jooginimi = "test";
			viewModel.topsepakis = 1337;

			Assert.AreEqual(1, viewModel.id);
			Assert.AreEqual("test", viewModel.jooginimi);
			Assert.AreEqual(1337, viewModel.topsepakis);
			Assert.AreEqual(0, viewModel.topsejuua);
		}
	}
}

using CoderBrain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoderBrain.Models;

namespace CoderBrain.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ISpaceXData _spaceXDataManager;

		public HomeController(ILogger<HomeController> logger, ISpaceXData spaceXDataManager)
		{
			_logger = logger;
			_spaceXDataManager = spaceXDataManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<JsonResult> GetSpaceXData(int pageSize=100,bool? launchSuccess=true,bool? landSuccess=false,int? launchYear=2014,bool isFilterRequest=false)
		{
			List<SpaceXdata> spaceXData = null;
			spaceXData = await _spaceXDataManager.GetData(pageSize, launchSuccess, landSuccess, launchYear, isFilterRequest);
			return Json(spaceXData);

		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

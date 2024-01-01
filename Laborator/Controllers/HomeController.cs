using Laborator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Laborator.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

		
		//public string Text { get; set; }

		public IActionResult Index()
		{
			ViewData["Text"] = "Ювелирные украшения";
			//ViewData["Lst"] = new SelectList(_listDemo, "ListItemValue", "ListItemText");
			return View();
		}

		//public class ListDemo
		//{
		//	public int ListItemValue { get; set; }
		//	public string ListItemText { get; set; }
		//}

		//public List<ListDemo> _listDemo;

		//public HomeController()
		//{
		//	_listDemo = new List<ListDemo>
		//	{
		//		new ListDemo{ ListItemValue=1, ListItemText="Item 1"},
		//		new ListDemo{ ListItemValue=2, ListItemText="Item 2"},
		//		new ListDemo{ ListItemValue=3, ListItemText="Item 3"}
				
		//	};
		//}



		//public IActionResult Privacy()
		//{
		//    return View();
		//}

		//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		//public IActionResult Error()
		//{
		//    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		//}
	}
}
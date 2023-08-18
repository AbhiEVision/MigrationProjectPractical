using Microsoft.AspNetCore.Mvc;

namespace AdminPanelTutorial
{

	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
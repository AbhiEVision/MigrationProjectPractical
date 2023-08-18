using CRUD_Operations.ModelsMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operations.Controllers
{

	[Microsoft.AspNetCore.Components.Route("{controller=Nurses}/{action}")]
	public class NursesController : Controller
	{
		private readonly AppDbContext db;

		public NursesController(AppDbContext dbContext)
		{
			db = dbContext;
		}

		public async Task<ActionResult> Index()
		{
			return View(await db.Nurses.ToListAsync());
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateNurse(Nurses nurse)
		{
			db.Nurses.Add(nurse);
			db.SaveChanges();
			return RedirectToAction("Index", "Nurses");
		}

		[HttpPost]
		public async Task<bool> Delete(int id)
		{
			try
			{
				Nurses nurse = await db.Nurses.Where(s => s.Id == id).FirstOrDefaultAsync();
				db.Nurses.Remove(nurse);
				await db.SaveChangesAsync();
				return true;
			}
			catch (System.Exception)
			{
				return false;
			}

		}

		public ActionResult Update(int id)
		{
			return View(db.Nurses.Where(s => s.Id == id).First());
		}

		[HttpPost]
		public ActionResult UpdateNurse(Nurses nurse)
		{
			Nurses d = db.Nurses.Where(s => s.Id == nurse.Id).First();
			d.Name = nurse.Name;
			d.Phone = nurse.Phone;

			db.SaveChanges();
			return RedirectToAction("Index", "Nurses");
		}
	}
}

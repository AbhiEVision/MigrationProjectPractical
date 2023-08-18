using CRUD_Operations.ModelsMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminPanelTutorial
{

	public class DoctorsController : Controller
	{
		private readonly AppDbContext db;

		public DoctorsController(AppDbContext db)
		{
			this.db = db;
		}

		public async Task<ActionResult> Index()
		{
			return View(await db.Doctors.ToListAsync());
		}
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateDoctor(Doctors doctor)
		{

			db.Doctors.Add(doctor);
			db.SaveChanges();
			return RedirectToAction("Index", "Doctors");
		}

		[HttpPost]
		public async Task<bool> Delete(int id)
		{
			try
			{
				Doctors doctor = await db.Doctors.Where(s => s.Id == id).FirstOrDefaultAsync();
				db.Doctors.Remove(doctor);
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
			return View(db.Doctors.Where(s => s.Id == id).First());
		}

		[HttpPost]
		public ActionResult UpdateDoctor(Doctors doctor)
		{
			Doctors d = db.Doctors.Where(s => s.Id == doctor.Id).First();
			d.Name = doctor.Name;
			d.Phone = doctor.Phone;
			d.Specialist = doctor.Specialist;
			db.SaveChanges();
			return RedirectToAction("Index", "Doctors");
		}
	}
}
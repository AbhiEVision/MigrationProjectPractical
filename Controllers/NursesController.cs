﻿using CRUD_Operations.ModelsMS;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUD_Operations.Controllers
{
    public class NursesController : Controller
    {
        AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return View(db.Nurses.ToList());
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
        public bool Delete(int id)
        {
            try
            {
                Nurses nurse = db.Nurses.Where(s => s.Id == id).First();
                db.Nurses.Remove(nurse);
                db.SaveChanges();
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

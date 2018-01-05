using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorldTravelBlog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorldTravelBlog.Controllers
{
    public class ExperiencesController : Controller
    {
        // GET: /<controller>/
        private WorldTravelBlogContext db = new WorldTravelBlogContext();
        public IActionResult Index()
        {
            return View(db.Experiences.ToList());
        }

		public IActionResult Details(int id)
		{
            var thisExperience = db.Experiences.Include(x=>x.Location).FirstOrDefault(names => names.ExperienceId == id);
			return View(thisExperience);
		}

		public IActionResult Create()
		{
			ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name", "Description"); 
            return View();
		}

		[HttpPost]
		public IActionResult Create(Experience item)
		{
			db.Experiences.Add(item);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			var thisExperience = db.Experiences.FirstOrDefault(names => names.ExperienceId == id);
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name", "Description");
			return View(thisExperience);
		}

		[HttpPost]
		public IActionResult Edit(Experience doggy)
		{
			db.Entry(doggy).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var thisExperience = db.Experiences.FirstOrDefault(names => names.ExperienceId == id);
			return View(thisExperience);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var thisExperience = db.Experiences.FirstOrDefault(names => names.ExperienceId == id);
			db.Experiences.Remove(thisExperience);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
    }
}

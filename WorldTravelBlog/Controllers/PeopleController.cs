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
    public class PeopleController : Controller
    {
		// GET: /<controller>/
		private WorldTravelBlogContext db = new WorldTravelBlogContext();

		public IActionResult Index()
        {
            return View(db.People.ToList());
        }
		public IActionResult Details(int id)
		{
			Person thisPerson = db.People.FirstOrDefault(names => names.PersonId == id);
			return View(thisPerson);
		}

		public IActionResult Create()
		{
			ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name", "Description"); 
            ViewBag.ExperienceId = new SelectList(db.Experiences, "ExperienceId", "Name", "Description");
			return View();
		}

		[HttpPost]
		public IActionResult Create(Person name)
		{
			db.People.Add(name);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			var thisPerson = db.People.FirstOrDefault(names => names.PersonId == id);
			return View(thisPerson);
		}

		[HttpPost]
		public IActionResult Edit(Person person)
		{
			db.Entry(person).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var thisPerson = db.People.FirstOrDefault(names => names.PersonId == id);
			return View(thisPerson);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var thisPerson = db.People.FirstOrDefault(names => names.PersonId == id);
			db.People.Remove(thisPerson);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
    }
}

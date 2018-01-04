using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorldTravelBlog.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorldTravelBlog.Controllers
{
    public class LocationsController : Controller
    {
        // GET: /<controller>/
        private WorldTravelBlogContext db = new WorldTravelBlogContext(); 

        public IActionResult Index()
        {
            return View(db.Locations.ToList());
        }

		public IActionResult Details(int id)
		{
			Location thisLocation = db.Locations.FirstOrDefault(names => names.LocationId == id);
			return View(thisLocation);
		}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create (Location name)
        {
            db.Locations.Add(name);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

		public IActionResult Edit(int id)
		{
			var thisLocation = db.Locations.FirstOrDefault(names => names.LocationId == id);
			return View(thisLocation);
		}

		[HttpPost]
		public IActionResult Edit(Location location)
		{
			db.Entry(location).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var thisLocation = db.Locations.FirstOrDefault(names => names.LocationId == id);
			return View(thisLocation);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var thisLocation = db.Locations.FirstOrDefault(names => names.LocationId == id);
			db.Locations.Remove(thisLocation);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
    }
}

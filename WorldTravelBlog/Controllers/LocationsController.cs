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
            ViewBag.LocationId = new SelectList(db.Locations, "LocationId", "Name", "Description"); 
            return View();
        }

        public IActionResult Create (Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

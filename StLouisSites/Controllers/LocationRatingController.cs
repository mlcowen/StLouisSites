using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StLouisSites.Data;
using Microsoft.AspNetCore.Mvc;

namespace StLouisSites.Controllers
{
    public class LocationRatingController : Controller
    {
        private ApplicationDbContext context;

        public LocationRatingController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Location> locations = context.Locations.ToList();
            return View(locations);
        }

        [HttpGet]
        public IActionResult Create(int locationId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int locationId, LocationRatingCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Persist(context);
            return RedirectToAction(controllerName: "Location", actionName: "Index");
        }
    }
}

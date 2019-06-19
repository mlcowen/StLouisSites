using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StLouisSites.Data;
using Microsoft.AspNetCore.Mvc;
using StLouisSites.Models;

namespace StLouisSites.Controllers
{
    public class LocationReviewController : Controller
    {
        private ApplicationDbContext context;

        public LocationReviewController(ApplicationDbContext context)
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

        //    [HttpPost]
        //    public IActionResult Create(int locationId, LocationReviewCreateViewModel model)
        //    {
        //        if (!ModelState.IsValid)
        //            return View(model);

        //        model.Persist(context);
        //        return RedirectToAction(controllerName: "Location", actionName: "Index");
        //    }
    }
}

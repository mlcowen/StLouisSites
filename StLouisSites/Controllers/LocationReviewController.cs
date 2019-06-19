using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StLouisSites.Data;
using Microsoft.AspNetCore.Mvc;
using StLouisSites.Models;
using StLouisSites.ViewModels.LocationReviews;

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
            List<LocationReview> locationReviews = context.LocationReviews.ToList();
            return View(locationReviews);
        }

        [HttpGet]
        public IActionResult Create(int LocationId)
        {
            Location locationResult = context.Locations.Where(a => a.Id == LocationId).Single();
            ViewBag.locationName =  locationResult.Name;

            return View();
        }

        [HttpPost]
        public IActionResult Create(int LocationId, LocationReviewCreateViewModel model)
        { 
       
            model.Persist(context);
            return RedirectToAction(controllerName: "Location", actionName: "Index");
        }
    }
}

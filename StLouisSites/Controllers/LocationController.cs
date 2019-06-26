using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StLouisSites.Data;
using StLouisSites.Models;
using StLouisSites.ViewModels.Locations;

namespace StLouisSites.Controllers
{
    public class LocationController : Controller
    {
        private ApplicationDbContext context;

        public LocationController(ApplicationDbContext context)
        {
            this.context = context;
        }
           

        public IActionResult Index()
        {
            //List<Location> locations = context.Locations.ToList();
            // where tells the query to get the row that matches the id of the location. This pulls data from the locationReview table 
            //List<Location> locations = context.Locations.Include(a => a.LocationReviews).ToList();
           
            List<LocationListItemViewModel> locations = LocationListItemViewModel.GetLocations(context);

            return View(locations);
        }

        [HttpGet]
        public IActionResult Create()
        {   
            return View();
        }


        ////[HttpPost]
        ////public IActionResult Create(Location location)
        ////{

        ////    context.Add(location);
        ////    context.SaveChanges();
        ////    //If you add and don't save changes, then it won't save to the database. 
        ////    return RedirectToAction(nameof(Index));
        ////}

  
        // copied from the locationReviewController to make viewing here easier. delete thise code
        [HttpPost]
        public IActionResult Create(int Id, LocationCreateViewModel model)
        {
           model.Persist(context);
           return RedirectToAction(controllerName: "Location", actionName: "Index");
        }



        [HttpGet]
        public IActionResult Details(int id)
        {
            // context is the variable name for ApplicationDbContext. Locations is the table in the database
            // where tells the query to get the row that matches the id of the location. This line grabs the location detail information
            // .include tells the query to grab the related reviews for this location from the locationReviews table. This line grabs each review for a location 
            IList<Location> locations = context.Locations.Where(a => a.Id == id).Include(a => a.LocationReviews).ToList();
            return View(locations);
        }



    }
}
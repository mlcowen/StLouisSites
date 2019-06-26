using StLouisSites.Data;
using StLouisSites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StLouisSites.ViewModels.Locations
{
    public class LocationListItemViewModel
    {
        // Declare properties of the LocationListItemViewModel, just like we do in a class
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HoursOfOperation { get; set; }
        public string Address { get; set; }
        public List<LocationReview> LocationReviews { get; set; }
        public double AverageRating { get; set; }


        //method to get locations. This is called in the controller to pass the data to the view
        public static List<LocationListItemViewModel> GetLocations(ApplicationDbContext context)
        {
            // first we have to query the db to get a list of locations. we save this to a list
            // the .Include() method ensures it pulls the associated reviews from the locationReviews table
            IList<Location> locations = context.Locations.Include(a => a.LocationReviews).ToList();


            //declare a new list. This will be used in our foreach loop to hold each individual instance of a location 
            //we add data to this list at the end of our foreach loop 
            List<LocationListItemViewModel> viewDataList = new List<LocationListItemViewModel>();

            // we need to iterate over the list we queried from the DB. Then print each row (location) to the view
            foreach (Location location in locations)
            {
                //every time we loop through we create a new instance of the locationListItemViewModel. 
                //look up recursion to get an explanation of how this works
                LocationListItemViewModel thisSpecificLocation = new LocationListItemViewModel();

                thisSpecificLocation.Id = location.Id;
                thisSpecificLocation.Name = location.Name;
                thisSpecificLocation.Description = location.Description;
                thisSpecificLocation.HoursOfOperation = location.HoursOfOperation;
                thisSpecificLocation.Address = location.Address;
                thisSpecificLocation.LocationReviews = location.LocationReviews;

                if(location.LocationReviews.Count > 0)
                {
                    //if we have reviews we want to calculate the average rating
                    thisSpecificLocation.AverageRating = Math.Round(location.LocationReviews.Average(x => x.Rating), 2);
                } else
                {
                    //if there are no ratings, just set the average rating to 0. The else statement in the view will prevent 0 from showing.
                    thisSpecificLocation.AverageRating = 0;
                }
                
                //push our new instance of the class into our placeholder (viewData) list
                viewDataList.Add(thisSpecificLocation);
            }
            return viewDataList;
        }

    }
}

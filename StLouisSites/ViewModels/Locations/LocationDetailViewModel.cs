﻿using StLouisSites.Data;
using StLouisSites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.ViewModels.Locations
{
    public class LocationDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HoursOfOperation { get; set; }
        public List<LocationReview> LocationReviews { get; set; }


        // we need to get a list of the actively checked IDs for each location when we edit.
        // so we declare a list propety up that we can populate later
        public List<CategoryLocation> ActiveCategoryIds { get; set; }

        // we also need to get a list of all categories
        // so we declare a list propety up that we can populate later
        public List<Category> Categories { get; set; }


        public LocationDetailViewModel() { }


        public LocationDetailViewModel(int Id, ApplicationDbContext context)
        {
            Location location = context.Locations.Find(Id);
            this.Id = location.Id;
            this.Name = location.Name;
            this.Description = location.Description;
            this.HoursOfOperation = location.HoursOfOperation;
            this.LocationReviews = context.LocationReviews.Where(a => a.LocationId == Id).ToList();

           // this.Categories = context.Categories.ToList();

            // populate our placeholder list of activeCategoryId. we query the categorylocations table for categories that contain this locationId
            this.ActiveCategoryIds = context.CategoryLocations.Where(a => a.LocationId == Id).ToList();

            // we then need to convert the ActiveCategoryIds to a type of list<int> we do that with this for loop. 
            // note: this is messy and we can probably do this some other way with less code and less converting from one type to another. 
            List<Category> CategoriesList = new List<Category>();
            foreach (var category in ActiveCategoryIds)
            {
                Category thisSpecificCategory = new Category();

                thisSpecificCategory.Id = category.CategoryId;
                thisSpecificCategory.Name = context.Categories.Where(a => a.Id == category.CategoryId).Select(a => a.Name).Single();

                CategoriesList.Add(thisSpecificCategory); // push this value into our categorylist list above our foreach loop
            }

            //finally..... we can set the forms CategoryIds element to this CategoriesList as it's now the right type (int)
            this.Categories = CategoriesList;

        }

    }
}

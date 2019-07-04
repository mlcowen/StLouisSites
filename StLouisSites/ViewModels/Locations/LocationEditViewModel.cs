using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StLouisSites.Data;
using StLouisSites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StLouisSites.ViewModels.Locations

{
    public class LocationEditViewModel
    {
        public int LocationId { get; set; }

        [Required]
        public string Name { get; set; }

        // we need to get a list of the actively checked IDs for each location when we edit.
        // so we declare a list propety up that we can populate later
        public List<CategoryLocation> ActiveCategoryIds { get; set; }

        // we also need to get a list of all categories
        // so we declare a list propety up that we can populate later
        public List<Category> Categories { get; set; }

        // we will need this place holder list to push content into after we convert our activecategoryIds list to the right type (int)
        public List<int> CategoryIds { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Description { get; set; }
        public string HoursOfOperation { get; set; }
        public string Address { get; set; }

        [Required]
        public string Region { get; set; }

        public LocationEditViewModel() { }

        public LocationEditViewModel(int LocationId, ApplicationDbContext context)
        {
            // populate the form values with data we can easily pull from the database
            Location location = context.Locations.Find(LocationId);
            this.Name = location.Name;
            this.Description = location.Description;
            this.HoursOfOperation = location.HoursOfOperation;
            this.Address = location.Address;
            this.Region = location.Region;
            this.Categories = context.Categories.ToList();

            // populate our placeholder list of activeCategoryId. we query the categorylocations table for categories that contain this locationId
            this.ActiveCategoryIds = context.CategoryLocations.Where(a => a.LocationId == LocationId).ToList();

            // we then need to convert the ActiveCategoryIds to a type of list<int> we do that with this for loop. 
            // note: this is messy and we can probably do this some other way with less code and less converting from one type to another. 
            List<int> CategoriesList = new List<int>();
            foreach (var category in ActiveCategoryIds)
            {
                CategoriesList.Add(category.CategoryId); // push this value into our categorylist list above our foreach loop
            }

            //finally..... we can set the forms CategoryIds element to this CategoriesList as it's now the right type (int)
            this.CategoryIds = CategoriesList;

        }

        public void Persist(int LocationId, ApplicationDbContext context)
        {
            Models.Location location = new Models.Location
            {
                Id = LocationId,
                Name = this.Name,
                Description = this.Description,
                HoursOfOperation = this.HoursOfOperation,
                Address = this.Address,
                Region = this.Region
            };
            context.Update(location);

            List<CategoryLocation> categoryLocations = CreateManyToManyRelationships(location.Id);
            location.CategoryLocations = categoryLocations;
            context.SaveChanges();
        }

        private List<CategoryLocation> CreateManyToManyRelationships(int locationId)
        {
            return CategoryIds.Select(catId => new CategoryLocation { LocationId = locationId, CategoryId = catId }).ToList();
        }

        internal void ResetCategoryList(ApplicationDbContext context)
        {
            this.Categories = context.Categories.ToList();
        }
    }
}


using StLouisSites.Data;
using StLouisSites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StLouisSites.ViewModels.Locations
{
    public class LocationCreateViewModel
    {
      
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Description { get; set; }
        public string HoursOfOperation { get; set; }
        public string Address { get; set; }

        [Display(Name="Select one or more categories.")]
        public List<int> CategoryIds { get; set; }
        public List<Category> Categories { get; set; }

        [Required]
        public string Region { get; set; }

        public LocationCreateViewModel() { }

        public LocationCreateViewModel(ApplicationDbContext context)
        {
            //OrderBy(s=>s.name)tells our code to alphabetize results by the name
            this.Categories = context.Categories.OrderBy(s =>s.Name).ToList();
        }

        public void Persist(ApplicationDbContext context)
        {
            Models.Location location = new Models.Location
            {
                Name = this.Name,
                Description = this.Description,
                HoursOfOperation = this.HoursOfOperation,
                Address = this.Address,
                Region = this.Region
                //CategoryId = this.CategoryIds,
                //Categories = this.Categories,
            };
            context.Locations.Add(location);
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

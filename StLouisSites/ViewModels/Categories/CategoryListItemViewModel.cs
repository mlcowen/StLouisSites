﻿using StLouisSites.Data;
using StLouisSites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.ViewModels.Categories
{
    public class CategoryListItemViewModel
    {
        //[HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }

        //public List<CategoryLocation> CategoryLocations { get; set; }

        ////method to get locations. This is called in the controller to pass the data to the view
        public static List<CategoryListItemViewModel> GetCategories(ApplicationDbContext context)
        {
            IList<Category> categories = context.Categories.ToList();


            //declare a new list. This will be used in our foreach loop to hold each individual instance of a category 
            //we add data to this list at the end of our foreach loop 
            List<CategoryListItemViewModel> viewCategoryList = new List<CategoryListItemViewModel>();

            foreach (Category category in categories)
            {
                CategoryListItemViewModel thisSpecificCategory = new CategoryListItemViewModel();

                thisSpecificCategory.Id = category.Id;
                thisSpecificCategory.Name = category.Name;

                //push our new instance of the class into our placeholder (viewCategoryList) list
                viewCategoryList.Add(thisSpecificCategory);

            }

            return viewCategoryList;
        }

    }
}

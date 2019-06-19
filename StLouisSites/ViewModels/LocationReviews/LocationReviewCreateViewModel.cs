using StLouisSites.Data;
using StLouisSites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisSites.ViewModels.LocationReviews
{
    public class LocationReviewCreateViewModel
    {
        public int LocationId { get; set; }
        public string ReviewHeadline { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }


        internal void Persist(ApplicationDbContext context)
        {
            LocationReview review = new LocationReview
            {
                LocationId = this.LocationId,
                ReviewHeadline = this.ReviewHeadline,
                Rating = this.Rating,
                Review = this.Review
            };

            context.Add(review);
            context.SaveChanges();
        }
    }
}

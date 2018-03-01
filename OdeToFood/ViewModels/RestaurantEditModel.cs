using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewModels
{
    /// <summary>
    /// To thwart overposting, we create a viewmodel that is comprised of all of the items on the form
    /// that should map to the model for the httppost
    /// </summary>
    public class RestaurantEditModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType  Cuisine { get; set; }

    }
}

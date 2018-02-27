using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {

            var model = _restaurantData.GetAll();
            
            //ObjectResult is a way a deferring what type of result you want later. In this case, we'll get a jsonresult.
            //return new ObjectResult(model);

            return View(model);
        }
    }
}

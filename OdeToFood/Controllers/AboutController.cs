
using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    //attributes can be applied at controller or action level
    //alternatively you can use [Route("[controller]")] and the routing would use the word in front of controller (in this case, about in about controller).
    [Route("about")]
    public class AboutController
    {
        //here, if mvc sees anything like /about without anything behind it it will assume to go here because of the blank attribute.
        [Route("")]
        public string Phone()
        {
            return "1+555+555+5555";
        }
        //Just like the [Route("[controller")] attribute, the same can be applied to an action.
        [Route("[action]")]
        public string Address()
        { return "USA"; }

    }
}

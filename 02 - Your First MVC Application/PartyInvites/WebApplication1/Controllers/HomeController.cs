using System;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Controllers {
    public class HomeController : Controller {

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger) {
        //    _logger = logger;
        //}

        public ViewResult Index() {
            ViewBag.Greeting = DateTime.Now.Hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }
        
        [HttpGet]
        public ViewResult RsvpForm() {
            return View();
        }


        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse) {
            if (ModelState.IsValid) {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            } else {
                // there is a validation error
                return View();
            }
        }

        public ViewResult ListResponses() {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }

        //public IActionResult Privacy() {
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error() {
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}

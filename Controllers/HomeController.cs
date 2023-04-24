using FoodOrder.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodOrder.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration Configuration;
        public HomeController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        private readonly ILogger<HomeController> _logger;

         HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index(SEC_UserModel modelSEC_UserModel)
        {

            if (modelSEC_UserModel.UserName.Equals("admin") && modelSEC_UserModel.Password.Equals("admin"))
            {
                return RedirectToAction("Homee");
            }
            else
            {

                return RedirectToAction("Index", "Payment", new { area = "Payment" });
                //return View("HomeClient");
            }
        }
        public IActionResult Index_food(SEC_UserModel modelSEC_UserModel)
        {

            if (modelSEC_UserModel.UserName.Equals("admin") && modelSEC_UserModel.Password.Equals("admin"))
            {
                return RedirectToAction("Homee");
            }
            else
            {

                return RedirectToAction("Index", "Food", new { area = "Food" });
                //return View("HomeClient");
            }
        }

        public IActionResult Homee()
        {

            return View("Home");

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment1.Models;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SportingContext context { get; set; }

        public HomeController(Microsoft.Extensions.Logging.ILogger<HomeController> logger, SportingContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Product()
        {
            ViewData["Message"] = "product page";
            return View();
        }

        public IActionResult Technician()
        {
            ViewData["Message"] = "Technician page";
            return View();
        }

        public IActionResult Registration()
        {
            ViewData["Message"] = "Registration page";
            return View();
        }

        public IActionResult Incidents()
        {
            ViewData["Message"] = "Incidents page";
            return View();
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

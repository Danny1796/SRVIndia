using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRVIndia.Models;

namespace SRVIndia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        // POST: Enquiries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveEnquiry(Enquiries enquiry)
        {
            if (ModelState.IsValid)
            {
                // 1. Add the object to the context
                _context.Add(enquiry);

                // 2. Push changes to the SQL Database
                await _context.SaveChangesAsync();

                // Redirect to a 'Success' page or Home
                return RedirectToAction("Index", "Home");
            }

            // If validation fails, return the user to the form with their data
            return View("ContactUs");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

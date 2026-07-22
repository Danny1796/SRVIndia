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

        public IActionResult CookiePolicy()
        {
            return View();
        }

        public IActionResult Term_Condition()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }
        public IActionResult UltraGuard()
        {
            return View();
        }
        public IActionResult UV()
        {
            return View();
        }

        public IActionResult AirGuard()
        {
            return View();
        }

        public IActionResult Hydrogelfilm()
        {
            return View();
        }

        public IActionResult Kinetic()
        {
            return View();
        }

        public IActionResult Antislippad()
        {
            return View();
        }

        public IActionResult Hydrogelfilmclear()
        {
            return View();
        }

        public IActionResult Cameralens()
        {
            return View();
        }
        public IActionResult Coming_soon()
        {
            return View();
        }

        public IActionResult MagicGuard()
        {
            return View();
        }

        
        public IActionResult IProtect()
        {
            return View();

        }
        public IActionResult IpcaMEraLense()
        {
            return View();

        }
        public IActionResult HD_Clear()
        {
            return View();

        }
        public IActionResult HDPrivacy()
        {
            return View();

        }
        public IActionResult HHDClear()
        {
            return View();

        }
        public IActionResult MattPrivacy()
        {
            return View();

        }
        public IActionResult HMatt()
        {
            return View();

        }
        public IActionResult NanoMatt()
        {
            return View();

        }
        public IActionResult PrivacyGuard()
        {
            return View();

        }
        public IActionResult OriginalLether()
        {
            return View();

        }
        public IActionResult News_Letter()
        {
            return View();
        }
        // GET: Distributor Form
        public IActionResult DistributorForm()
        {
            return View();
        }

        // POST: Save Distributor Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DistributorForm(Distributor distributor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(distributor);   // ✅ Save to DB
                await _context.SaveChangesAsync();

                ViewBag.Message = "Distributor Form Submitted Successfully!";
                return View(); // stay on same page
            }

            return View(distributor);
        }

        public IActionResult Culture()
        {
            return View();
        }
        public IActionResult Whysrv()
        {
            return View();
        }
        public IActionResult News()
        {
            return View();
        }
        public IActionResult Videos()
        {
            return View();
        }
        public IActionResult Whowe()
        {
            return View();
        }
        public IActionResult Mission()
        {
            return View();
        }
        public IActionResult Machine()
        {
            return View();
        }
        public IActionResult EWaste()
        {
            return View();
        }
        public IActionResult Warranty()
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
                enquiry.IsReply = false; // Default value for new enquiries
                enquiry.CreatedAt = DateTime.Now;
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

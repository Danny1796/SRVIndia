using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SRVIndia.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Fetches all enquiries from the database asynchronously
            var enquiries = _context.Enquiries.ToList();
            return View(enquiries);
        }
        // GET: Enquiries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enquiry = await _context.Enquiries
                .FirstOrDefaultAsync(m => m.Id == id);

            if (enquiry == null)
            {
                return NotFound();
            }

            return View(enquiry);
        }
    }
}

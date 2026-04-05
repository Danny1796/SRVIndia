using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SRVIndia.Models;

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

        // RIGHT
        public IActionResult UploadBanners()
        {
            // Send a new, empty single object for the form to bind to
            return View(new MainBanners());
        }
        
        // POST: Admin/UploadBanners
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadBanners(MainBanners model, IFormFile bannerFile)
        {
            if (bannerFile != null && bannerFile.Length > 0)
            {
                // 1. Define the folder path (wwwroot/images/banners)
                string uploadDir = Path.Combine(_environment.WebRootPath, "images/banners");
                if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);

                // 2. Create a unique filename
                string fileName = Guid.NewGuid().ToString() + "-" + bannerFile.FileName;
                string filePath = Path.Combine(uploadDir, fileName);

                // 3. Save the file to the server
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await bannerFile.CopyToAsync(fileStream);
                }

                // 4. Save the relative path to the database
                model.BannerImage = "/images/banners/" + fileName;
                model.CreatedAt = DateTime.Now;
                model.CreatedBy = User.Identity?.Name ?? "Admin";

                _context.MainBanners.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index"); // Redirect to a list view
            }

            return View(model);
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BHRUGEN_MVC.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using BHRUGEN_MVC.Data;
using Microsoft.AspNetCore.Hosting;

namespace BHRUGEN_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger,
                ApplicationDbContext context,
                IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ShowProfile()
        {
            var items = _context.Profiles.ToList();
            return View(items);
        }




        [HttpPost]
        public async Task<IActionResult> Create(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string stringFileName = UploadFile(model);
            var profile = new Profile
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                Email = model.Email,
                Message = model.Message,
                DisplayPicture = stringFileName
            };
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return RedirectToAction("ShowProfile");
        }

        private string UploadFile(ProfileViewModel model)
        {
            string fileName = null;
            if (model.DisplayPicture != null)
            {
                string upLoadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff")+"-"+model.DisplayPicture.FileName;
                string filePath = Path.Combine(upLoadDir, fileName);
                using (var fileStream = new FileStream(filePath,FileMode.Create))
                {
                    model.DisplayPicture.CopyToAsync(fileStream);
                }
            }
            return fileName;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

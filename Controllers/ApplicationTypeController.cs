using System.Collections.Generic;
using BHRUGEN_MVC.Data;
using BHRUGEN_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BHRUGEN_MVC.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _context.ApplicationType;
            
            return View(objList);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

         // POST - CREATE
         [HttpPost]
         [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType applicationType)
        {
            _context.ApplicationType.Add(applicationType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
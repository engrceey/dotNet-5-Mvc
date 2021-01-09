using System.Collections.Generic;
using BHRUGEN_MVC.Data;
using BHRUGEN_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BHRUGEN_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _context.Category;
            
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
        public IActionResult Create(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
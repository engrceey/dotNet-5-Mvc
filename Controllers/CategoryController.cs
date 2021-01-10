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
            if(ModelState.IsValid)
            {
                 _context.Category.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);  
        }

        // Get - Edit
        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = _context.Category.Find(Id);
            
            if(category == null)
            {
               return  NotFound();
            }

            return View(category);
        }

        [HttpPost]
         [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                 _context.Category.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);  
        }

        public IActionResult Delete(int Id)
        {
            return View();
        }
    }
}
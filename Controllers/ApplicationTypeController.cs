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
            if (ModelState.IsValid)
            {
                _context.ApplicationType.Add(applicationType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationType);
        }

        // Get - Edit
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var applicationType = _context.ApplicationType.Find(Id);

            if (applicationType == null)
            {
                return NotFound();
            }

            return View(applicationType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType applicationType)
        {
            if (ModelState.IsValid)
            {
                _context.ApplicationType.Update(applicationType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationType);
        }

        // Get - Edit
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var applicationType = _context.ApplicationType.Find(Id);

            if (applicationType == null)
            {
                return NotFound();
            }

            return View(applicationType);
        }

        // Delete - Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var applicationType = _context.ApplicationType.Find(Id);
            if (applicationType == null)
            {
                return NotFound();
            }
            _context.ApplicationType.Remove(applicationType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
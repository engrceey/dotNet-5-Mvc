using Microsoft.AspNetCore.Mvc;

namespace BHRUGEN_MVC.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
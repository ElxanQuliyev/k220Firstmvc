using Microsoft.AspNetCore.Mvc;

namespace k220Firstmvc.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

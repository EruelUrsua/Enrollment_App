using Microsoft.AspNetCore.Mvc;

namespace Enrollment.App.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

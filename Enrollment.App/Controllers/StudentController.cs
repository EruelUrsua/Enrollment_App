using Enrollment.Datamodel;
using Enrollment.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Enrollment.App.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext context;
        public StudentController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add() {

            return View(new Student());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Add(Student model)
        {
            context.Add<Student>(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

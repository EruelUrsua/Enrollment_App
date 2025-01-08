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
            return View(context.Students.OrderByDescending(o => o.Lastname).ToList());
        }

        public IActionResult Add()
        {

            return View(new Student());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

         public async Task<IActionResult> Add(Student model)
        {
            await context.AddAsync(model);
            //context.Set<Student>().Add(model);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var student =  await context.Students.FindAsync(id);
            context.Set<Student>().Remove(student);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var student = await context.Students.FindAsync(id);

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Student model)
        {
            context.Set<Student>().Update(model);
           // context.Update(model);
            await context.SaveChangesAsync();
            return RedirectToAction("Index"); 
        }


    }
}

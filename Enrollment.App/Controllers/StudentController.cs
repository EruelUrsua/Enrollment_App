using AutoMapper;
using Enrollment.App.Models;
using Enrollment.Datamodel;
using Enrollment.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Enrollment.App.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext context;

        private readonly IMapper mapper;

        public StudentController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            List<StudentVM> list = mapper.Map<List<StudentVM>>(context.Students.ToList());
            return View(list);
        }

        public IActionResult Add()
        {

            return View(new StudentVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

         public async Task<IActionResult> Add(StudentVM model)
        {
            Student entity = mapper.Map<Student>(model);
            //entity.Id = model.Id;
            //entity.Lastname = model.Lastname;
            //entity.Firstname = model.Firstname;

            if (ModelState.IsValid == true)
            {
                await context.AddAsync(mapper.Map<Student>(model));
                //context.Set<Student>().Add(model);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            { 
                return View(model);
            }
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

            StudentVM student = mapper.Map<StudentVM>(await context.Students.FindAsync(id));

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(StudentVM model)
        {
            if (ModelState.IsValid == true)
            {
                context.Set<Student>().Update(mapper.Map<Student>(model));
                // context.Update(model);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else { 
                return View(model);
            }
        }


    }
}

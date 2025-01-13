using AutoMapper;
using Enrollment.App.Models;
using Enrollment.App.Models.Repositories;
using Enrollment.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Enrollment.App.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepo repo;
        private readonly IMapper mapper;
        public TeacherController(ITeacherRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task <IActionResult> Index()
        {
            return View(mapper.Map<List<TeacherVM>>(await repo.GetAllAsync()));
        }

        public IActionResult Add() { 
        
            return View(new TeacherVM());
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TeacherVM model)
        {
            if (ModelState.IsValid)
            {
                await repo.AddAsync(mapper.Map<Teacher>(model));

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
        
          await repo.DeleteAsync(id);

                return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            TeacherVM teacher = mapper.Map<TeacherVM>(await repo.GetAsync((int)id));

            return View(teacher);
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeacherVM model)
        {
            if (ModelState.IsValid)
            {

                await repo.UpdateAsync(mapper.Map<Teacher>(model));

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        
        }

    }
}

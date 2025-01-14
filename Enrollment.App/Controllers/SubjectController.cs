using AutoMapper;
using Enrollment.App.Models;
using Enrollment.App.Models.Repositories;
using Enrollment.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enrollment.App.Controllers
{
    [Authorize]
    public class SubjectController : Controller
    {
        private readonly ISubjectRepo repo;
        private readonly IMapper mapper;
        public SubjectController(ISubjectRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        // GET: SubjectController
        public async Task<ActionResult> Index()
        {
            List<SubjectVM> list = mapper.Map<List<SubjectVM>>(await repo.GetAllAsync());
            return View(list);
        }
  
        public IActionResult Add()
        {

            return View(new SubjectVM());

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(SubjectVM model)
        {
            if (ModelState.IsValid)
            {
                await repo.AddAsync(mapper.Map<Subject>(model));

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
            SubjectVM subject = mapper.Map<SubjectVM>(await repo.GetAsync((int)id));

            return View(subject);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubjectVM model)
        {
            if (ModelState.IsValid)
            {

                await repo.UpdateAsync(mapper.Map<Subject>(model));

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }

        }


    }
}

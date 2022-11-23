using EntityFrameworkUppgift.Data;
using EntityFrameworkUppgift.Models;
using EntityFrameworkUppgift.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkUppgift.Controllers
{
    public class LanguageController : Controller
    {
        readonly ApplicationDbContext _context;

        public LanguageController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.people = _context.People.Include(x => x.Languages).ToList();

            ViewBag.People = new SelectList(_context.People, "PersonId", "Name");
            ViewBag.Languages = new SelectList(_context.Languages, "LanguageId", "LanguageName");

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult AddLanguage(LanguageViewModel vm)
        {

            if (ModelState.IsValid)
            {
                Language language = new Language(){ LanguageName = vm.LanguageName};
                _context.Add(language);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddLanguageToPerson(LanguageViewModel vm)
        {
            Person person = _context.People.Include(x => x.Languages).FirstOrDefault(x => x.PersonId == vm.PersonId);
            Language language = _context.Languages.Find(vm.LanguageId);

            person.Languages.Add(language);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}

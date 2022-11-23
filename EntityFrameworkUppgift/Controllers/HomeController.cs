using EntityFrameworkUppgift.Data;
using EntityFrameworkUppgift.Models;
using EntityFrameworkUppgift.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkUppgift.Controllers
{
    public class HomeController : Controller
    {

        readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            PeopleViewModel peopleViewModel = new PeopleViewModel();
            peopleViewModel.people = _context.People.Include(x => x.City).Include(z => z.City.Country).ToList();
            
            ViewBag.Cities = new SelectList(_context.Cities, "CityId", "CityName");

            return View(peopleViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(new Person {Name = model.Name, PhoneNumber = model.PhoneNumber, CityId = model.CityId});
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Person person = _context.People.Find(id);
            _context.People.Remove(person);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
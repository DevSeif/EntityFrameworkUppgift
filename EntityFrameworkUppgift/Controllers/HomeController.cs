using EntityFrameworkUppgift.Data;
using EntityFrameworkUppgift.Models;
using EntityFrameworkUppgift.ViewModels;
using Microsoft.AspNetCore.Mvc;


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
            return View(_context.People.OrderBy(x => x.Name).ToList());
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(new Person {Name = model.Name, PhoneNumber = model.PhoneNumber, City = model.City});
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
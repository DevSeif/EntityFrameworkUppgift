using EntityFrameworkUppgift.Data;
using EntityFrameworkUppgift.Models;
using EntityFrameworkUppgift.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkUppgift.Controllers
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            CityViewModel cityViewModel = new CityViewModel();
            cityViewModel.countries = _context.Cities.Include(x => x.Country).ToList();
            

            ViewBag.Countries = new SelectList(_context.Countries, "CountryId", "CountryName");

            return View(cityViewModel);
        }

        [HttpPost]
        public IActionResult Create(CityViewModel cityViewModel)
        {

            if (ModelState.IsValid)
            {
                City city = new City() { CityName = cityViewModel.Name, CountryId = cityViewModel.CountryId };
                _context.Cities.Add(city);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}

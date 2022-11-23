using EntityFrameworkUppgift.Data;
using EntityFrameworkUppgift.Models;
using EntityFrameworkUppgift.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkUppgift.Controllers
{
    public class CountryController : Controller
    {
        readonly ApplicationDbContext _context;

        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            CountryViewModel countryViewModel = new CountryViewModel();
            countryViewModel.countries = _context.Countries.ToList();

            return View(countryViewModel);
        }

        [HttpPost]
        public IActionResult Create(CountryViewModel countryViewModel)
        {

            if (ModelState.IsValid)
            {
                Country country = new Country() { CountryName = countryViewModel.CountryName};
                _context.Countries.Add(country);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}

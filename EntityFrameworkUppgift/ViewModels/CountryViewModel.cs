using EntityFrameworkUppgift.Models;

namespace EntityFrameworkUppgift.ViewModels
{
    public class CountryViewModel
    {
        public List<Country> countries = new List<Country>();

        public string CountryName { get; set; }
    }
}

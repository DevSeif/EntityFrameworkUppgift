using EntityFrameworkUppgift.Models;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkUppgift.ViewModels
{
    public class CountryViewModel
    {
        public List<Country> countries = new List<Country>();

        [Required]
        public string CountryName { get; set; }
    }
}

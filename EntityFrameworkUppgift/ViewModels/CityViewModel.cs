using EntityFrameworkUppgift.Models;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkUppgift.ViewModels
{
    public class CityViewModel
    {
        public List<City> countries = new List<City>();

        public int CountryId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

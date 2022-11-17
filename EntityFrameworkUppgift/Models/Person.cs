using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkUppgift.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }


        public string Name { get; set; }


        public string PhoneNumber { get; set; }


        public string City { get; set; }

    }
}

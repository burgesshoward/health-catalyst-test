using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleApp.Models
{
    public class Person
    {
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [RegularExpression(@"^[0-9]*$")]
        [StringLength(5, MinimumLength = 5)]
        public string Zip { get; set; }

        public int Age { get; set; }
        public string Interests { get; set; }
        public byte[] Photo { get; set; }
    }
}

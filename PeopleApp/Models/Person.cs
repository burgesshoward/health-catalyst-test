using System;
using System.ComponentModel.DataAnnotations;

namespace PeopleApp.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public int Age { get; set; }
        public string Interests { get; set; }
        public byte[] Photo { get; set; }
    }
}

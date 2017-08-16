using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace PeopleApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PeopleContext(serviceProvider.GetRequiredService<DbContextOptions<PeopleContext>>()))
            {
                if (context.Person.Any()){
                    return;
                }

                context.Person.AddRange(
                    new Person
                    {
                        FirstName = "Burgess",
                        LastName = "Howard",
                        Address = "3881 E 12 N",
                        City = "Rigby",
                        State = "ID",
                        Zip = "83442",
                        Age = 10,
                        Interests = "Dirtbikes, Soccer, Camping, Outdoors"
                    },

					new Person
					{
						FirstName = "Mickey",
						LastName = "Mouse",
						Address = "Disneyland",
						City = "Anahiem",
						State = "CA",
						Zip = "99999",
						Age = 99,
						Interests = "Minnie"
					}
                );

                context.SaveChanges();
            }
        }
    }
}

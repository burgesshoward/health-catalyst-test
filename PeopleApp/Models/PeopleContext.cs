using Microsoft.EntityFrameworkCore;

namespace PeopleApp.Models
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> options) : base(options)
        {
        }

        public DbSet<PeopleApp.Models.Person> Person { get; set; }
    }
}

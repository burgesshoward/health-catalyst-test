using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace PeopleApp.Models
{
    public static class DBinitialize
    {
        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var context = new PeopleContext(serviceProvider.GetRequiredService<DbContextOptions<PeopleContext>>());

            context.Database.EnsureCreated();
        }
    }
}

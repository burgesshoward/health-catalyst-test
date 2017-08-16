using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeopleApp.Models;

namespace PeopleApp.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleContext _context;

        public PeopleController(PeopleContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var people = GetSearchResults(searchString);

			return View(await people.ToListAsync());
        }

		public async Task<IActionResult> IndexSearch(string searchString)
		{
			var people = GetSearchResults(searchString);

            return PartialView("PeoplePartial", await people.ToListAsync());
		}

        private IQueryable<Person> GetSearchResults(string searchString) 
        {
			var people = from p in _context.Person
						 select p;

			if (!String.IsNullOrEmpty(searchString))
			{
				people = people.Where(s => s.FirstName.ToLower().Contains(searchString.ToLower()) ||
									  s.LastName.ToLower().Contains(searchString.ToLower()));
			}

            return people;
        }

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Address,City,State,Zip,Age,Interests")] Person person)
		{
			if (ModelState.IsValid)
			{
				_context.Add(person);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(person);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var person = await _context.Person.SingleOrDefaultAsync(m => m.ID == id);
			if (person == null)
			{
				return NotFound();
			}
			return View(person);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Address,City,State,Zip,Age,Interests")] Person person)
		{
			if (id != person.ID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(person);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!PersonExists(person.ID))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction("Index");
			}
			return View(person);
		}

		private bool PersonExists(int id)
		{
			return _context.Person.Any(e => e.ID == id);
		}

    }
}

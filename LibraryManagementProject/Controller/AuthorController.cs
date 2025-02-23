using Microsoft.AspNetCore.Mvc;
using LibraryManagementProject.Models;

namespace LibraryManagementProject.Controllers
{
    public class AuthorController : Controller
    {
        public static List<AuthorViewModel> authors = new List<AuthorViewModel>();

        public IActionResult List()
        {
            return View(authors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AuthorViewModel model)
        {
            model.Id = authors.Any() ? authors.Max(b => b.Id) + 1 : 1;

            authors.Add(model);

            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            var author = authors.FirstOrDefault(a => a.Id == id);

            if (author == null)
                return NotFound();

            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(AuthorViewModel updatedAuthor)
        {
            var author = authors.FirstOrDefault(a => a.Id == updatedAuthor.Id);

            if (author == null)
                return NotFound();

            author.FirstName = updatedAuthor.FirstName;
            author.LastName = updatedAuthor.LastName;
            author.DateOfBirth = updatedAuthor.DateOfBirth;

            foreach (var book in author.Books)
            {
                book.AuthorName = $"{author.FirstName} {author.LastName}";
            }

            return RedirectToAction("List");
        }

        public IActionResult Details(int id)
        {
            var author = authors.FirstOrDefault(a => a.Id == id);

            if (author == null)
                return NotFound();

            return View(author);
        }

        public IActionResult Delete(int id)
        {
            var author = authors.FirstOrDefault(a => a.Id == id);

            if (author == null) 
                return NotFound();

            foreach (var book in author.Books)
            {
                book.AuthorId = 0;
                book.AuthorName = "Unknown"; 
            }

            authors.Remove(author);

            return RedirectToAction("List");
        }
    }
}

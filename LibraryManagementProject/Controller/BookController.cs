using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryManagementProject.Models;

namespace LibraryManagementProject.Controllers
{
    public class BookController : Controller
    {
        public static List<BookViewModel> books = new List<BookViewModel>();

        public IActionResult List()
        {
            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.Authors = AuthorController.authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = $"{a.FirstName} {a.LastName}"
            }).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {
            // Girilen AuthorId’ye sahip bir yazar var mı kontrol edelim
            var author = AuthorController.authors.FirstOrDefault(a => a.Id == model.AuthorId);

            if (author == null)
            {
                ModelState.AddModelError("AuthorId", "Geçerli bir yazar seçmelisiniz.");
                return View(model);
            }

            // Kitap ID'si otomatik artsın
            model.Id = books.Any() ? books.Max(b => b.Id) + 1 : 1;

            // Yazar bilgisi kitap modeline eklenmeli
            model.AuthorName = $"{author.FirstName} {author.LastName}";

            books.Add(model);

            return RedirectToAction("List");
        }


        public IActionResult Edit(int id)
        {
            ViewBag.Authors = AuthorController.authors
                .Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = $"{a.FirstName} {a.LastName}"
                }).ToList();

            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(BookViewModel updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == updatedBook.Id);

            if (book == null)
                return NotFound();

            var oldAuthor = AuthorController.authors.FirstOrDefault(a => a.Id == book.AuthorId);
            if (oldAuthor != null)
            {
                oldAuthor.Books.Remove(book);
            }

            book.Title = updatedBook.Title;
            book.Genre = updatedBook.Genre;
            book.ISBN = updatedBook.ISBN;
            book.PublishDate = updatedBook.PublishDate;
            book.CopiesAvailable = updatedBook.CopiesAvailable;
            book.AuthorId = updatedBook.AuthorId;

            var newAuthor = AuthorController.authors.FirstOrDefault(a => a.Id == updatedBook.AuthorId);
            if (newAuthor != null)
            {
                book.AuthorName = $"{newAuthor.FirstName} {newAuthor.LastName}";
                newAuthor.Books.Add(book);
            }

            return RedirectToAction("List");
        }

        public IActionResult Details(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound();

            var author = AuthorController.authors.FirstOrDefault(a => a.Id == book.AuthorId);

            if (author != null)
            {
                author.Books.Remove(book);
            }

            books.Remove(book);

            return RedirectToAction("List");
        }
    }
}

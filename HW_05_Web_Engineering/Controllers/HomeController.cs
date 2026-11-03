using HW_05_Web_Engineering.Models;
using HW_05_Web_Engineering.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW_05_Web_Engineering.Controllers
{
    public class HomeController : Controller
    {
        private static List<Author> authors = new List<Author>
        {
            new Author { Id = 1, Name = "Shayan", Country = "PK" },
            new Author { Id = 2, Name = "Arbaz", Country = "PK" }
        };
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "How to Code", Price = 19.99m, AuthorId = 1 },
            new Book { Id = 2, Title = "What is Web", Price = 12.50m, AuthorId = 2 },
            new Book { Id = 3, Title = "C++", Price = 9.99m, AuthorId = 2 }
        };
        [HttpPost]
        public IActionResult AddBook(string title, decimal price, int authorId)
        {
            int newId = books.Any() ? books.Max(b => b.Id) + 1 : 1;
            books.Add(new Book { Id = newId, Title = title, Price = price, AuthorId = authorId });
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddAuthor(string name, string country)
        {
            int newId = authors.Any() ? authors.Max(a => a.Id) + 1 : 1;
            authors.Add(new Author { Id = newId, Name = name, Country = country });
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var bookCardViewModels = new List<BookCardViewModel>();
            foreach (var b in books)
            {
                string? foundAuthorName = "Unknown"; 
                foreach (var a in authors)
                {
                    if (a.Id == b.AuthorId)
                    {
                        foundAuthorName = a.Name;
                        break; 
                    }
                }
                bookCardViewModels.Add(new BookCardViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Price = b.Price,
                    AuthorName = foundAuthorName
                });
            }
            var homeViewModel = new HomeViewModel
            {
                Books = bookCardViewModels,
                Authors = authors
            };
            return View(homeViewModel);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RemoveBook(int id)
        {
            Book? bookToRemove = null;
            foreach (var b in books)
            {
                if (b.Id == id)
                {
                    bookToRemove = b;
                    break;
                }
            }
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }
            return RedirectToAction("Index");
        }
    }
}

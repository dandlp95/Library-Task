using System.Diagnostics;
using Library_Task.Models;
using Library_Task.Repositories.Implementations;
using Library_Task.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepository _bookRepository;

        public HomeController(ILogger<HomeController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <returns>The library page view with a list of all books in the "database".</returns>
        [HttpGet]
        public IActionResult Library()
        {
            try
            {
                List<BookViewModel> books = _bookRepository.GetAllBooksView();
                return View(books);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }

        /// <summary>
        /// Displays the book form. If an Id is provided, the book form will display the book's information to edit. Otherwise, 
        /// it will display an empty form to create a new book.
        /// </summary>
        /// <param name="id">The Id of the book to edit, or null to create a new book.</param>
        /// <returns>The CreateEditBook form view.</returns>
        [HttpGet]
        public IActionResult CreateEditBook(int? id)
        {
            try
            {
                if (id is not null)
                {
                    Book book = _bookRepository.GetBook((int)id);
                    return View(book);
                }
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }
        /// <summary>
        /// Handles the form submission for creating or editing a book. If the book has an Id of 0, redirect to the CreateBook action to create a new book.
        /// Otherwise, redirect to the EditBook action to update the book.
        /// </summary>
        /// <param name="book">The book to create or edit.</param>
        /// <returns>A redirect to the appropriate controller.</returns>
        [HttpPost]
        public IActionResult CreateEditBookForm(Book? book)
        {
            try
            {
                if (book?.Id == 0)
                {
                    return RedirectToAction("CreateBook", book);
                };
                return RedirectToAction("EditBook", book);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }
        /// <summary>
        /// Updates an existing book.
        /// </summary>
        /// <param name="book">The book to update.</param>
        /// <returns>A redirect to the library page.</returns>
        [HttpGet]
        public IActionResult EditBook(Book book)
        {
            try
            {
                _bookRepository.UpdateBook(book);
                return RedirectToAction("Library");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }
        /// <summary>
        /// Creates a new book.
        /// </summary>
        /// <param name="book">The book to create.</param>
        /// <returns>A redirect to the library page.</returns>
        [HttpGet]
        public IActionResult CreateBook(Book book)
        {
            try
            {
                _bookRepository.AddBook(book);
                return RedirectToAction("Library");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }
        /// <summary>
        /// Deletes a book by its Id.
        /// </summary>
        /// <param name="id">The Id of the book to delete.</param>
        /// <returns>A redirect to the library page.</returns>
        [HttpGet]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                _bookRepository.DeleteBook(id);
                return RedirectToAction("Library");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = ex.Message });
            }
        }
    }

}

using Library_Task.Database;
using Library_Task.Models;
using Library_Task.Repositories.Interfaces;
using Library_Task.Services.Implementations;
using Library_Task.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library_Task.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _db;
        private readonly DbSet<Book> _dbSet;
        private readonly IBookService _bookService;
        public BookRepository(LibraryDbContext db, IBookService bookService)
        {
            _db = db;
            _dbSet = db.Set<Book>();
            _bookService = bookService;
        }
        /// <summary>
        /// Gets the view model of a book by its Id.
        /// </summary>
        /// <param name="id">The Id of the book.</param>
        /// <returns>A BookViewModel type object representing the book.</returns>
        public BookViewModel GetBookView(int id)
        {
            Book book = _dbSet.Find(id) ?? throw new InvalidOperationException("Book not found.");
            BookViewModel bookView = _bookService.MapObjects<Book, BookViewModel>(book);
            if (book.PublishedYear != null)
            {
                bookView.PublishedYearDisplay = _bookService.FormatYear((int)book.PublishedYear);
            }
            return bookView;
        }
        /// <summary>
        /// Gets a book by its Id.
        /// </summary>
        /// <param name="id">The Id of the book.</param>
        /// <returns>A Book type object representing the book.</returns>
        public Book GetBook(int id)
        {
            Book book = _dbSet.Find(id) ?? throw new InvalidOperationException("Book not found.");
            return book;
        }
        /// <summary>
        /// Gets a list of all view models representing the books currently in the "database".
        /// </summary>
        /// <returns>A list of BookViewModel type objects representing all books.</returns>
        public List<BookViewModel> GetAllBooksView()
        {
            List<Book> books = _dbSet.OrderBy(b => b.Title).ToList(); // Sorting by Title
            List<BookViewModel> booksViewFormat = _bookService.MapObjects<Book, BookViewModel>(books);

            // Convert to dictionary for faster lookup in the foreach loop below.
            Dictionary<int, Book> bookDictionary = books.ToDictionary(b => b.Id);
            foreach (BookViewModel bookView in booksViewFormat)
            {
                if (bookDictionary.TryGetValue(bookView.Id, out var book) && book.PublishedYear != null)
                {
                    bookView.PublishedYearDisplay = _bookService.FormatYear((int)book.PublishedYear);
                }
            }
            return booksViewFormat;
        }
        /// <summary>
        /// Adds a new book to the repository.
        /// </summary>
        /// <param name="book">The Book type object to add.</param>
        public void AddBook(Book book)
        {
            _dbSet.Add(book);
            _db.SaveChanges();
        }
        /// <summary>
        /// Updates an existing book in the repository.
        /// </summary>
        /// <param name="book">The Book type object to update.</param>
        public void UpdateBook(Book book)
        {
            _dbSet.Update(book);
            _db.SaveChanges();
        }
        /// <summary>
        /// Deletes a book from the repository by its ID.
        /// </summary>
        /// <param name="id">The Id of the book to delete.</param>
        public void DeleteBook(int id)
        {
            Book book = GetBook(id);
            _dbSet.Remove(book);
            _db.SaveChanges();
        }

    }
}

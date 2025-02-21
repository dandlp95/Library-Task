using Library_Task.Models;

namespace Library_Task.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public BookViewModel GetBookView(int id);
        public Book GetBook(int id);
        public List<BookViewModel> GetAllBooksView();
        public void AddBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(int id);
    }
}

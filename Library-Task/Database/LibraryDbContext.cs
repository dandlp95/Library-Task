using Library_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Task.Database
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "To Kill a Mockingbird", Author = "Harper Lee", PublishedYear = 1960 },
                new Book { Id = 2, Title = "1984", Author = "George Orwell", PublishedYear = 1949 },
                new Book { Id = 3, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublishedYear = 1925 },
                new Book { Id = 4, Title = "Moby-Dick", Author = "Herman Melville", PublishedYear = 1851 },
                new Book { Id = 5, Title = "Pride and Prejudice", Author = "Jane Austen", PublishedYear = 1813 },
                new Book { Id = 6, Title = "The Catcher in the Rye", Author = "J.D. Salinger", PublishedYear = 1951 },
                new Book { Id = 7, Title = "The Testaments", Author = "Margaret Atwood", PublishedYear = 2019 },
                new Book { Id = 8, Title = "Project Hail Mary", Author = "Andy Weir", PublishedYear = 2021 },
                new Book { Id = 9, Title = "The Midnight Library", Author = "Matt Haig", PublishedYear = 2020 },
                new Book { Id = 10, Title = "Klara and the Sun", Author = "Kazuo Ishiguro", PublishedYear = 2021 },
                new Book { Id = 11, Title = "The Night Watchman", Author = "Louise Erdrich", PublishedYear = 2020 },
                new Book { Id = 12, Title = "The Paper Palace", Author = "Miranda Cowley Heller", PublishedYear = 2021 },
                new Book { Id = 13, Title = "The Lincoln Highway", Author = "Amor Towles", PublishedYear = 2021 },
                new Book { Id = 14, Title = "Cloud Cuckoo Land", Author = "Anthony Doerr", PublishedYear = 2021 },
                new Book { Id = 15, Title = "Bewilderment", Author = "Richard Powers", PublishedYear = 2021 }
                );
        }
    }
}

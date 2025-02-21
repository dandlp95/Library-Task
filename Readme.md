# Library Task

## Overview

Library Task is a ASP.NET Core Web App (MVC) project that manages a collection of books. It allows users to view, add, edit, and delete books from the library. The project uses an in-memory database for data storage and includes a simple user interface for interacting with the library.

## Features

- View a list of books in the library
- Add a new book to the library
- Edit an existing book in the library
- Delete a book from the library
- Display book details including title, author, and published year

## Project Structure

The project is structured as follows:

- **Controllers**: Contains the `HomeController` which handles the main operations for the library.
- **Database**: Contains the `LibraryDbContext` which manages the in-memory database.
- **Models**: Contains the `Book` and `BookViewModel` classes which represent the data models.
- **Repositories**: Contains the `IBookRepository` interface and its implementation `BookRepository` which handle data operations.
- **Services**: Contains the `IBookService` interface and its implementation `BookService` which provide additional business logic.
- ## Usage

- **View Books**: Navigate to the "Library" page to see a list of all books.
- **Add Book**: Click on "Add Book" to open the form for adding a new book.
- **Edit Book**: Click on a book in the list to open the form for editing the book details.
- **Delete Book**: Click on the "Delete" button next to a book to remove it from the library.

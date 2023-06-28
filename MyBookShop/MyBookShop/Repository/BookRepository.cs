using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookShop.Models;
using MyBookShop.Data;
namespace MyBookShop.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _bookStoreContext = null;
        public BookRepository(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }
        public int AddBook(BookModel bookModel)
        {
            var newBook = new Books() {
                BookName = bookModel.BookName,
                Author=bookModel.Author,
                Description = bookModel.Description,
                TotalPages = bookModel.TotalPages,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn=DateTime.UtcNow
            };
            _bookStoreContext.Books.Add(newBook);
            _bookStoreContext.SaveChanges();
            return newBook.id;
        }
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBook(int id)
        {
            return DataSource().Where(x => x.id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBooks(string bookname, string author)
        {
            return DataSource().Where(x => x.BookName.Contains(bookname) && x.Author.Contains(author)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>() { 
            new BookModel (){id=1,BookName="C#",Author="abc",Description="This is an sample book for your reference.",Category="IT",Language="Pogramming",TotalPages=562 },
            new BookModel (){id=2,BookName="ASP.NET",Author="xyz",Description="This is an sample book for your reference.",Category="IT",Language="Pogramming",TotalPages=562 },
            new BookModel (){id=3,BookName="ASP.NET MVC",Author="abc",Description="This is an sample book for your reference.",Category="IT",Language="Pogramming",TotalPages=562 },
            new BookModel (){id=9,BookName="React",Author="xyz",Description="This is an sample book for your reference.",Category="IT",Language="Pogramming",TotalPages=562 }
            };
        }
    }
}

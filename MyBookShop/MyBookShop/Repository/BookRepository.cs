using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookShop.Models;
using MyBookShop.Data;
using Microsoft.EntityFrameworkCore;

namespace MyBookShop.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _bookStoreContext = null;
        public BookRepository(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }       
        public async Task<int> AddBook(BookModel bookModel)
        {
            var newBook = new Books() {
                BookName = bookModel.BookName,
                Author=bookModel.Author,
                Description = bookModel.Description,
                TotalPages = bookModel.TotalPages.HasValue?bookModel.TotalPages.Value:0,//if we set nullable property in Book Model, then we have to check has value. we have to check whether it contains the data or not.
                LanguageId = bookModel.LanguageId,
                //Language = bookModel.Language.Name,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn=DateTime.UtcNow
            };
           await _bookStoreContext.Books.AddAsync(newBook);
           await _bookStoreContext.SaveChangesAsync();
            return newBook.id;
        }
        public async Task< List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _bookStoreContext.Books.ToListAsync();
            if (allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel() { 
                    BookName=book.BookName,
                    Author=book.Author,
                    Description=book.Description,
                    TotalPages=book.TotalPages,
                    id=book.id,
                    Category=book.Category,
                        LanguageId = book.LanguageId,
                        Language=book.Language.Name

                    });
                }
            }
            return books;
        }

        
        public async Task<BookModel> GetBook(int id)
        {
           //var book= await _bookStoreContext.Books.FindAsync(id);
           return await _bookStoreContext.Books.Where(x=>x.id==id).Select(book => new BookModel()
            {
                BookName = book.BookName,
                Author = book.Author,
                Description = book.Description,
                TotalPages = book.TotalPages,
                id = book.id,
                Category = book.Category,
                LanguageId = book.LanguageId,
                Language = book.Language.Name
            }).FirstOrDefaultAsync();
            ////if (book != null)
            ////{
            //    var bookdetails = new BookModel() {
            //        BookName = book.BookName,
            //        Author = book.Author,
            //        Description = book.Description,
            //        TotalPages = book.TotalPages,
            //        id = book.id,
            //        Category = book.Category,
            //        LanguageId = book.LanguageId,
            //        Language=book.Language.Name
            //    };
            //    return bookdetails;
            ////}
            //return null;
            //return DataSource().Where(x => x.id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBooks(string bookname, string author)
        {
            return null;
            //return DataSource().Where(x => x.BookName.Contains(bookname) && x.Author.Contains(author)).ToList();
        }

        //private List<BookModel> DataSource()
        //{
        //    return new List<BookModel>() { 
        //    new BookModel (){id=1,BookName="C#",Author="abc",Description="This is an sample book for your reference.",Category="IT",Language="Pogramming",TotalPages=562 },
        //    new BookModel (){id=2,BookName="ASP.NET",Author="xyz",Description="This is an sample book for your reference.",Category="IT",Language="Pogramming",TotalPages=562 },
        //    new BookModel (){id=3,BookName="ASP.NET MVC",Author="abc",Description="This is an sample book for your reference.",Category="IT",Language="Pogramming",TotalPages=562 },
        //    new BookModel (){id=9,BookName="React",Author="xyz",Description="This is an sample book for your reference.",Category="IT",Language="Pogramming",TotalPages=562 }
        //    };
        //}
    }
}

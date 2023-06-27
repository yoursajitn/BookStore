using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookShop.Models;

namespace MyBookShop.Repository
{
    public class BookRepository
    {
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
            new BookModel (){id=4,BookName="React",Author="xyz",Description="This is an sample book for your reference.",Category="IT",Language="Pogramming",TotalPages=562 }
            };
        }
    }
}

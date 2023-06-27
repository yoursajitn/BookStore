using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookShop.Repository ;
using MyBookShop.Models;

namespace MyBookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {
            //return _bookRepository.GetAllBooks();
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }

        public ViewResult GetBookId(int id)
        {
            var data= _bookRepository.GetBook(id);
            return View(data);
        }

        public List<BookModel> searchBook(string bookname, string author)
        {
            return _bookRepository.SearchBooks(bookname, author);
        }

        public ViewResult AddNewBook()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddNewBook(BookModel _bookModel)
        {
            return View();
        }
    }
}

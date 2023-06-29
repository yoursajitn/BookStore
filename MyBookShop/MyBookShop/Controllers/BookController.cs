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
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }        
        public async Task<ViewResult> GetAllBooks()
        {
            //return _bookRepository.GetAllBooks();
            var data =await _bookRepository.GetAllBooks();
            return View(data);
        }

        public async Task<ViewResult> GetBookId(int id)
        {
            var data=await _bookRepository.GetBook(id);
            return View(data);
        }

        public List<BookModel> searchBook(string bookname, string author)
        {
            return _bookRepository.SearchBooks(bookname, author);
        }

        public ViewResult AddNewBook(bool isSuccess=false,int bookid=0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookid;
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> AddNewBook(BookModel _bookModel)
        {
           int id=await _bookRepository.AddBook(_bookModel);
            if (id > 0)
            {
                //this will reset the fields, we called AddNewBook() from [HTTPGET].
                return RedirectToAction(nameof(AddNewBook),new { isSuccess=true,bookid=id});
            }
            return View();
        }        
    }
}

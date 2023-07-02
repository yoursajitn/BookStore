using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookShop.Repository;
using MyBookShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MyBookShop.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            //return _bookRepository.GetAllBooks();
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        public async Task<ViewResult> GetBookId(int id)
        {
            var data = await _bookRepository.GetBook(id);
            return View(data);
        }

        public List<BookModel> searchBook(string bookname, string author)
        {
            return _bookRepository.SearchBooks(bookname, author);
        }

        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookid = 0)
        {
            //var model = new BookModel() { Language="Marathi"};
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookid;
            //var group1 = new SelectListGroup() {Name="Group1" };
            //var group2 = new SelectListGroup() { Name = "Group2" };
            //var group3 = new SelectListGroup() { Name = "Group3" };
            //ViewBag.Language =new SelectList(new List<string>() {"Marahi","Hindi","English","Spanish" });
            //ViewBag.Language = new SelectList(getLanguages(),"Id","Text");
            //ViewBag.Language = new List<SelectListItem>() {
            //new SelectListItem(){Value="1",Text="Marathi",Group=group1 },
            //new SelectListItem(){Value="2",Text="Hindi",Group=group1 },
            //new SelectListItem(){Value="3",Text="English",Group=group2 },
            //new SelectListItem(){Value="4",Text="Spanish",Group=group2 },
            //new SelectListItem(){Value="5",Text="Urdu",Group=group3 },
            //};
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel _bookModel)
        {
            if (ModelState.IsValid)
            {
                if (_bookModel.CoverPhoto != null)
                {
                    string folder = "Books/Cover/";
                    _bookModel.CoverImageUrl = await UploadImage(folder, _bookModel.CoverPhoto);
                }
                if (_bookModel.GallaryFiles != null)
                {
                    string folder = "Books/Gallery/";
                    _bookModel.Gallery = new List<GalleryModel>();
                    foreach (var file in _bookModel.GallaryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            Url = await UploadImage(folder, file)
                        };
                        _bookModel.Gallery.Add(gallery);
                    }
                }
                if (_bookModel.BookPdf != null)
                {
                    string folder = "Books/Pdf/";
                    _bookModel.BookPdfUrl = await UploadImage(folder, _bookModel.BookPdf);
                }
                int id = await _bookRepository.AddBook(_bookModel);
                if (id > 0)
                {
                    //this will reset the fields, we called AddNewBook() from [HTTPGET].
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookid = id });
                }

            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            //ViewBag.Language = new List<string>() { "Marahi", "Hindi", "English", "Spanish" };
            //ViewBag.Language = new SelectList(getLanguages(), "Id", "Text");
            //Note : in validatio summary we can use 2 values, All and ModleOnly.
            //All value contains the property as well as model(from controller, custom error) value.
            //ModelOnly- contains only custom error from controller
            //ModelState.AddModelError("", "This is an custom error message");
            return View();

        }

        private async Task<string> UploadImage(string folderpath, IFormFile file)
        {

            folderpath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folderpath);
            await file.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
            return "/" + folderpath;
        }

        //private List<LanguageModel> getLanguages()
        //{
        //    return new List<LanguageModel>() {
        //    new LanguageModel(){Id=1,Text="Marathi" },
        //    new LanguageModel(){Id=2,Text="Hindi" },
        //    new LanguageModel(){Id=3,Text="English" },
        //    };
        //}
    }
}

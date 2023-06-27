using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBookShop.Models;


namespace MyBookShop.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Type = new BookModel() {id=1,BookName="C#" };
            ViewData["BookDetails"] = new BookModel() {id=5,BookName="React Js" };
            return View();
        }
        public ViewResult AboutUs()
        {
            return View();
        }
        [ViewData]
        public string Address { get; set; }
        public ViewResult ContactUs()
        {
            Address = "Solapur";
            return View();
        }

    }
}

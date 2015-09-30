using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Models;

namespace WebUI.Controllers
{
    public class BookController : Controller
    {
        //private IRepository<Book> repository;

        //public BookController(IRepository<Book> bookRepository)
        //{
        //    this.repository = bookRepository;
        //}

        private IBookService bookService;

        public BookController(IBookService _bookService)
        {
            this.bookService = _bookService;
        }

        public ViewResult List()
        {
            return View(bookService.GetList());
        }
    }
}
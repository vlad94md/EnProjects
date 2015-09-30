﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace AutofacLearn.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository repository;

        public BookController(IBookRepository bookRepository)
        {
            this.repository = bookRepository;
        }

        public ViewResult List()
        {
            return View(repository.Books);
        }
    }
}
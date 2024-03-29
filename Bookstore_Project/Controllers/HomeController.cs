﻿using Bookstore_Project.Models;
using Bookstore_Project.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_Project.Controllers
{
    public class HomeController : Controller
    {

        private IBookstoreProjectRepository repo;
        public HomeController(IBookstoreProjectRepository temp) => repo = temp;

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            //books per page
            int pageSize = 10;

            var x = new BooksViewModel
            {
                //grabbing the right books for the right pages
                Books = repo.Books
                .Where(b => b.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                        (bookCategory == null 
                            ? repo.Books.Count() 
                            : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}

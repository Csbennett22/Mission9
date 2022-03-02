using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookType, int pageNum = 1) //set the default page to 1 & DO NOT USE page as this variable name
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books //.ToList() //we changed the data that is passed in; it is no longer a list
                    .Where(b => b.Category == bookType || bookType == null)
                    .OrderBy(b => b.Title)
                    .Skip(pageSize * (pageNum - 1)) // skip certain number of records
                    .Take(pageSize), // take a certain number of records

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookType == null ? repo.Books.Count() 
                    : repo.Books.Where(x => x.Category == bookType).Count()),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}

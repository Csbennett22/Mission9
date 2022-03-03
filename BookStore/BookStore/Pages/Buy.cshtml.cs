using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.infrastructure;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore.Pages
{
    public class BuyModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public Cart kart { get; set; }
        public string ReturnUrl { get; set; }
        public BuyModel(IBookstoreRepository temp, Cart c)
        {
            repo = temp;
            kart = c;
        }

        public Cart cart { get; set; }
        //public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

            //cart = HttpContext.Session.GetJson<Cart>("basket") ?? new Cart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            //cart = HttpContext.Session.GetJson<Cart>("basket") ?? new Cart();

            kart.AddItem(b, 1);

            //HttpContext.Session.SetJson("basket", cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            kart.RemoveItem(kart.Items.First(x => x.booker.BookId == bookId).booker);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}

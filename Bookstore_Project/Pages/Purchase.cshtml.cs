using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore_Project.Infastructure;
using Bookstore_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore_Project.Pages
{
    public class PurchaseModel : PageModel
    {

        private IBookstoreProjectRepository repo { get; set; }

        public PurchaseModel(IBookstoreProjectRepository temp)
        {
            repo = temp;
        }

        public ShoppingCart shoppingcart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            shoppingcart = HttpContext.Session.GetJson<ShoppingCart>("shoppingcart") ?? new ShoppingCart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            shoppingcart = HttpContext.Session.GetJson<ShoppingCart>("shoppingcart") ?? new ShoppingCart();
            shoppingcart.AddItem(b, 1);

            HttpContext.Session.SetJson("shoppingcart", shoppingcart);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}

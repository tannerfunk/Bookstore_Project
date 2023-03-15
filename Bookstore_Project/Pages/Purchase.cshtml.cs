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

        // Declare an instance of IBookstoreProjectRepository to handle bookstore data
        private IBookstoreProjectRepository repo { get; set; }

        // Constructor that takes in IBookstoreProjectRepository and ShoppingCart objects
        public PurchaseModel(IBookstoreProjectRepository temp, ShoppingCart sc)
        {
            repo = temp;
            shoppingcart = sc;
        }

        // Declare an instance of the ShoppingCart object and a string for the return URL
        public ShoppingCart shoppingcart { get; set; }
        public string ReturnUrl { get; set; }

        // HTTP GET method for the Purchase page that sets the return URL
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        // HTTP POST method for adding a book to the shopping cart
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            // Retrieve the book based on the book ID
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            // Add the book to the shopping cart
            shoppingcart.AddItem(b, 1);

            // Redirect the user to the previous page
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        // HTTP POST method for removing a book from the shopping cart
        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            // Remove the book from the shopping cart based on the book ID
            shoppingcart.RemoveItem(shoppingcart.Items.First(x => x.Book.BookId == bookId).Book);

            // Redirect the user to the previous page
            return RedirectToPage(new {ReturnUrl = returnUrl });
        }
    }
}

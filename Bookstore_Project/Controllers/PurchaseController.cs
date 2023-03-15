using Bookstore_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_Project.Controllers
{
    public class PurchaseController : Controller
    {

        // Declare a private instance of IPurchaseRepository and ShoppingCart 
        // to handle purchases and shopping carts
        private IPurchaseRepository repo { get; set; }
        private ShoppingCart shoppingcart { get; set; }

        // Constructor that takes in IPurchaseRepository and ShoppingCart objects
        public PurchaseController (IPurchaseRepository temp, ShoppingCart sc)
        {
            repo = temp;
            shoppingcart = sc;
        }

        // HTTP GET method for the Checkout action that returns the view with an empty Purchase object
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        // HTTP POST method for the Checkout action that processes the purchase information
        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (shoppingcart.Items.Count == 0)
            {
                ModelState.AddModelError("", "Sorry, your shoppping cart is empty!");
            }

            // If the purchase object is valid, save it to the repository, clear the shopping cart, 
            // and redirect the user to the PurchaseCompleted page
            if (ModelState.IsValid)
            {
                purchase.Lines = shoppingcart.Items.ToArray();
                repo.SavePurchase(purchase);
                shoppingcart.ClearCart();

                return RedirectToPage("/PurchaseCompleted");
            }
            // Otherwise, return the view with the invalid purchase object
            else
            {
                return View();
            }
        }
    }
}

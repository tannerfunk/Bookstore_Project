using Bookstore_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_Project.Views.Shared.Components
{
    public class CartSummaryViewComponent : ViewComponent {

        private ShoppingCart shoppingcart;
        public CartSummaryViewComponent(ShoppingCart temp)
        {
            shoppingcart = temp;
        }
        public IViewComponentResult Invoke()
        {
            return View(shoppingcart);
        }

    }
}

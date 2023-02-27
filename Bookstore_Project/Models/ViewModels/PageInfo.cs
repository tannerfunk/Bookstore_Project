using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_Project.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        // Figure out how many pages we need
        // Cast it as a double, round up cast back to int, send it to the total pages variable.
        public int TotalPages => (int) Math.Ceiling((double)TotalNumBooks / BooksPerPage);
    }
}

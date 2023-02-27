using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_Project.Models
{
    public class EFBookstoreProjectRepository : IBookstoreProjectRepository
    {
        private BookstoreContext context { get; set; }

        //THIS \/  \/  \/
        //public EFBookstoreProjectRepository(BookstoreContext temp)
        //{
        //    context = temp;
        //}
        //IS THE SAME AS THIS \/ \/ \/
        public EFBookstoreProjectRepository(BookstoreContext temp) => context = temp;


        public IQueryable<Book> Books => context.Books;
    }
}

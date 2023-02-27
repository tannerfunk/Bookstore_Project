using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_Project.Models
{
    public interface IBookstoreProjectRepository
    {
        IQueryable<Book> Books { get; }
    }
}

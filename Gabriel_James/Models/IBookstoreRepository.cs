using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabriel_James.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}

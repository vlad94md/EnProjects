using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace AutofacLearn
{
    public interface IBookRepository
    {
        IQueryable<Book> Products { get; }
    }
}

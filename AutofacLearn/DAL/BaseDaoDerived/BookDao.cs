using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookDao : BaseDao<Book>
    {
        public BookDao(IRepository<Book> repos)
            : base(repos){}

    }
}

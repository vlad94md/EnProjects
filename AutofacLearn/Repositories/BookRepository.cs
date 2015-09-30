using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    public class BookRepository : IBookRepository  
    { 
        private LibraryEntities context = new LibraryEntities();     
        public IQueryable<Book> Books{ get { return context.Books; }
    }
}

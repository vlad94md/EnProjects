using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookRepository : IRepository<Book>
    { 
        private LibraryEntities context = new LibraryEntities();

        public ICollection<Book> GetList
        { 
            get { return context.Books.ToList(); } 
        }

        public bool Add(Book book)
        {
            context.Books.Add(book);
            return context.SaveChanges() > 0;
        }

        public bool Delete(Book book)
        {
            context.Books.Remove(book);
            return context.SaveChanges() > 0;
        }

    }
}

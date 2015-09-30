using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
using Converter;

namespace Services
{
    public class BookService : IBookService
    {
        private BookDao bookDao;

        public BookService()
        {
            bookDao = new BookDao(new BookRepository());  // :(
        }

        public ICollection<BookModel> GetList()
        {
            return bookDao.GetList().Select(x => BookConverter.ConvertToModel(x)).ToList();
        }
    }
}

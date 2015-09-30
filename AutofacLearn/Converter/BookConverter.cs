using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace Converter
{
    public static class BookConverter
    {
        public static Book ConvertToDB(BookModel bookMod)
        {
            throw new NotImplementedException();
        }

        public static BookModel ConvertToModel(Book book)
        {
            return new BookModel()
            {
                Id = book.Id,
                Title = book.Title,
                Descriptn = book.Descriptn,
                Price = book.Price,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                Author = AuthorConverter.ConvertToModel(book.Author),
            };
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class BookCRUD
    {
        public int AddBook(Book book)
        {
            int addedBookId;
            using (var context = new LibraryEntities())
            {
                context.Books.Add(book);
                context.SaveChanges();
                addedBookId = book.Id;
            }
            return addedBookId;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> result;
            using (var context = new LibraryEntities())
            {
                result = context.Books.Include("Author").Include("Category").ToList();
            }
            return result;
        }

        public bool DeleteBookById(int id)
        {
            bool result = false;
            using (var context = new LibraryEntities())
            {
                var bookToDelte = context.Books.FirstOrDefault(x => x.Id == id);
                if (bookToDelte != null)
                {
                    context.Books.Remove(bookToDelte);
                    context.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        //public Category GetCategoryOfBook(int id)
        //{
        //    Category result;
        //    using (var context = new LibraryEntities())
        //    {
        //        result = context.Books.FirstOrDefault(x => x.Id == id).Category;
        //    }
        //    return result;
        //}

        //public Author GetAuthorOfBook(int id)
        //{
        //    Author result;
        //    using (var context = new LibraryEntities())
        //    {
        //        result = context.Books.FirstOrDefault(x => x.Id == id).Author;
        //    }
        //    return result;
        //}

        public List<Book> GetBooksWithCategoryId(int id)
        {
            List<Book> result;
            using (var context = new LibraryEntities())
            {
                result = context.Books.Where(x => x.Category.Id == id).ToList();
            }
            return result;
        }

        public List<Book> GetBooksWithAuthorId(int id)
        {
            List<Book> result;
            using (var context = new LibraryEntities())
            {
                result = context.Books.Where(x => x.Author.Id == id).ToList();
            }
            return result;
        }

        public Book GetBookById(int id)
        {
            Book result;
            using (var context = new LibraryEntities())
            {
                result = context.Books.Include("Author").Include("Category").FirstOrDefault(x => x.Id == id);
            }
            return result;
        }

        public void UpdateBookTitle(int bookId, string title)
        {
            using (var context = new LibraryEntities())
            {
                context.Books.FirstOrDefault(x => x.Id == bookId).Title = title;
                context.SaveChanges();
            }
        }

        public void UpdateBookDescr(int bookId, string descr)
        {
            using (var context = new LibraryEntities())
            {
                context.Books.FirstOrDefault(x => x.Id == bookId).Descriptn = descr;
                context.SaveChanges();
            }
        }

        public void UpdateBookPrice(int bookId, int price)
        {
            using (var context = new LibraryEntities())
            {
                context.Books.FirstOrDefault(x => x.Id == bookId).Price = price;
                context.SaveChanges();
            }
        }

        public void UpdateBookAuthor(int bookId, int authorId)
        {
            using (var context = new LibraryEntities())
            {
                context.Books.FirstOrDefault(x => x.Id == bookId).AuthorId = authorId;
                context.SaveChanges();
            }
        }
    }
}
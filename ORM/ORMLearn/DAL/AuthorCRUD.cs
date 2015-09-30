using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class AuthorCRUD
    {
        public int AddAuthor(Author author)
        {
            int addedAuthorId;
            using (var context = new LibraryEntities())
            {
                context.Authors.Add(author);
                context.SaveChanges();
                addedAuthorId = author.Id;
            }
            return addedAuthorId;
        }

        public List<Author> GetAllAuthors()
        {
            List<Author> result;
            using (var context = new LibraryEntities())
            {
                result = context.Authors.ToList();
            }
            return result;
        }

        public bool DeleteAuthorById(int id)
        {
            bool result = false;
            using (var context = new LibraryEntities())
            {
                var authorToDelte = context.Authors.FirstOrDefault(x => x.Id == id);
                if (authorToDelte != null)
                {
                    context.Authors.Remove(authorToDelte);
                    context.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public Author GetAuthorById(int id)
        {
            Author result;
            using (var context = new LibraryEntities())
            {
                result = context.Authors.FirstOrDefault(x => x.Id == id);
            }
            return result;
        }
    }
}
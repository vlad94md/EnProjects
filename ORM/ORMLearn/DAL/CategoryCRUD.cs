using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class CategoryCRUD
    {
        public int AddCategory(Category cat)
        {
            int addedAuthorId;
            using (var context = new LibraryEntities())
            {
                context.Categorys.Add(cat);
                context.SaveChanges();
                addedAuthorId = cat.Id;
            }
            return addedAuthorId;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> result;
            using (var context = new LibraryEntities())
            {
                result = context.Categorys.ToList();
            }
            return result;
        }

        public bool DeleteCategoryById(int id)
        {
            bool result = false;
            using (var context = new LibraryEntities())
            {
                var categoryToDelte = context.Categorys.FirstOrDefault(x => x.Id == id);
                if (categoryToDelte != null)
                {
                    context.Categorys.Remove(categoryToDelte);
                    context.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
    }
}
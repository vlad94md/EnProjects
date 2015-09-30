namespace DAL
{
    public class LibraryDB
    {
        public BookCRUD bookCrud;
        public AuthorCRUD authorCrud;
        public CategoryCRUD categoryCrud;

        public LibraryDB()
        {
            bookCrud = new BookCRUD();
            authorCrud = new AuthorCRUD();
            categoryCrud = new CategoryCRUD();
        }
    }
}
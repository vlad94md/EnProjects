using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BookLibrary
{
    class LibraryManager
    {
        LibraryDB lib;

        public LibraryManager(LibraryDB lib)
        {
            this.lib = lib;
        }

        public void PrintAllBooks()
        {
            var allBooks = lib.bookCrud.GetAllBooks();

            Console.WriteLine("All Books: \n");
            foreach (Book row in allBooks)
            {
                printBook(row);
                Console.WriteLine("\n");
            }
        }

        public void PrintAuthors()
        {
            var allAuthors = lib.authorCrud.GetAllAuthors();

            Console.WriteLine("Authors: \n");
            foreach (Author row in allAuthors)
            {
                Console.WriteLine(String.Format("First Name: {0} \nLast Name: {1} \nCountry: {2}\nID: {3}", 
                    row.First_name, row.Last_name, row.Country, row.Id));

                Console.Write("Written:");
                var booksForAuthor = lib.bookCrud.GetBooksWithAuthorId(row.Id);
                Console.WriteLine(booksForAuthor.Count());
                foreach (var item in booksForAuthor)
                {
                    Console.WriteLine(item.Title);
                }
                Console.WriteLine("\n");
            }
        }

        public void PrintCategories()
        {
            var allCategories = lib.categoryCrud.GetAllCategories();

            Console.WriteLine("Categories: \n");
            foreach (Category row in allCategories)
            {
                Console.WriteLine(String.Format("Category: {0}\nID: {1}", row.Name, row.Id));
                Console.Write("Books from this category: ");
                var booksForCategory = lib.bookCrud.GetBooksWithCategoryId(row.Id);
                Console.WriteLine(booksForCategory.Count());
                foreach (var item in booksForCategory)
                {
                    Console.WriteLine(item.Title);
                }
                Console.WriteLine("\n");
            }
        }

        public void PrintBooksExpensiveThan()
        {
            Console.WriteLine("Enter Price");
            int currentPrice = Convert.ToInt32(Console.ReadLine());

            var allBooksExpensiveThenCurPrice = lib.bookCrud.GetAllBooks().Where(x => x.Price >= currentPrice);
            Console.WriteLine("All books more expensive than " + currentPrice + ": \n");

            foreach (Book row in allBooksExpensiveThenCurPrice)
            {
                printBook(row);
                Console.WriteLine("\n");
            }
        }

        public void PrintBookFoundById()
        {
            Console.WriteLine("Enter Book ID:");
            int selectedId = Convert.ToInt32(Console.ReadLine());

            var foundBook = lib.bookCrud.GetBookById(selectedId);

            if (foundBook == null )
            {
                Console.WriteLine("No book with such ID found!");
            }
            else
            {
                Console.WriteLine("Book found:\n");
                printBook(foundBook);
                Console.WriteLine("\n");
            }

        }

        public void PrintBooksOFSelectedCategory()
        {
            Console.WriteLine("Enter category name:");
            string selectedCategory = Console.ReadLine();

            var booksOfSelectedCategory = lib.bookCrud.GetAllBooks().Where(x => x.Category.Name == selectedCategory);

            Console.WriteLine("Books From category {0}: \n", selectedCategory);

            if (booksOfSelectedCategory.Count() == 0)
            {
                Console.WriteLine("No books found!");
            }
            else
            {         
                foreach (Book row in booksOfSelectedCategory)
                {
                    printBook(row);
                    Console.WriteLine("\n");
                }
            }
        }

        public void PrintBookFoundByTitle()
        {
            Console.WriteLine("Enter Book Title:");
            string selectedTitle = Console.ReadLine();

            var foundBook = lib.bookCrud.GetAllBooks().FirstOrDefault(x => x.Title == selectedTitle);

            if (foundBook == null)
            {
                Console.WriteLine("No book with such title found!");
            }
            else
            {
                Console.WriteLine("Book found:\n");
                printBook(foundBook);
                Console.WriteLine("\n");
            }
        }

        public void AddNewBook()
        {
            Console.WriteLine("Enter book title:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter book description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter book price:");
            int price = Convert.ToInt32(Console.ReadLine());

            var authors = lib.authorCrud.GetAllAuthors();
            printAuthorsList(authors);
            Console.Write("Choose author ID:");
            int authorId = Convert.ToInt32(Console.ReadLine());

            var categories = lib.categoryCrud.GetAllCategories();
            printCategoryList(categories);
            Console.Write("Choose category ID:");
            int categoryId = Convert.ToInt32(Console.ReadLine());

            lib.bookCrud.AddBook(new Book 
            { 
                Title = title, 
                Price = price, 
                Descriptn = description, 
                AuthorId = authorId,
                CategoryId = categoryId
            });
            Console.WriteLine("New book added!");
        }

        public void DeleteBook()
        {
            Console.WriteLine("Enter book Id to delete:");
            int id = Convert.ToInt32(Console.ReadLine());
            lib.bookCrud.DeleteBookById(id);
        }

        public void AddNewAuthor()
        {
            Console.WriteLine("Enter author first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter author last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter author motherland");
            string country = Console.ReadLine();

            lib.authorCrud.AddAuthor(new Author { First_name = firstName, Last_name = lastName, Country = country});
        }

        public void DeleteAuthor()
        {
            Console.WriteLine("Enter author Id to delete:");
            int id = Convert.ToInt32(Console.ReadLine());
            lib.authorCrud.DeleteAuthorById(id);
        }

        public void AddNewCategory()
        {
            Console.WriteLine("Enter new category name:");
            string name = Console.ReadLine();

            lib.categoryCrud.AddCategory(new Category { Name = name });
        }

        public void DeleteCategory()
        {
            Console.WriteLine("Enter category Id to delete:");
            int id = Convert.ToInt32(Console.ReadLine());
            lib.categoryCrud.DeleteCategoryById(id);
        }

        public void ModifyBook()
        {
            Console.WriteLine("Enter Book ID:");
            int selectedId = Convert.ToInt32(Console.ReadLine());

            var foundBook = lib.bookCrud.GetBookById(selectedId);

            if (foundBook == null)
            {
                Console.WriteLine("No book with such ID found!");
            }
            else
            {
                Console.WriteLine("Choose field to modify: ");
                Console.WriteLine("1)Title: ");
                Console.WriteLine("2)Description: ");
                Console.WriteLine("3)Price: ");
                Console.WriteLine("4)Author ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Title: ");
                        string title = Console.ReadLine();
                        lib.bookCrud.UpdateBookTitle(selectedId,title);
                        break;
                    case 2:
                        Console.WriteLine("Enter Description: ");
                        string descr = Console.ReadLine();
                        lib.bookCrud.UpdateBookDescr(selectedId, descr);
                        break;
                    case 3:
                        Console.WriteLine("Enter new Price: ");
                        int price = Convert.ToInt32(Console.ReadLine());
                        lib.bookCrud.UpdateBookPrice(selectedId, price);
                        break;
                    case 4:
                        var authors = lib.authorCrud.GetAllAuthors();
                        printAuthorsList(authors);
                        Console.Write("Choose author ID:");
                        int authorId = Convert.ToInt32(Console.ReadLine());
                        lib.bookCrud.UpdateBookAuthor(selectedId, authorId);
                        break;
                }

                
            }
        }


        private void printBook(Book book)
        {
            Console.WriteLine
                (
                    String.Format("Title: {0} \nDescription: {1} \nAuthor: {2} \nCategory: {3} \nPrice: {4}\nID: {5}",
                    book.Title, 
                    book.Descriptn, 
                    (book.Author.First_name + " " + book.Author.Last_name), 
                    book.Category.Name, 
                    book.Price, 
                    book.Id)
                );
        }

        private void printAuthorsList(List<Author> authors)
        {
            foreach (Author row in authors)
            {
                Console.WriteLine(String.Format("First Name: {0} \nLast Name: {1} \nCountry: {2}\nID: {3}",
                    row.First_name, row.Last_name, row.Country, row.Id));
            }
        }

        private void printCategoryList(List<Category> categories)
        {
            foreach (Category row in categories)
            {
                Console.WriteLine(String.Format("Category: {0}\nID: {1}", row.Name, row.Id));
            }
        }
    }
}

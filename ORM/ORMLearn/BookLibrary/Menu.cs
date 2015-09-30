using System;

namespace BookLibrary
{
    class Menu
    {
        private LibraryManager libraryManager;

        public Menu(LibraryManager libManager)
        {
            libraryManager = libManager;
        }

        public void Execute()
        {
            while (true)
            {
                PrintMenu();
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        libraryManager.PrintAllBooks();
                        break;

                    case 2:
                        Console.Clear();
                        libraryManager.PrintAuthors();
                        break;

                    case 3:
                        Console.Clear();
                        libraryManager.PrintCategories();
                        break;

                    case 4:
                        Console.Clear();
                        libraryManager.PrintBooksExpensiveThan();
                        break;

                    case 5:
                        Console.Clear();
                        libraryManager.PrintBookFoundById();
                        break;

                    case 6:
                        Console.Clear();
                        libraryManager.PrintBookFoundByTitle();
                        break;

                    case 7:
                        Console.Clear();
                        libraryManager.PrintBooksOFSelectedCategory();
                        break;

                    case 8:
                        Console.Clear();
                        libraryManager.AddNewBook();
                        break;

                    case 9:
                        Console.Clear();
                        libraryManager.DeleteBook();
                        break;

                    case 10:
                        Console.Clear();
                        libraryManager.AddNewAuthor();
                        break;

                    case 11:
                        Console.Clear();
                        libraryManager.DeleteAuthor();
                        break;

                    case 12:
                        Console.Clear();
                        libraryManager.AddNewCategory();
                        break;

                    case 13:
                        Console.Clear();
                        libraryManager.DeleteCategory();
                        break;

                    case 14:
                        Console.Clear();
                        libraryManager.ModifyBook();
                        break;

                    case 0:
                        return;
                }
                Console.ReadLine();
            }
        }

        private void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("======= LIBRARY MENU =======");
            Console.WriteLine("1) Show all books");
            Console.WriteLine("2) Show all authors");
            Console.WriteLine("3) Show all categories");
            Console.WriteLine("4) Show books more expensive than selected price");
            Console.WriteLine("5) Find Book by ID");
            Console.WriteLine("6) Find Book by Title");
            Console.WriteLine("7) Show books of selected category");
            Console.WriteLine("8) Add new book");
            Console.WriteLine("9) Delete book");
            Console.WriteLine("10) Add new author");
            Console.WriteLine("11) Delete author");
            Console.WriteLine("12) Add new category");
            Console.WriteLine("13) Delete category");
            Console.WriteLine("14) Modify book");
            Console.WriteLine("0) Exit");
            Console.WriteLine("Enter your choice:");
        }
    }
}
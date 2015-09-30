using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryDB library = new LibraryDB();
            LibraryManager libraryManger = new LibraryManager(library);

            Menu menu = new Menu(libraryManger);
            menu.Execute();
        }
    }
}

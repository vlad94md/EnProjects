using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descriptn { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> AuthorId { get; set; }

        public AuthorModel Author { get; set; }
        public CategoryModel Category { get; set; }
    }
}

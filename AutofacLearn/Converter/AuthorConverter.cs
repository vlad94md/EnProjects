using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace Converter
{
    public static class AuthorConverter
    {
        public static AuthorModel ConvertToModel(Author author)
        {
            return new AuthorModel()
            {
                Id = author.Id,
                First_name = author.First_name,
                Last_name = author.Last_name,
                Country = author.Country
            };
        }
    }
}

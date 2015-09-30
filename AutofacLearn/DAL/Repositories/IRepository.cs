using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepository<T>
    {
        ICollection<T> GetList { get; }
        bool Add(T t);
        bool Delete(T t);
    }
}

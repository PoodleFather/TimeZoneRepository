using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZoneRepository.Repository
{
    public interface IRepository<T>
    {
        void Insert(T item);
        void Delete(T item);
        void Update(T item);
        void Save();
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}

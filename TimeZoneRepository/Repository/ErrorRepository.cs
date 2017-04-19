using TimeZoneRepository.Model;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TimeZoneRepository.Repository
{
    public interface IErrorRepository : IRepository<Error> { }

    public class ErrorRepository : IErrorRepository
    {
        public Entities Entity;
        private DbSet<Error> dbSet;

        public ErrorRepository()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Load(Assembly.GetExecutingAssembly());
                Entity = kernel.Get<Entities>();
                dbSet = Entity.Set<Error>();
            }
        }
        public void Delete(Error item)
        {
            dbSet.Remove(item);
        }

        public IEnumerable<Error> GetAll()
        {
            return dbSet;
        }

        public Error GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(Error item)
        {
            dbSet.Add(item);
        }

        public void Save()
        {
            Entity.SaveChanges();
        }

        public void Update(Error item)
        {
            Entity.Entry(item).State = EntityState.Modified;
        }
    }
    public class DummyErrorRepository : IErrorRepository
    {
        private List<Error> DummyList = new List<Error>()
        {
            new Error() { Err_Id = 1,ErrorMessage="DummyError1",ErrorMothod="DummyErrorMothod1"}
            ,new Error() { Err_Id = 2,ErrorMessage="DummyError2",ErrorMothod="DummyErrorMothod2"}
            ,new Error() { Err_Id = 3,ErrorMessage="DummyError3",ErrorMothod="DummyErrorMothod3"}
        };
        public void Delete(Error item)
        {
            DummyList.Remove(item);
        }

        public IEnumerable<Error> GetAll()
        {
            return DummyList;
        }

        public Error GetById(int id)
        {
            return DummyList.Where(w => w.Err_Id == id).FirstOrDefault();
        }

        public void Insert(Error item)
        {
            DummyList.Add(item);
        }

        public void Save()
        {
            return;
        }

        public void Update(Error item)
        {
            return;
        }
    }
}

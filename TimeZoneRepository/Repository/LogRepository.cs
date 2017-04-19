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
    public interface ILogRepository : IRepository<Log> { }

    public class LogRepository : ILogRepository
    {
        public Entities Entity;
        private DbSet<Log> dbSet;

        public LogRepository()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Load(Assembly.GetExecutingAssembly());
                Entity = kernel.Get<Entities>();
                dbSet = Entity.Set<Log>();
            }
        }
        public void Delete(Log item)
        {
            dbSet.Remove(item);
        }

        public IEnumerable<Log> GetAll()
        {
            return dbSet;
        }

        public Log GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(Log item)
        {
            dbSet.Add(item);
        }

        public void Save()
        {
            Entity.SaveChanges();
        }

        public void Update(Log item)
        {
            Entity.Entry(item).State = EntityState.Modified;
        }
    }
    public class DummyLogRepository : ILogRepository
    {
        private List<Log> DummyList = new List<Log>()
        {
            new Log() { Log_Id = 1,UserIP="UserIP1",UserBrowser="UserBrowser1"}
            ,new Log() { Log_Id = 2,UserIP="UserIP2",UserBrowser="UserBrowser2"}
            ,new Log() { Log_Id = 3,UserIP="UserIP3",UserBrowser="UserBrowser3"}
        };
        public void Delete(Log item)
        {
            DummyList.Remove(item);
        }

        public IEnumerable<Log> GetAll()
        {
            return DummyList;
        }

        public Log GetById(int id)
        {
            return DummyList.Where(w => w.Log_Id == id).FirstOrDefault();
        }

        public void Insert(Log item)
        {
            DummyList.Add(item);
        }

        public void Save()
        {
            return;
        }

        public void Update(Log item)
        {
            return;
        }
    }
}

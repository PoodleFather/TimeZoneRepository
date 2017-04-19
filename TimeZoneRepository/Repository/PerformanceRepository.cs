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
    public interface IPerformanceRepository : IRepository<Performance> { }

    public class PerformanceRepository : IPerformanceRepository
    {
        private Entities Entity;
        private DbSet<Performance> dbSet;
        public PerformanceRepository()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Load(Assembly.GetExecutingAssembly());
                Entity = kernel.Get<Entities>();
                dbSet = Entity.Set<Performance>();
            }
        }
        public void Delete(Performance item)
        {
            dbSet.Remove(item);
        }

        public IEnumerable<Performance> GetAll()
        {
            return dbSet;
        }

        public Performance GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(Performance item)
        {
            dbSet.Add(item);
        }

        public void Save()
        {
            Entity.SaveChanges();
        }

        public void Update(Performance item)
        {
            Entity.Entry(item).State = EntityState.Modified;
        }
    }
    public class DummyPerformanceRepository : IPerformanceRepository
    {
        private List<Performance> DummyList = new List<Performance>()
        {
            new Performance() { PF_Id = 1,CurrentMethod="CurrentMethod1",DurationTime=1}
            ,new Performance() { PF_Id = 2,CurrentMethod="CurrentMethod2",DurationTime=2}
            ,new Performance() { PF_Id = 3,CurrentMethod="CurrentMethod3",DurationTime=3}
        };
        public void Delete(Performance item)
        {
            DummyList.Remove(item);
        }

        public IEnumerable<Performance> GetAll()
        {
            return DummyList;
        }

        public Performance GetById(int id)
        {
            return DummyList.Where(w => w.PF_Id == id).FirstOrDefault();
        }

        public void Insert(Performance item)
        {
            DummyList.Add(item);
        }

        public void Save()
        {
            return;
        }

        public void Update(Performance item)
        {
            return;
        }
    }
}

using TimeZoneRepository.Model;
using TimeZoneRepository.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TimeZoneRepository
{
    public interface IUnitOfWork
    {
        Entities db { get; set; }
        ILogRepository LogRepository { get; set; }
        IPerformanceRepository PerformanceRepository { get; set; }
        IErrorRepository ErrorRepository { get; set; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        public Entities db { get; set; }
        public ILogRepository LogRepository { get; set; }
        public IPerformanceRepository PerformanceRepository { get; set; }
        public IErrorRepository ErrorRepository { get; set; }

        public UnitOfWork()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Load(Assembly.GetExecutingAssembly());
                db = kernel.Get<Entities>();
                LogRepository = kernel.Get<LogRepository>();
                PerformanceRepository = kernel.Get<PerformanceRepository>();
                ErrorRepository = kernel.Get<ErrorRepository>();
            }
        }
        public UnitOfWork(ILogRepository logRepositoryParam)
        {
            LogRepository = logRepositoryParam;
        }
        public UnitOfWork(IPerformanceRepository PerformanceRepositoryParam)
        {
            PerformanceRepository = PerformanceRepositoryParam;
        }
        public UnitOfWork(IErrorRepository ErrorRepositoryParam)
        {
            ErrorRepository = ErrorRepositoryParam;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZoneRepository.Model
{
    public class Entities : DbContext
    {
        public Entities() : base("data source=127.0.0.1;initial catalog=HyunWoo;persist security info=True;user id=sa;password=ad!@#0;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }
        public Entities(string ConnectionString) : base(ConnectionString)
        {
        }
        public DbSet<Log> Log { get; set; }
        public DbSet<Performance> Performance { get; set; }
        public DbSet<Error> Error { get; set; }
    }
}

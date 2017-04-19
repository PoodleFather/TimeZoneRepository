using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZoneRepository.Model
{
    [Table("Log")]
    public partial class Log
    {
        [Key]
        public int Log_Id { get; set; }

        [StringLength(50)]
        public string UserIP { get; set; }

        [StringLength(200)]
        public string UserBrowser { get; set; }
    }
}

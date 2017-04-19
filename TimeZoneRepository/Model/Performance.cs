using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZoneRepository.Model
{
    [Table("Performance")]
    public partial class Performance
    {
        [Key]
        public int PF_Id { get; set; }

        [StringLength(50)]
        public string CurrentMethod { get; set; }

        public double? DurationTime { get; set; }
    }
}

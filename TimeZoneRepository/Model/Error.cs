using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZoneRepository.Model
{
    [Table("Error")]
    public partial class Error
    {
        [Key]
        public int Err_Id { get; set; }

        [StringLength(200)]
        public string ErrorMothod { get; set; }

        [StringLength(200)]
        public string ErrorMessage { get; set; }
    }
}

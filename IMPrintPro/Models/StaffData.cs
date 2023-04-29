using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMPrintPro.Models
{
    public class StaffData
    {
        [Key]
        public int StaffId { get; set; }
        public int Transaction { get; set; }
        public int Check { get; set; }
        public string cuton { get; set; }
    }
}

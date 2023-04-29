using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMPrintPro.Models
{
    public class VendorData
    {
        [Key]
        public int VendorID { get; set; }
        public int Transaction { get; set; }
        public int Check { get; set; }
        public string CutOn { get; set; }
        public int PaymentType { get; set; }
    }
}

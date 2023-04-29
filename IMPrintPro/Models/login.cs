using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IMPrintPro.Models
{
    public class login
    {
        [Key]
        public int Id { get; set; }
        public string  UserId { get; set; }

        public string  UserPassword { get; set; }
    }
}

using IMPrintPro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMPrintPro.Data
{
    public class ImprintDataContext:DbContext
    {

        public ImprintDataContext(DbContextOptions<ImprintDataContext> options) : base(options)
        {
            
        }
        
        public DbSet<login> logins { get; set; }

        public DbSet<StaffData> StaffDatas { get; set; }

        public DbSet<VendorData> VendorDatas { get; set; }

         
    }
}

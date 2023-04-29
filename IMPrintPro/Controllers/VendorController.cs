using IMPrintPro.Data;
using IMPrintPro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IMPrintPro.Controllers
{
    [Authorize]
    public class VendorController : Controller
    {

        private readonly ImprintDataContext context;

        public VendorController(ImprintDataContext context)
        {
            this.context = context;
        }

         
        [HttpGet]

        public IActionResult VendorExcel()
        {
            return View();
        }

        [HttpPost]
        public async Task<List<VendorData>> VendorExcel(IFormFile file)
        {
            var list = new List<VendorData>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    var rowcount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowcount; row++)
                    {
                        list.Add(new VendorData
                        {   
                            Transaction = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                            Check = Convert.ToInt32(worksheet.Cells[row, 2].Value),
                             CutOn=worksheet.Cells[row,3].Value.ToString().Trim(),
                            PaymentType=Convert.ToInt32(worksheet.Cells[row,4].Value)
                        });

                    }
                    context.VendorDatas.AddRangeAsync(list);
                    await context.SaveChangesAsync();
                }
            }
            return list;
        }

    }
}

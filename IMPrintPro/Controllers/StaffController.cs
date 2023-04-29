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
    public class StaffController : Controller
    {

        private readonly ImprintDataContext context;

        public StaffController(ImprintDataContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult ImportExcel()
        {
            return View();
        }

        [HttpPost]
        public async Task<List<StaffData>> ImportExcel(IFormFile file)
        {
            var list = new List<StaffData>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    var rowcount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowcount; row++)
                    {
                        list.Add(new StaffData
                        { 
                            Transaction = Convert.ToInt32(worksheet.Cells[row, 1].Value),
                            Check = Convert.ToInt32(worksheet.Cells[row, 2].Value),
                            cuton = worksheet.Cells[row, 3].Value.ToString().Trim()
                        });

                    }
                    context.StaffDatas.AddRangeAsync(list);
                    await context.SaveChangesAsync();
                }
            }
            return list;
        }
    }
}

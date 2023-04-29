using IMPrintPro.Data;
using IMPrintPro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IMPrintPro.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly ImprintDataContext context;
      
        public HomeController(ImprintDataContext context)
        {
            this.context = context;
        }

        /*public IActionResult DisplayData()
        {
            IEnumerable<login> Logins = context.logins;

            return View(Logins);
        }*/


        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        
        public IActionResult Index(login model)
        {
            if (ModelState.IsValid)
            {
                var data = context.logins.Where(x => x.UserId == model.UserId).FirstOrDefault();

                if (data != null)
                {
                    bool isValid = (data.UserId == model.UserId && data.UserPassword == model.UserPassword);

                    if (isValid)
                    {
                        
                        return RedirectToAction("VendorExcel", "Vendor");
                    }
                    else
                    {
                        TempData["errorMessage"] = "Invalid Password";
                        return View(model);
                    }
                }
                else 
                {
                    TempData["errorMessage"] = "Data not found";
                    return View(model);
                }
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

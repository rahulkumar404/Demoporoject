using IMPrintPro.Data;
using IMPrintPro.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IMPrintPro.Controllers
{
    public class ImprintLoginController : Controller
    {
        private readonly ImprintDataContext context;

        public ImprintLoginController(ImprintDataContext context)
        {
            this.context = context;
        }


        public IActionResult SlideMenu()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }


        
        public IActionResult logOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("ImprintLogin", "ImprintLogin");
        }


        [HttpGet]
        public IActionResult ImprintLogin()
        {
            return View();
        }


        [HttpPost]
        public IActionResult ImprintLogin(login model)
        {
            if (ModelState.IsValid)
            {
                var data = context.logins.Where(x => x.UserId == model.UserId).FirstOrDefault();

                if (data != null)
                {
                    bool isValid = (data.UserId == model.UserId && data.UserPassword == model.UserPassword);

                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserId) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var principle = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                        HttpContext.Session.SetString("UserId", model.UserId);

                        return RedirectToAction("ImportExcel", "staff");
                    }
                    else
                    {
                        TempData["errorMessage"] = "Invalid Password!";
                        return View(model);
                    }
                }
                else
                {
                    TempData["errorMessage"] = "Enter Email Id and Password!";
                    return View(model);
                }
            }
            return View();
        }

    }
}

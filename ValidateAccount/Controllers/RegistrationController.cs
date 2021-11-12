using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidateAccount.Data;
using ValidateAccount.Models;

namespace ValidateAccount.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly myDbcontext _dbcontext;
        public RegistrationController(myDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        // Registration view
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        // Post-Registration
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AccountDatails obj)
        {
            var success = await _dbcontext.AccountDatails.Where(a => a.Email.Equals(obj.Email)).FirstOrDefaultAsync();
            if (success == null)
            {
               await _dbcontext.AccountDatails.AddAsync(obj);
                 _dbcontext.SaveChanges();
                return RedirectToAction("RegReply");
            }
            ModelState.AddModelError(string.Empty, "Email Already Used");
            return View(obj);
        }
       
        // Post-Registration view Meaasage4
        public IActionResult RegReply()
        {
            return View();
        }

    }
}

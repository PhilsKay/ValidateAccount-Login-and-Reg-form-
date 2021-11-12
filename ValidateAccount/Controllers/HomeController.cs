using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ValidateAccount.Data;
using ValidateAccount.Models;

namespace ValidateAccount.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly myDbcontext _dbcontext;

        public HomeController(ILogger<HomeController> logger, myDbcontext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }
        // Verify Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AccountDatails obj)
        {
                var success = await _dbcontext.AccountDatails.Where(a => a.UserPass.Equals(obj.UserPass) && a.Email.Equals(obj.Email)).FirstOrDefaultAsync();
                if(success == null)
                {
                 ModelState.AddModelError(string.Empty, "Invalid login Attempt");
                return View(obj);
                }
                return RedirectToAction("Verify");
        }
        // signin successful
        public IActionResult Verify()
        {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SonOfCodSeafood.Models;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SonOfCodSeafood.Controllers
{
    
    public class NewsletterController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public NewsletterController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.EmailList.ToList()); // remove emiallist from return!!!
        }
        [HttpPost]
        public IActionResult AddEmail(string email)
        {
            Debug.WriteLine("hello");
            EmailListMember newMember = new EmailListMember(email);
            _db.Add(newMember);
            _db.SaveChanges();
            return RedirectToAction("Index", "Newsletter");
        }
    }
}

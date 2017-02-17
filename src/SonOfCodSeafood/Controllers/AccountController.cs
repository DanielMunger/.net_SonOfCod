using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SonOfCodSeafood.ViewModels;
using SonOfCodSeafood.Models;
using Microsoft.AspNetCore.Identity;
using System.IO;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SonOfCodSeafood.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public IActionResult Index()
        {
          
            return View();
            
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email)
        {
            

            var user = new ApplicationUser { UserName = email, Email = email};
            IdentityResult result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
               // var user = await _userManager.GetUserAsync(User);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

       // public async Task<IActionResult> UserAccount()
        //{
          //  var user = await _userManager.GetUserAsync(User);
            //string userId = user.Id;
            //var userPhotos = _db.Photos
           //     .Where(photos => photos.User.Id == userId);
            //ViewBag.UserPhotos = userPhotos;
            //return View(user);

       // }
    }
}

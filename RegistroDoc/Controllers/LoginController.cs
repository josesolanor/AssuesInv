using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroDoc.Context;
using RegistroDoc.Core;
using RegistroDoc.Entities;
using RegistroDoc.Models;

namespace RegistroDoc.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly AppDBContext _context;
        private readonly Hash _hash;

        public LoginController(AppDBContext context, Hash hash)
        {
            _context = context;
            _hash = hash; 
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginViewModels model)
        {
            if (ModelState.IsValid)
            {
                model.Input.Password = _hash.EncryptString(model.Input.Password);
                var login = _context.User.Where(m => m.Account == model.Input.Username && m.Password == model.Input.Password).FirstOrDefault();

                if (login is null)
                {

                    model.ErrorMessage = "Credenciales Incorrectas";
                    return View(model);
                }
                var RoleName = _context.Role.FirstOrDefault(m => m.RoleId == login.RoleId).RoleValue;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.Account),
                    new Claim("FullName", $"{login.FirstName} {login.LastName} {login.SecondLastName}"),
                    new Claim("Id", login.UserId.ToString()),
                    new Claim(ClaimTypes.Email, login.Email),
                    new Claim(ClaimTypes.Role, RoleName)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {

                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Inventory");
                
            }
            model.ErrorMessage = "Error al Iniciar";
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Denied()
        {
            return View();
        }
    }
}

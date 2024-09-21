using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using MVCWeek9.Entities;
using MVCWeek9.Models;

namespace MVCWeek9.Controllers;

public class AuthController : Controller
{
    public static List<UserEntity> _users = new List<UserEntity>()
    {
        new UserEntity {Id=1,Email=".",Password=".",PhoneNumber=".",FullName="."} // static user list
    };

    private readonly IDataProtector _dataProtector; // for data protection , Encryption of password 

    public AuthController(IDataProtectionProvider dataProtectionProvider)
    {
        _dataProtector = dataProtectionProvider.CreateProtector("security");
    }

    [HttpGet]
    public IActionResult SignUp() // sign up get method
    {
        return View();
    }    

    [HttpPost]
    public IActionResult SignUp(AuthSignUpViewModel formData) // method of obtaining and processing information from a view  
    {
        if(!ModelState.IsValid) // ıf this is invalid data retun view 
        {
            return View(formData); // formdata go to view . If dont go data all will come data empty
        }

        var user = _users.FirstOrDefault(x => x.Email.ToLower() == formData.Email.ToLower()); // Check if there is a user

        if(user is not null) // same user
        {
            ViewBag.Error = "Kullanıcı mevcut";
            return View(formData);
        }

        var newUser = new UserEntity() // creat new user
        {
            Id = _users.Max(x=> x.Id) +1,
            Email = formData.Email.ToLower(),
            FullName = formData.FullName,
            PhoneNumber = formData.PhoneNumber,
            Password = _dataProtector.Protect(formData.Password)
        };

            _users.Add(newUser); // add user in static list

        return RedirectToAction("SignIn");
    }

    [HttpGet]
    public IActionResult SignIn() // sign in method
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(AuthSignInViewModel formData)
    {

        var user = _users.FirstOrDefault(x=> x.Email.ToLower() == formData.Email.ToLower()); // check email

        if(user is null) // there is not matching user
        {
            ViewBag.Error ="Kullanıcı adı veya şifre hatalı";
            return View(formData); // go back view with data
        }

        var rawPassword = _dataProtector.Unprotect(user.Password); // decoding

        if(rawPassword == formData.Password) // check password
        {
            // Login
            
            var claims = new List<Claim>();

            claims.Add(new Claim("email",user.Email));
            claims.Add(new Claim("id",user.Id.ToString()));

            var claimIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            var autProperties = new AuthenticationProperties
            {
                AllowRefresh = true, // If you refresh the page, the account will remain open.
                ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(48)) // for 48 hours account is login
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity),autProperties);

        }
        else // wrong password
        {
            ViewBag.Error ="Kullanıcı adı veya şifre hatalı";
            return View(formData);            
        }

        return RedirectToAction("List","Book"); // go to bookcontroller list
    }

    public async Task<IActionResult> SignOut() 
    {
        await HttpContext.SignOutAsync();

        return RedirectToAction("Index","Home"); // go to home
    }

}
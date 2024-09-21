using Microsoft.AspNetCore.Authentication.Cookies; // for authentitacation 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // mvc pattern applied

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath = new PathString("/"); 
    options.LogoutPath = new PathString("/");
    options.AccessDeniedPath = new PathString("/");
});

var app = builder.Build();

app.UseAuthentication(); // for authentication 

app.UseStaticFiles(); // use static files boostrap etc.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}"  // default routing home index
);

app.Run();

using LenaTalent.DAL.Abstract;
using LenaTalent.DAL.Concrete;
using LenaTalent.Entities.Context;
using LenaTalent.Entities.Models.Identity;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection
builder.Services.AddDbContext<LenaTalentDbContext>();
builder.Services.AddScoped<IFormDAL, FormDAL>();

//Identity Option and Cookie
builder.Services.AddIdentity<User, Role>(options => 
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
}).AddEntityFrameworkStores<LenaTalentDbContext>().AddDefaultTokenProviders().AddRoles<Role>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";//Giriþ yapýlmadýysa
    options.AccessDeniedPath = "/";//Yetkisi yoksa
    options.Cookie = new CookieBuilder
    {
        Name = "AspNetIdentityExampleCookie",
        HttpOnly = false,
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.Always
    };
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
});

//Add Session
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//Use Session
app.UseSession();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();//Giriþ
app.UseAuthorization();//Yetki (Giriþi Her zaman yetkiden önce yaz)



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

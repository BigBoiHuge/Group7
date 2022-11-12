using HappyCitizens.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

const string context = "ApplicationDbContext";
var builder = WebApplication.CreateBuilder(args);

// use SQLite for development and SQL Server for production
if (builder.Environment.IsDevelopment())
{
    builder.Services
        .AddDbContext<ApplicationDbContext>(options => options.UseSqlite(
            builder.Configuration.GetConnectionString(context)))
        .AddDatabaseDeveloperPageExceptionFilter();
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString($"Production{context}")));
}

builder.Services
    .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

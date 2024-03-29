﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SeniorSolutionsWeb.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
//options.LoginPath = "/Account/Login";
//options.AccessDeniedPath = "/Account/Denied";
//options.LogoutPath = "Account/Logout";
options.Events = new CookieAuthenticationEvents()
  {
        OnSigningIn = async context =>
         {
             await Task.CompletedTask;
         },

        OnSignedIn = async context =>
         {
             await Task.CompletedTask;
         },

        OnValidatePrincipal = async context =>
         {
             await Task.CompletedTask;
         }
   };
});
//Retrieve env db connection info
String connectionString = builder.Configuration.GetConnectionString(builder.Environment.EnvironmentName + "Connection");

builder.Services.AddDbContext<SeniorSolutionsWebContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

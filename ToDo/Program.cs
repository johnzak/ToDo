using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using Repo.Data;
using Repo.Interfaces;
using Services.Interfaces;
using Services.Implementation;
using Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the DbContext
    builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer
(builder.Configuration.GetConnectionString("HisStore")));

// Register repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<Repo.Interfaces.IToDoListRepository, Repo.Data.ToDoListRepository>();
builder.Services.AddTransient<IToDoItemRepository, ToDoItemRepository>();

builder.Services.AddMemoryCache();
builder.Services.AddSession();




builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IToDoListService, ToDoListService>();
builder.Services.AddScoped<IToDoItemService, ToDoItemService>();

builder.Services.AddDistributedMemoryCache();
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
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//buray� kontrol et context dosya tan�m�n hatal�yd� dbcontextin repositorycontext i�inde tan�ml�
//builder.Services.AddDbContext<RepositoryContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
        b => b.MigrationsAssembly("StoreApp")
        );
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "StoreApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Repository servis kay�tlar�
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

//Servis kay�tlar�
builder.Services.AddScoped<IServiceManager,ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();

builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c));

builder.Services.AddAutoMapper(typeof(Program));

//buraya bi bak

////buraya kadar dbcontext tan�mlamaya calistim
//builder.Services.AddDbContext<RepositoryContext>(options =>
//{
//    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
//        b => b.MigrationsAssembly("StoreApp"));
//});

var app = builder.Build();

//static dosyalar�n burada kanka a�lama
app.UseStaticFiles();
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name:"Admin",
        areaName:"Admin",
        pattern:"Admin/{controller=Dashboard}/{action=Index}/{id?}"
        );
    endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});


app.Run();

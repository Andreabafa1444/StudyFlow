using Microsoft.EntityFrameworkCore;
using StudyFlow.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔴 IMPORTANT: fix logging (NO Windows Event Log)
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// ADD MVC SUPPORT
builder.Services.AddControllersWithViews();

// DATABASE
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 🔴 COMMENT THIS FOR NOW (DEV)
// app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

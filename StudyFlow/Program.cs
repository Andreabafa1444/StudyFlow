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
//sesion 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 🔴 COMMENT THIS FOR NOW (DEV)
// app.UseHttpsRedirection();

app.UseRouting();
app.UseSession();


app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

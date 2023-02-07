var builder = WebApplication.CreateBuilder(args);

//Aktivera MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Statiska filer i wwwrot
app.UseStaticFiles();

app.UseRouting();

// Routing
app.MapControllerRoute (
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
);

app.Run();

using StackExchange.Redis;
using MyServer.Services;
using TinyURLService.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Redis Conncect
IConfiguration configuration = builder.Configuration;
var multiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
builder.Services.AddSingleton<IRedisService, RedisServiceImpl>();
builder.Services.AddSingleton<ITinyURLService, TinyURLServiceImpl>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "tinyURL",
    pattern: "tinyurl",
    defaults: new { controller = "TinyURL", action = "Index" });

//app.MapControllerRoute(
//    name: "PasteBin",
//    pattern: "pastebin",
//    defaults: new { controller = "PasteBin", action = "Index" });


app.Run();

using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// ƒобавление сервисов контроллеров и представлений
builder.Services.AddControllersWithViews();

// —ервис сессии
builder.Services.AddDistributedMemoryCache(); // данные по сессии
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ƒобавление Home как сервиса с областью видимости запроса
builder.Services.AddSingleton<Home>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // »нициализаци€ сессии

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

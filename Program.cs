using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// ���������� �������� ������������ � �������������
builder.Services.AddControllersWithViews();

// ������ ������
builder.Services.AddDistributedMemoryCache(); // ������ �� ������
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ���������� Home ��� ������� � �������� ��������� �������
builder.Services.AddSingleton<Home>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // ������������� ������

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

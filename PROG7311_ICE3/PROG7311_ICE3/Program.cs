using PROG7311_ICE3.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Register our services as singletons so cart/orders persist during the session
builder.Services.AddSingleton<ProductRepository>();
builder.Services.AddSingleton<OrderService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shop}/{action=Index}/{id?}");

app.Run();
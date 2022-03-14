using ModalCRUD.Infrastructure; // the  O N L Y  reason why we depend on the Infrastructure Layer here in the Web Layer (UI) is for dependency injection (service registration), and shouldn't be used/referenced anywhere else in the Web Layer (UI)

var builder = WebApplication.CreateBuilder(args);

// Add services to the dependency injetion container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllersWithViews();
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

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


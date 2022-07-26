using ContactList;
using ContactList.Database;
using ContactList.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add services to the container.
//builder.Services.AddRazorPages();


// Register the Swagger generator
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper((config) => { }, AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();

builder.Services.AddDbContext<ContactListContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
{
    config.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<ContactListContext>();

builder.Services.RegisterServices();
builder.Services.RegisterRepositories();
builder.Services.RegisterValidators();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSwaggerUI();

app.UseSwagger(x => x.SerializeAsV2 = true);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

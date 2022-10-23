using Microsoft.EntityFrameworkCore;
using Repository.Database;
using Repository.Repositories.Categorias;
using Repository.Repositories.Livros;
using Service.Services.Categorias;
using Service.Services.Livros;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\moc\\source\\repos\\ProWay.CSharp.AspNetCore5-2022-10-02\\Proway.Projeto00\\Database\\BancoDados.mdf;Integrated Security=True";

builder.Services.AddDbContext<ProjetoContext>(options =>
    options.UseSqlServer(connectionString));

// Dependecy Injection
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ILivroService, LivroService>();

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

app.Run();

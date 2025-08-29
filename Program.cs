using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Projeto_Claro.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//configDb 
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(connectionString)
    );


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    dbContext.Database.Migrate(); // Aplica as migrações automaticamente
}


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
    pattern: "{controller=Ticket}/{action=Index}");
app.Run();




using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Repositories;
using Repository.UnitOfWorks;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Configuration

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Scoped For Depend. Injection
builder.Services.AddScoped<IUnitOFWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));



//AddMigration
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        //Not Type Safe
        //option.MigrationsAssembly("Repository") 
        //Type Scrript Dynamic
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

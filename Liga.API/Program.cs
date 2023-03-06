using Liga.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Se Agrega el .AddJsonOption para evitar todas las redundancias Ciclicas automaticamente
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=DefaultConnection"));

//Para uno de una sola vez en el sistema
builder.Services.AddTransient<SeedDb>();

//Injeccion del SeedBd
var app = builder.Build();
SeedData(app);

async void SeedData(WebApplication app)
{
    IServiceScopeFactory scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (IServiceScope scope = scopedFactory!.CreateScope())
    {
        SeedDb service = scope.ServiceProvider.GetService<SeedDb>();
        await service!.SeedAsync();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Servicio de Cors para que responsa Front Angular, React, Blazor entre otros.
app.UseCors(x => x
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials());

app.MapControllers();

app.Run();

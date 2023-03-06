using CurrieTechnologies.Razor.SweetAlert2;
using Liga.Web;
using Liga.Web.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Lines Modificada
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7256/") });

//Inyeccion de repositorios
builder.Services.AddScoped<IRepository, Repository>();
//Injection Sweet Alert2 para mensajes y alertas
builder.Services.AddSweetAlert2();


await builder.Build().RunAsync();

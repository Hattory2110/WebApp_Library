using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApp_Library.UI;
using WebApp_Library.UI.Services;
using WebApp_Library.UI.Services.Impl;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:8080") });

builder.Services.AddScoped<IReaderService, ReaderServiceImpl>();
builder.Services.AddScoped<IBookService, BookServiceImpl>();
builder.Services.AddScoped<IRentService, RentServiceImpl>();

await builder.Build().RunAsync();
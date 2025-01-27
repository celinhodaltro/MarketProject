using System.AppWeb.Components;
using System.Reflection;
using Microsoft.AspNetCore.Components.WebAssembly.Server;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

System.Injects.Injecter.ExecuteServiceConfigs(builder.Services);

WebApplication app = builder.Build();


app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


var ExternalProjectAssemblies = Assembly.Load("System.Pages");

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(ExternalProjectAssemblies)
    .AddInteractiveWebAssemblyRenderMode();

app.Run();



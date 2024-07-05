
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.BusinessRules;
using System.Provider.Auth;

namespace System.Injects
{
  public class Injecter
  {
    public static void ExecuteInject(IServiceCollection services)
    {

      services.AddCascadingAuthenticationState();
      services.AddScoped<ApplicationDbContext, ApplicationDbContext>();


      InjectBussinessRules(services);
      InjectProvider(services);
    }

    public static void InjectBussinessRules(IServiceCollection services)
    {
      services.AddScoped<AuthenticationStateProvider, AuthBusinessRules>();
      services.AddScoped<AuthBusinessRules, AuthBusinessRules>();
    }

    public static void InjectProvider(IServiceCollection services)
    {
      services.AddScoped<AuthProvider, AuthProvider>();
    }
  }
}


using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mysqlx.Prepare;
using System.BusinessRules;
using System.Provider.Auth;

using Microsoft.AspNetCore.Builder;

namespace System.Injects
{
  public class Injecter
  {


    public static void ExecuteServiceConfigs(IServiceCollection services)
    {


      services.AddAuthentication(options =>
      {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
      }).AddCookie(options =>
      {
        options.Cookie.Name = "YourAppCookieName";
      });

      services.AddCascadingAuthenticationState();
      services.AddScoped<ApplicationDbContext, ApplicationDbContext>();
      services.AddHttpContextAccessor();

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

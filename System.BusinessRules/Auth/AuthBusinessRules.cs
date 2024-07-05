using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using System.Entities;
using System.Provider.Auth;

namespace System.BusinessRules
{
  public class AuthBusinessRules : AuthenticationStateProvider
  {
    private readonly AuthProvider AuthProvider;
    private readonly IHttpContextAccessor HttpContextAccessor;

    public AuthBusinessRules(AuthProvider authProvider, IHttpContextAccessor httpContextAccessor)
    {
      AuthProvider = authProvider;
      HttpContextAccessor = httpContextAccessor;
    }
    public async Task<ClaimsPrincipal> Login(Account account)
    {
      account = await AuthProvider.GetAccount(account);

      if (account != null)
      {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, account.UniqueId.ToString()),
            new Claim(ClaimTypes.Name, account.Login),
            new Claim(ClaimTypes.Email, account.Email),
            new Claim(ClaimTypes.Role, "User")
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var user = new ClaimsPrincipal(identity);

        var authProps = new AuthenticationProperties
        {
          IsPersistent = true // Define se o cookie é persistente ou de sessão
        };

        // Obtém o contexto HTTP usando o HttpContextAccessor
        var httpContext = HttpContextAccessor.HttpContext;

        // Configura o cookie diretamente no contexto de resposta
        httpContext.Response.Cookies.Append(CookieAuthenticationDefaults.CookiePrefix + CookieAuthenticationDefaults.AuthenticationScheme,
            CookieAuthenticationDefaults.CookiePrefix + CookieAuthenticationDefaults.AuthenticationScheme,
            new CookieOptions
            {
              HttpOnly = true,
              Secure = true,
              SameSite = SameSiteMode.None,
              Expires = DateTime.Now.AddHours(1)
            });

        // Realiza o login do usuário
        await httpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            user,
            authProps);

        return user;
      }

      throw new UnauthorizedAccessException("Credenciais inválidas!");
    }



    public async Task Register(Account account)
    {
      if (await AuthProvider.GetAccount(account.Login) != null)
      {
        throw new Exception("This name already exists!");
      }

      await AuthProvider.CreateAccount(account);
    }

    public async Task Logout()
    {
      await HttpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      var claims = new List<Claim>
            {
                new Claim("Chave", "Valor"),
                new Claim(ClaimTypes.Name, "João")
            };

      var identity = new ClaimsIdentity(claims, "demo");
      var user = new ClaimsPrincipal(identity);

      return await Task.FromResult(new AuthenticationState(user));
    }
  }
}

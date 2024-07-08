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
  public class AuthBusinessRules 
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

      if (account is Account)
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


        // Realiza o login do usuário
        await httpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            user,
            authProps);

        return user;
      }
      else
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


  }
}

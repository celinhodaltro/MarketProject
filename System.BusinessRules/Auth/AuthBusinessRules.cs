using System.Entities;
using System.Provider.Auth;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

using Microsoft.AspNetCore.Authorization;

namespace System.BusinessRules;

public class AuthBusinessRules : AuthenticationStateProvider
{
  private readonly AuthProvider AuthProvider;

  public AuthBusinessRules(AuthProvider authProvider)
  {
    AuthProvider = authProvider;
  }

  public async Task<ClaimsPrincipal> Login(Account account)
  {
    if (account.Login == "admin" && account.Password == "admin")
    {
      var identity = new ClaimsIdentity(new[]
      {
                new Claim(ClaimTypes.NameIdentifier, nameof(account.UniqueId)),
                new Claim(ClaimTypes.Name, account.Login),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Role, "Admin") // Exemplo de atribuição de função
            }, "apiauth_type");

      var user = new ClaimsPrincipal(identity);
      return user;
    }

    throw new UnauthorizedAccessException("Invalid credentials!");
  }


  public async Task Register(Account account)
  {
    if (await this.AuthProvider.GetAccount(account.Login) is Account)
      throw new Exception("This name already exists!");


    await this.AuthProvider.CreateAccount(account);

  }

  public async Task Logout()
  {
    var anonymousUser = new ClaimsPrincipal();
  }



  public override async Task<AuthenticationState> GetAuthenticationStateAsync()
  {
    var usuario = new ClaimsIdentity(new List<Claim>()
    {
      new Claim("Chave", "Valor"),
      new Claim(ClaimTypes.Name, "jOÃO"),
    }, "demo");

    return await Task.FromResult(new AuthenticationState(
      new ClaimsPrincipal(usuario)));
  }
}

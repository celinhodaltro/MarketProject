using System.Entities;
using System.Provider.Auth;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

using Microsoft.AspNetCore.Authorization;

public class AuthBusinessRules : AuthenticationStateProvider
{
  private readonly AuthProvider AuthProvider;

  public AuthBusinessRules(AuthProvider authProvider)
  {
    AuthProvider = authProvider;
  }

  public override async Task<AuthenticationState> GetAuthenticationStateAsync()
  {
    var usuario = new ClaimsIdentity();

    return await Task.FromResult(new AuthenticationState(
      new ClaimsPrincipal(usuario)));
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

    throw new UnauthorizedAccessException("Credenciais inválidas");
  }

  public async Task Logout()
  {
    var anonymousUser = new ClaimsPrincipal();
  }
}

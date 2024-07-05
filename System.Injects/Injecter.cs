
using Microsoft.Extensions.DependencyInjection;

namespace System.Injects
{
  public class Injecter
  {
    public static void ExecuteInject(IServiceCollection services)
    {
      InjectBussinessRules(services);
      InjectProvider(services);
    }

    public static void InjectBussinessRules(IServiceCollection services)
    {

    }

    public static void InjectProvider(IServiceCollection services)
    {

    }
  }
}

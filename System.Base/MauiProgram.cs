using Microsoft.Extensions.Logging;

namespace System.Base
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            System.Injects.Injecter.ExecuteServiceConfigs(builder.Services);
            builder.Services.AddMauiBlazorWebView();

            #if DEBUG
    		    builder.Services.AddBlazorWebViewDeveloperTools();
    		    builder.Logging.AddDebug();
            #endif
            return builder.Build();
        }
    }
}

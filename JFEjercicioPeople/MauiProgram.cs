using Microsoft.Extensions.Logging;

namespace JFEjercicioPeople
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            string dbPath = JFFileAccessHelper.GetLocalFilePath("people.db3");
            builder.Services.AddSingleton<JFPersonRepository>(s => ActivatorUtilities.CreateInstance<JFPersonRepository>(s, dbPath));
#endif

            return builder.Build();
        }
    }
}

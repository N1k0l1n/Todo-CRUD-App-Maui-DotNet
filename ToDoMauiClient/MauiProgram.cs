using ToDoMauiClient.DataServices;
using ToDoMauiClient.Pages;

namespace ToDoMauiClient
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

            builder.Services.AddSingleton<IRestDataService, RestDataService>();

            //Register Main Page
            builder.Services.AddSingleton<MainPage>();
            //Register Manage Todos Page (AddTransient beacause its displayed on/off)
            builder.Services.AddTransient<ManageToDoPage>();

            return builder.Build();
        }
    }
}
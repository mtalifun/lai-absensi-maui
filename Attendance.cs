using LaiAbsensi.Services;
namespace LaiAbsensi;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();
        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddSingleton<TimeService>();
        return builder.Build();
    }
}
namespace LaiAbsensi;
public static class MauiProgram
{
    public const string FIREBASE_API_KEY = "AIzaSyD1psUVL5VUkkNJ89DrieUCkSoy2tkxChg";
    public const string FIREBASE_DB_URL = "https://lampiongroupapp-default-rtdb.firebaseio.com";
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();
        return builder.Build();
    }
}

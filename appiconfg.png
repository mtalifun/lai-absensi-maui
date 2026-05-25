using LaiAbsensi.Services;
using System.Text;
namespace LaiAbsensi.Pages;
public partial class SettingsPage : ContentPage
{
    DatabaseService db;
    public SettingsPage(DatabaseService database){ InitializeComponent(); db=database; lblInfo.Text = $"App v1.1 • User: {Preferences.Get("user_name","")}"; }
    async void OnExport(object sender, EventArgs e)
    {
        var data = await db.GetHistory(Preferences.Get("user_id",0));
        var sb = new StringBuilder(); sb.AppendLine("Type,ServerTime,Lat,Lon,Accuracy,IsMock");
        foreach(var d in data) sb.AppendLine($"{d.Type},{d.ServerTime:O},{d.Latitude},{d.Longitude},{d.Accuracy},{d.IsMock}");
        var path = Path.Combine(FileSystem.CacheDirectory, "riwayat.csv");
        File.WriteAllText(path, sb.ToString());
        await Share.RequestAsync(new ShareFileRequest{ Title="Export CSV", File = new ShareFile(path)});
    }
    async void OnClear(object sender, EventArgs e){ if(await DisplayAlert("Hapus","Yakin hapus semua data?","Ya","Tidak")){ Preferences.Clear(); await DisplayAlert("Selesai","Silakan login ulang","OK"); await Shell.Current.GoToAsync("login"); } }
    async void OnLogout(object sender, EventArgs e){ Preferences.Clear(); await Shell.Current.GoToAsync("login"); }
}
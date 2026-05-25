using LaiAbsensi.Models;
using LaiAbsensi.Services;
namespace LaiAbsensi.Pages;
public partial class AbsenPage : ContentPage
{
    DatabaseService db; TimeService time;
    public AbsenPage(DatabaseService database, TimeService t){ InitializeComponent(); db=database; time=t; }
    protected override void OnAppearing(){ base.OnAppearing(); var id=Preferences.Get("user_id",0); if(id==0){ Shell.Current.GoToAsync("login"); return; } lblWelcome.Text = $"Halo, {Preferences.Get("user_name","")}"; }
    async void OnIn(object sender, EventArgs e)=> await DoAbsen("IN");
    async void OnOut(object sender, EventArgs e)=> await DoAbsen("OUT");
    async Task DoAbsen(string type)
    {
        try
        {
            lblStatus.Text = "Mengambil GPS...";
            var loc = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(20)));
            if(loc==null){ await DisplayAlert("Error","GPS tidak aktif","OK"); return; }
            bool isMock = false;
#if ANDROID
            isMock = loc.IsFromMockProvider;
#endif
            if(isMock){ await DisplayAlert("DITOLAK","Fake GPS terdeteksi!","OK"); return; }

            lblStatus.Text = "Mengambil waktu server...";
            var serverTime = await time.GetNetworkTime();
            var deviceTime = DateTime.Now;
            if(!time.IsTimeValid(serverTime, deviceTime)){ await DisplayAlert("DITOLAK",$"Waktu HP tidak sesuai server.
Selisih >2 menit","OK"); return; }

            lblStatus.Text = "Ambil foto selfie...";
            var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions{ Title = $"Selfie {type}"});
            if(photo==null) return;
            var photoPath = Path.Combine(FileSystem.CacheDirectory, $"{type}_{DateTime.Now:yyyyMMddHHmmss}.jpg");
            using var stream = await photo.OpenReadAsync();
            using var fs = File.OpenWrite(photoPath); await stream.CopyToAsync(fs);

            var att = new Attendance{
                UserId = Preferences.Get("user_id",0),
                Type = type,
                ServerTime = serverTime,
                DeviceTime = deviceTime,
                Latitude = loc.Latitude,
                Longitude = loc.Longitude,
                Accuracy = loc.Accuracy ?? 0,
                IsMock = isMock,
                PhotoPath = photoPath,
                Note = $"Akurasi {loc.Accuracy:F0}m"
            };
            await db.SaveAttendance(att);
            lblStatus.Text = $"{type} BERHASIL
{serverTime:HH:mm:ss dd MMM}
Lat:{loc.Latitude:F5} Lon:{loc.Longitude:F5}";
            await DisplayAlert("Sukses",$"{type} tersimpan offline","OK");
        }
        catch(Exception ex){ await DisplayAlert("Error",ex.Message,"OK"); }
    }
}
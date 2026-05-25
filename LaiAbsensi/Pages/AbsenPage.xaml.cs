using LaiAbsensi.Models;
using LaiAbsensi.Services;

namespace LaiAbsensi.Pages;

public partial class AbsenPage : ContentPage
{
    private readonly ApiService _api = new();
    private readonly LocalDb _db = new();
    private Location? _lastLocation;

    public AbsenPage()
    {
        InitializeComponent();
        LoadUser();
        _ = GetLocation();
    }

    private void LoadUser()
    {
        var user = Preferences.Get("user_name", "Karyawan");
        lblWelcome.Text = $"Halo, {user}";
    }

    private async Task GetLocation()
    {
        try
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted)
                _lastLocation = await Geolocation.Default.GetLocationAsync();
        }
        catch { }
    }

    private async void OnMasukClicked(object sender, EventArgs e) => await DoAbsen("masuk");
    private async void OnPulangClicked(object sender, EventArgs e) => await DoAbsen("pulang");

    private async Task DoAbsen(string tipe)
    {
        btnMasuk.IsEnabled = false;
        btnPulang.IsEnabled = false;
        lblStatus.Text = "Mengambil lokasi...";

        await GetLocation();
        if (_lastLocation == null)
        {
            await DisplayAlert("Gagal", "Lokasi tidak didapat. Aktifkan GPS.", "OK");
            ResetButtons();
            return;
        }

        var att = new Attendance
        {
            Type = tipe,
            Timestamp = DateTime.Now,
            Latitude = _lastLocation.Latitude,
            Longitude = _lastLocation.Longitude,
            Synced = false
        };

        await _db.SaveAttendance(att);
        lblStatus.Text = $"{tipe.ToUpper()} tersimpan";

        var userId = Preferences.Get("user_id", 0);
        if (await _api.SendAttendance(userId, att))
        {
            att.Synced = true;
            await _db.SaveAttendance(att);
            lblStatus.Text = $"{tipe.ToUpper()} berhasil";
        }

        ResetButtons();
    }

    private void ResetButtons()
    {
        btnMasuk.IsEnabled = true;
        btnPulang.IsEnabled = true;
    }
}
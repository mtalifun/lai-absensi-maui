using LaiAbsensi.Models;
using LaiAbsensi.Services;

namespace LaiAbsensi.Pages;

public partial class AbsenPage : ContentPage
{
    private readonly ApiService _api = new();
    private readonly LocalDb _db = new();
    private User? _user;

    public AbsenPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var email = Preferences.Get("user_email", "");
        _user = await _api.Login(email, "");
        lblWelcome.Text = $"Halo, {_user?.Name}";
    }

    async void OnMasukClicked(object sender, EventArgs e) => await DoAbsen("Masuk");
    async void OnPulangClicked(object sender, EventArgs e) => await DoAbsen("Pulang");

    async Task DoAbsen(string type)
    {
        btnMasuk.IsEnabled = false;
        btnPulang.IsEnabled = false;
        lblStatus.Text = "Mengambil lokasi...";

        try
        {
            var loc = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));
            var att = new Attendance
            {
                Type = type,
                Timestamp = DateTime.Now,
                Latitude = loc?.Latitude ?? 0,
                Longitude = loc?.Longitude ?? 0,
                Synced = false
            };
            await _db.SaveAttendance(att);
            await _api.SendAttendance(_user?.Id ?? 0, att);
            lblStatus.Text = $"{type} berhasil {att.Timestamp:t}";
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Gagal: {ex.Message}";
        }
        finally
        {
            btnMasuk.IsEnabled = true;
            btnPulang.IsEnabled = true;
        }
    }
}
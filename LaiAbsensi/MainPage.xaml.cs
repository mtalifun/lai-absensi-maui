using System.Net.Http.Json;
using System.Text.Json;

namespace LaiAbsensi;

public partial class MainPage : ContentPage
{
    private string idToken = "";
    private string localId = "";
    private readonly HttpClient http = new();

    public MainPage()
    {
        InitializeComponent();
    }

    async void OnRegister(object sender, EventArgs e) => await Auth(true);
    async void OnLogin(object sender, EventArgs e) => await Auth(false);

    async Task Auth(bool isRegister)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                await DisplayAlert("Error", "Isi email dan password", "OK");
                return;
            }

            var url = $"https://identitytoolkit.googleapis.com/v1/accounts:{(isRegister ? "signUp" : "signInWithPassword")}?key={MauiProgram.FIREBASE_API_KEY}";
            
            var res = await http.PostAsJsonAsync(url, new { 
                email = txtEmail.Text, 
                password = txtPass.Text, 
                returnSecureToken = true 
            });
            
            var json = await res.Content.ReadAsStringAsync();
            
            if (!res.IsSuccessStatusCode) 
            { 
                await DisplayAlert("Gagal", "Email sudah dipakai atau password <6 karakter", "OK"); 
                return; 
            }
            
            var doc = JsonDocument.Parse(json);
            idToken = doc.RootElement.GetProperty("idToken").GetString()!;
            localId = doc.RootElement.GetProperty("localId").GetString()!;
            
            loginFrame.IsVisible = false;
            appFrame.IsVisible = true;
            lblUser.Text = txtEmail.Text;
            lblStatus.Text = "Login berhasil - siap absen";
        }
        catch (Exception ex) 
        { 
            await DisplayAlert("Error", ex.Message, "OK"); 
        }
    }

    async void OnClockIn(object sender, EventArgs e) => await Absen("clockIn");
    async void OnClockOut(object sender, EventArgs e) => await Absen("clockOut");

    async Task Absen(string type)
    {
        try
        {
            // 1. Ambil foto
            var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions { Title = "Foto Absensi" });
            if (photo == null) return;

            byte[] bytes;
            using (var stream = await photo.OpenReadAsync())
            using (var ms = new MemoryStream())
            {
                await stream.CopyToAsync(ms);
                bytes = ms.ToArray();
            }
            var base64 = Convert.ToBase64String(bytes);

            // 2. Ambil lokasi
            await DisplayAlert("GPS", "Mengambil lokasi...", "OK");
            var loc = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10)));
            
            // 3. Simpan ke Firebase
            var today = DateTime.Now.ToString("yyyy-MM-dd");
            var payload = new { 
                time = DateTime.Now.ToString("HH:mm:ss"), 
                lat = loc?.Latitude ?? 0, 
                lng = loc?.Longitude ?? 0, 
                photo = base64.Substring(0, Math.Min(8000, base64.Length)) // potong biar ga berat
            };
            
            var url = $"{MauiProgram.FIREBASE_DB_URL}/attendance/{localId}/{today}/{type}.json?auth={idToken}";
            var res = await http.PutAsJsonAsync(url, payload);
            
            lblStatus.Text = $"{type.ToUpper()} berhasil jam {DateTime.Now:HH:mm}";
            await DisplayAlert("Sukses", $"{type} tersimpan di Firebase", "OK");
        }
        catch (Exception ex) 
        { 
            await DisplayAlert("Gagal Absen", ex.Message + "\n\nPastikan izin Kamera & Lokasi diaktifkan", "OK"); 
        }
    }

    void OnLogout(object sender, EventArgs e)
    {
        idToken = "";
        localId = "";
        txtPass.Text = "";
        appFrame.IsVisible = false;
        loginFrame.IsVisible = true;
    }
}

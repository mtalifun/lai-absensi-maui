using LaiAbsensi.Services;

namespace LaiAbsensi.Pages;

public partial class LoginPage : ContentPage
{
    private readonly ApiService _api = new();

    public LoginPage()
    {
        InitializeComponent();
    }

    async void OnLogin(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
        {
            await DisplayAlert("Error", "Isi email dan password", "OK");
            return;
        }

        var user = await _api.Login(txtEmail.Text, txtPass.Text);
        if (user == null)
        {
            await DisplayAlert("Gagal", "Email atau password salah", "OK");
            return;
        }

        Preferences.Set("user_id", user.Id);
        Preferences.Set("user_name", user.Name);
        await Shell.Current.GoToAsync("//absen");
    }

    async void OnRegister(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text) || 
            string.IsNullOrWhiteSpace(txtEmail.Text) || 
            string.IsNullOrWhiteSpace(txtPass.Text))
        {
            await DisplayAlert("Isi", "Lengkapi nama, email, password", "OK");
            return;
        }

        var user = await _api.Register(txtName.Text, txtEmail.Text, txtPass.Text);
        if (user == null)
        {
            await DisplayAlert("Gagal", "Email sudah terdaftar", "OK");
            return;
        }

        Preferences.Set("user_id", user.Id);
        Preferences.Set("user_name", user.Name);
        await Shell.Current.GoToAsync("//absen");
    }
}
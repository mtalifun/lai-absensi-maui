using LaiAbsensi.Services;
namespace LaiAbsensi.Pages;
public partial class LoginPage : ContentPage
{
    DatabaseService db;
    public LoginPage(DatabaseService database){ InitializeComponent(); db = database; }
    async void OnLogin(object sender, EventArgs e)
    {
        var user = await db.Login(txtEmail.Text, txtPass.Text);
        if(user==null){ await DisplayAlert("Gagal","Email/password salah","OK"); return; }
        Preferences.Set("user_id", user.Id); Preferences.Set("user_name", user.Name);
        await Shell.Current.GoToAsync("//absen");
    }
    async void OnRegister(object sender, EventArgs e)
    {
        if(string.IsNullOrWhiteSpace(txtName.Text)){ await DisplayAlert("Isi","Nama dulu","OK"); return; }
        var user = await db.Register(txtEmail.Text, txtPass.Text, txtName.Text);
        Preferences.Set("user_id", user.Id); Preferences.Set("user_name", user.Name);
        await Shell.Current.GoToAsync("//absen");
    }
}
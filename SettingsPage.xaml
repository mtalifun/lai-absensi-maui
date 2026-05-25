using LaiAbsensi.Services;
namespace LaiAbsensi.Pages;
public partial class HistoryPage : ContentPage
{
    DatabaseService db;
    public HistoryPage(DatabaseService database){ InitializeComponent(); db = database; }
    protected override async void OnAppearing(){ base.OnAppearing(); var id = Preferences.Get("user_id",0); list.ItemsSource = await db.GetHistory(id); }
}
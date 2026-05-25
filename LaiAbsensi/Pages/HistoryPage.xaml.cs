using LaiAbsensi.Services;

namespace LaiAbsensi.Pages;

public partial class HistoryPage : ContentPage
{
    private readonly LocalDb _db = new();

    public HistoryPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var data = await _db.GetHistory();
        historyList.ItemsSource = data;
    }
}
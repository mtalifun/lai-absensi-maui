<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="LaiAbsensi.Pages.HistoryPage" Title="Riwayat">
    <CollectionView x:Name="list" Margin="10">
        <CollectionView.ItemTemplate>
            <DataTemplate>
                <Frame Margin="5" Padding="10" CornerRadius="10">
                    <VerticalStackLayout>
                        <Label Text="{Binding Type}" FontAttributes="Bold" TextColor="{StaticResource Primary}"/>
                        <Label Text="{Binding ServerTime, StringFormat='{0:dd MMM yyyy HH:mm}'}"/>
                        <Label Text="{Binding Note}" FontSize="12" TextColor="Gray"/>
                    </VerticalStackLayout>
                </Frame>
            </DataTemplate>
        </CollectionView.ItemTemplate>
    </CollectionView>
</ContentPage>
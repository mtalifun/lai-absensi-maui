<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="LaiAbsensi.Pages.AbsenPage" Title="Absen">
    <ScrollView>
    <VerticalStackLayout Padding="20" Spacing="12">
        <Label x:Name="lblWelcome" FontSize="20" FontAttributes="Bold"/>
        <Frame BackgroundColor="#ffedd5" Padding="10" CornerRadius="12">
            <Label x:Name="lblStatus" Text="Siap absen" HorizontalTextAlignment="Center"/>
        </Frame>
        <Grid ColumnDefinitions="*,*" ColumnSpacing="10">
            <Button Grid.Column="0" Text="CLOCK IN" Clicked="OnIn" BackgroundColor="#16a34a" TextColor="White" HeightRequest="60"/>
            <Button Grid.Column="1" Text="CLOCK OUT" Clicked="OnOut" BackgroundColor="#dc2626" TextColor="White" HeightRequest="60"/>
        </Grid>
        <Label Text="Anti Fake GPS • Waktu Server • Foto Selfie • Simpan Offline" FontSize="12" TextColor="Gray" HorizontalTextAlignment="Center"/>
    </VerticalStackLayout>
    </ScrollView>
</ContentPage>
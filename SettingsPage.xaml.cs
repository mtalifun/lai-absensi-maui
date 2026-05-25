<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="LaiAbsensi.Pages.LoginPage" BackgroundColor="#fff7ed">
    <VerticalStackLayout Padding="30" Spacing="15" VerticalOptions="Center">
        <Image Source="leaf_logo.png" HeightRequest="100"/>
        <Label Text="LAI Absensi Pro" FontSize="28" FontAttributes="Bold" HorizontalOptions="Center" TextColor="#ea580c"/>
        <Entry x:Name="txtEmail" Placeholder="Email" Keyboard="Email"/>
        <Entry x:Name="txtPass" Placeholder="Password" IsPassword="True"/>
        <Entry x:Name="txtName" Placeholder="Nama (untuk daftar)" />
        <Button Text="Login" Clicked="OnLogin" BackgroundColor="#ea580c" TextColor="White"/>
        <Button Text="Daftar" Clicked="OnRegister" BackgroundColor="#64748b" TextColor="White"/>
    </VerticalStackLayout>
</ContentPage>
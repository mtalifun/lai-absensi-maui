<?xml version="1.0" encoding="UTF-8" ?>
<Shell xmlns="http://schemas.microsoft.com/dotnet/2021/maui" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="LaiAbsensi.AppShell" Shell.FlyoutBehavior="Disabled">
    <TabBar>
        <ShellContent Title="Absen" Icon="home.png" ContentTemplate="{DataTemplate local:Pages.AbsenPage}" Route="absen"/>
        <ShellContent Title="Riwayat" Icon="list.png" ContentTemplate="{DataTemplate local:Pages.HistoryPage}" Route="history"/>
        <ShellContent Title="Setting" Icon="settings.png" ContentTemplate="{DataTemplate local:Pages.SettingsPage}" Route="settings"/>
    </TabBar>
</Shell>
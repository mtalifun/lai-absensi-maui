<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>net9.0-android</TargetFrameworks>
    <OutputType>Exe</OutputType>
    <UseMaui>true</UseMaui>
    <SingleProject>true</SingleProject>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <ApplicationTitle>LAI Absensi Pro</ApplicationTitle>
    <ApplicationId>com.lampiongroup.laiabsensi</ApplicationId>
    <ApplicationDisplayVersion>1.1</ApplicationDisplayVersion>
    <ApplicationVersion>2</ApplicationVersion>
    <SkipValidateMauiImplicitPackageReferences>true</SkipValidateMauiImplicitPackageReferences>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.Maui.Controls" Version="9.0.0" />
    <PackageReference Include="Microsoft.Maui.Essentials" Version="9.0.0" />
    <PackageReference Include="sqlite-net-pcl" Version="1.9.172" />
    <PackageReference Include="SQLitePCLRaw.bundle_green" Version="2.1.11" />
  </ItemGroup>
  <ItemGroup>
    <MauiIcon Include="Resources\AppIconppicon.svg" ForegroundFile="Resources\AppIconppiconfg.png" Color="#FF6B00" />
    <MauiImage Include="Resources\Images\*" />
    <MauiFont Include="Resources\Fonts\*" />
  </ItemGroup>
</Project>
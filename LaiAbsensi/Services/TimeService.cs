using System.Net.Http;
using System.Text.Json;
namespace LaiAbsensi.Services;
public class TimeService
{
    public async Task<DateTime> GetNetworkTime()
    {
        try
        {
            using var client = new HttpClient{Timeout=TimeSpan.FromSeconds(5)};
            var json = await client.GetStringAsync("http://worldtimeapi.org/api/timezone/Asia/Jakarta");
            var dt = JsonDocument.Parse(json).RootElement.GetProperty("datetime").GetString();
            return DateTime.Parse(dt!).ToLocalTime();
        }
        catch { return DateTime.Now; }
    }
    public bool IsTimeValid(DateTime server, DateTime device) => Math.Abs((server - device).TotalMinutes) < 2;
}
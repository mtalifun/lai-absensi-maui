using SQLite;

namespace LaiAbsensi.Models;

public class Attendance
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Type { get; set; } = "";
    public DateTime Timestamp { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool Synced { get; set; }
}
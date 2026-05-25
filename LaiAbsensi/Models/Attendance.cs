using SQLite;
namespace LaiAbsensi.Models;
public class Attendance
{
    [PrimaryKey, AutoIncrement] public int Id { get; set; }
    public int UserId { get; set; }
    public string Type { get; set; } // IN / OUT
    public DateTime ServerTime { get; set; }
    public DateTime DeviceTime { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Accuracy { get; set; }
    public bool IsMock { get; set; }
    public string PhotoPath { get; set; }
    public string Note { get; set; }
    public bool Synced { get; set; }
}
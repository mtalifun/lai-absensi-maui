using LaiAbsensi.Models;
namespace LaiAbsensi.Services;
public class ApiService
{
    public async Task<User?> Login(string email, string password)
    {
        await Task.Delay(200);
        return new User { Id = 1, Name = email.Split('@')[0], Email = email };
    }
    public async Task<User?> Register(string name, string email, string password)
    {
        await Task.Delay(200);
        return new User { Id = 2, Name = name, Email = email };
    }
    public async Task<bool> SendAttendance(int userId, Attendance att)
    {
        await Task.Delay(200);
        return true;
    }
}
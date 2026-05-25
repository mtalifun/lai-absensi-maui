using SQLite;
using LaiAbsensi.Models;
namespace LaiAbsensi.Services;
public class DatabaseService
{
    SQLiteAsyncConnection db;
    async Task Init()
    {
        if(db != null) return;
        var path = Path.Combine(FileSystem.AppDataDirectory, "lai.db3");
        db = new SQLiteAsyncConnection(path);
        await db.CreateTableAsync<User>();
        await db.CreateTableAsync<Attendance>();
    }
    public async Task<User> Login(string email, string pass)
    {
        await Init();
        var hash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(pass));
        return await db.Table<User>().FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == hash);
    }
    public async Task<User> Register(string email, string pass, string name)
    {
        await Init();
        var user = new User{Email=email, PasswordHash=Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(pass)), Name=name};
        await db.InsertAsync(user);
        return user;
    }
    public async Task SaveAttendance(Attendance a){ await Init(); await db.InsertAsync(a); }
    public async Task<List<Attendance>> GetHistory(int userId){ await Init(); return await db.Table<Attendance>().Where(x=>x.UserId==userId).OrderByDescending(x=>x.ServerTime).ToListAsync(); }
}
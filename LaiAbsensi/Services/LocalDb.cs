using SQLite;
using LaiAbsensi.Models;

namespace LaiAbsensi.Services;

public class LocalDb
{
    SQLiteAsyncConnection? _db;
    async Task Init()
    {
        if (_db != null) return;
        var path = Path.Combine(FileSystem.AppDataDirectory, "lai.db");
        _db = new SQLiteAsyncConnection(path);
        await _db.CreateTableAsync<Attendance>();
    }
    public async Task SaveAttendance(Attendance a)
    {
        await Init();
        await _db!.InsertOrReplaceAsync(a);
    }
    public async Task<List<Attendance>> GetHistory()
    {
        await Init();
        return await _db!.Table<Attendance>().OrderByDescending(x => x.Timestamp).ToListAsync();
    }
}
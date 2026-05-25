using SQLite;
using LaiAbsensi.Models;

namespace LaiAbsensi.Services;

public class LocalDb
{
    SQLiteAsyncConnection? _db;
    async Task Init()
    {
        if (_db!= null) return;
        var path = Path.Combine(FileSystem.AppDataDirectory, "lai.db");
        _db = new SQLiteAsyncConnection(path);
        await _db.CreateTableAsync<Attendance>();
    }
    public async Task SaveAttendance(Attendance a)
    {
        await Init();
        await _db!.InsertOrReplaceAsync(a);
    }
}
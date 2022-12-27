using SQLite;
using System.IO;

namespace Challenge.Mobile.Infrastructure
{
    public sealed class Sqlite
    {
        private static SQLiteConnection _connection;

        public static SQLiteConnection ConnectionDB => _connection is SQLiteConnection ? _connection : GetConnection();

        private static SQLiteConnection GetConnection()
        {
            var dbase = "SBI_DB";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            _connection = new SQLiteConnection(path);
            return _connection;
        }
    }
}
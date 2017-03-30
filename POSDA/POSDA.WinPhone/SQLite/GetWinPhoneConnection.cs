using POSDA.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using POSDA.GlobalVar;
using Windows.Storage;
using SQLite.Net.Platform.WinRT;
using POSDA.WinPhone.SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(GetWinPhoneConnection))]
namespace POSDA.WinPhone.SQLite
{
    public class GetWinPhoneConnection : ISQLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            string dbPath = ApplicationData.Current.LocalFolder.Path;

            var path = System.IO.Path.Combine(dbPath, GlobalDegisken.localDbName);
            var platform = new SQLitePlatformWinRT();

            var connection = new SQLiteConnection(platform, path);

            return connection;
        }
    }
}

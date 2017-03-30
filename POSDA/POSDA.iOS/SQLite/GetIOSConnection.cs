using POSDA.GlobalVar;
using POSDA.iOS.SQLite;
using POSDA.Methods;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using System;


[assembly : Xamarin.Forms.Dependency(typeof(GetIOSConnection))]
namespace POSDA.iOS.SQLite
{
    public class GetIOSConnection : ISQLiteConnection
    {
        public SQLiteConnection GetConnection()
        {

            string dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var path = System.IO.Path.Combine(dbPath, GlobalDegisken.localDbName);
            var platform = new SQLitePlatformIOS();

            var connection = new SQLiteConnection(platform, path);

            return connection;

        }
    }
}
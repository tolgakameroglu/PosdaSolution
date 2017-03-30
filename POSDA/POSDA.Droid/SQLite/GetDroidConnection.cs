using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using POSDA.Methods;
using POSDA.GlobalVar;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using POSDA.Droid.SQLite;

[assembly : Xamarin.Forms.Dependency(typeof(GetDroidConnection))]
namespace POSDA.Droid.SQLite
{
    public class GetDroidConnection : ISQLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            string dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
             
            var path = System.IO.Path.Combine(dbPath, GlobalDegisken.localDbName);
            var platform = new SQLitePlatformAndroid();

            var connection = new SQLiteConnection(platform,path);

            return connection;
        }
    }
}
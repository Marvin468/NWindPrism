using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NWindPrism.Services;
using SQLite;

namespace NWindPrism.Droid.Services
{
    public class SQLiteConnectionProvider : ISQLiteConnectionProvider
    {
        private SQLiteConnection Connection { get; set; }
        public SQLiteConnection GetConnection()
        {
            if (this.Connection != null) { return this.Connection; }
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "marvin2.db3");
            return Connection = new SQLiteConnection(path);
        }
    }
}
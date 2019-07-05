using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using NWindPrism.Services;
using SQLite;
using UIKit;

namespace NWindPrism.iOS.Services
{
    public class SQLiteConnectionProvider : ISQLiteConnectionProvider
    {
        private SQLiteConnection Connection { get; set; }
        public SQLiteConnection GetConnection()
        {
            if (Connection != null) { return this.Connection; }
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "..", "Library", "marvin.db3");
            return Connection = new SQLiteConnection(path);
        }
    }
}
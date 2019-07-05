using System;
using System.Collections.Generic;
using System.Text;
using NWindPrism.Model;
using SQLite;

namespace NWindPrism.Services
{
    public class BatFamilyService : IBatFamilyService
    {
        private ISQLiteConnectionProvider ConnectionProvider { get; }
        private SQLiteConnection Connection { get; }

        public BatFamilyService(ISQLiteConnectionProvider connectionProvider)
        {
            ConnectionProvider = connectionProvider;
            Connection = ConnectionProvider.GetConnection();
            Connection.CreateTable<BatFamily>();

        }
        public void Delete(int id)
        {
            Connection.Delete<BatFamily>(id);
        }

        public IEnumerable<BatFamily> GetAll()
        {
            return Connection.Table<BatFamily>().ToList();
        }

        public BatFamily GetById(int id)
        {
            return Connection.Table<BatFamily>().FirstOrDefault(x => x.Id == id);
        }

        public void Insert(BatFamily todoItem)
        {
            Connection.Insert(todoItem);
        }

        public void Update(BatFamily todoItem)
        {
            Connection.Update(todoItem);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NWindPrism.Model;
using SQLite;

namespace NWindPrism.Services
{
    public class BatFamilyService : IBatFamilyService
    {
        private ISQLiteConnectionProvider ConnectionProvider { get; }
        private SQLiteAsyncConnection Connection { get; }

        public BatFamilyService(ISQLiteConnectionProvider connectionProvider)
        {
            ConnectionProvider = connectionProvider;
            Connection = ConnectionProvider.GetConnection();
            Connection.CreateTableAsync<BatFamily>();
        }

        public async Task<IEnumerable<BatFamily>> GetAllAsync()
        {
            await Connection.CreateTableAsync<BatFamily>();
            return await Connection.Table<BatFamily>().ToListAsync();
        }

        public async Task<BatFamily> GetByIdAsync(int id)
        {
            await Connection.CreateTableAsync<BatFamily>();
            return await Connection.Table<BatFamily>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(BatFamily BatParent)
        {
            await Connection.CreateTableAsync<BatFamily>();
            await Connection.UpdateAsync(BatParent);
        }

        public async Task InsertAsync(BatFamily BatParent)
        {
            await Connection.CreateTableAsync<BatFamily>();
            await Connection.InsertAsync(BatParent);
        }

        public async Task DeleteAsync(BatFamily id)
        {
            await Connection.CreateTableAsync<BatFamily>();
            await Connection.DeleteAsync(id);
        }
        //public void Delete(int id)
        //{
        //    Connection.Delete<BatFamily>(id);
        //}

        //public IEnumerable<BatFamily> GetAll()
        //{
        //    return Connection.Table<BatFamily>().ToList();
        //}

        //public BatFamily GetById(int id)
        //{
        //    return Connection.Table<BatFamily>().FirstOrDefault(x => x.Id == id);
        //}

        //public void Insert(BatFamily todoItem)
        //{
        //    Connection.Insert(todoItem);
        //}

        //public void Update(BatFamily todoItem)
        //{
        //    Connection.Update(todoItem);
        //}
    }
}

using NWindPrism.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NWindPrism.Services
{
    public interface IBatFamilyService
    {
        //IEnumerable<BatFamily> GetAll();
        //BatFamily GetById(int id);
        //void Update(BatFamily BatParent);
        //void Insert(BatFamily BatParent);
        //void Delete(int id);
        Task<IEnumerable<BatFamily>> GetAllAsync();
        Task<BatFamily> GetByIdAsync(int id);
        Task UpdateAsync(BatFamily BatParent);
        Task InsertAsync(BatFamily BatParent);
        Task DeleteAsync(BatFamily id);
    }
}

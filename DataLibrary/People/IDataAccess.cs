using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary
{
    public interface IDataAccess
    {
        Task<List<T>> Load<T, U>(string sql, U parameters, string connectionString);
        Task Save<T>(string sql, T parameters, string connectionString);
    }
}
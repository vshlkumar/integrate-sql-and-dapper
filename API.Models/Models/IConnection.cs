using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace API.Models.Models
{
    public interface IConnection
    {
        OracleConnection GetOracleConnection(string connectionString, bool open = true);
        IDbConnection GetSqlConnection(string connectionString, bool open = true);
    }
}

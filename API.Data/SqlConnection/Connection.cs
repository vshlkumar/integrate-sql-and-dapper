using API.Models.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.SqlClient;

namespace API.Data.SqlConnection
{
    public class Connection : IConnection
    {
        /// <summary>
        /// Gets ADO.NET based OracleConnection Object to allow Command object and handle LONG types.
        /// </summary>
        /// <param name="connectionString">The connectionString.</param>
        /// <param name="open"> whether to open the connection</param>
        /// <returns></returns>
        public OracleConnection GetOracleConnection(string connectionString, bool open = true)
        {
            var oracleConnection = new OracleConnection(connectionString);
            if (oracleConnection == null)
                throw new DataException($"The oracle provider cannot create a new connection");

            oracleConnection.ConnectionString = connectionString;
            if (open) oracleConnection.Open();
            return oracleConnection;
        }

        /// <summary>
        /// Gets an open connection to the database specified by the connection string.
        /// </summary>
        /// <param name="connectionString">The connectionString.</param>
        /// <param name="open">Whether to return a open connection or not, by default the connection will be open</param>
        /// <returns>IDbConnection</returns>
        public IDbConnection GetSqlConnection(string connectionString, bool open = true)
        {
            var dbConnection = SqlClientFactory.Instance.CreateConnection();
            if (dbConnection == null)
                throw new DataException($"The sql provider cannot create a new connection");

            dbConnection.ConnectionString = connectionString;
            if (open) dbConnection.Open();
            return dbConnection;
        }
    }
}

using Questao5.Infrastructure.Sqlite;
using System.Data;
using System.Data.SQLite;

namespace Questao5.Infrastructure.Database
{
    internal class ConnectionDB
    {
        private IDbConnection _dbConnection;

        public IDbConnection ConnectionOpen()
        {
            var databaseConfig = new DatabaseConfig(){ Name = "Data Source=database.sqlite" };
            _dbConnection = new SQLiteConnection(databaseConfig.Name);
            _dbConnection.Open();

            return _dbConnection;
        }
    }
}

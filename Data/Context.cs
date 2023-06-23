using MySqlConnector;
using System.Data;

namespace CEP_HTTP_REQUEST.Data
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Database");
        }
        public IDbConnection CreateConnection()
            => new MySqlConnection(_connectionString);
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepositoryContract;

namespace Repository
{
	public class DapperContext : IDapperContext
	{
		public readonly IConfiguration _configuration;
		private readonly string _connectionString;

		public DapperContext(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("UserDB");
		}

		public IDbConnection createConnection() => new SqlConnection(_connectionString);
	}
}

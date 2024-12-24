using RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Common;
using System.Dynamic;
using System.Data;
using System.Net;
using Model;
using Dapper;

namespace Repository
{
	public class UserRepository : IUserRepository

	{
		private readonly DapperContext _dapperContext;
		public UserRepository( DapperContext dapperContext)
		{
			_dapperContext = dapperContext;

		}

		public async Task<ResponseViewModel> getByIdUser(int id)
		{
			var procedureName = Common.Constant.getByIdUser;
			var parameters = new DynamicParameters();
			parameters.Add("@UserID", id, DbType.Int64);

			using (var connection = _dapperContext.createConnection())
			{
				var result = await connection.QueryAsync<User>(procedureName, parameters, commandType: CommandType.StoredProcedure);
				var getByIdUser = new ResponseViewModel
				{
					statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
					Message = result.Count() == 0 ? "Data Not Found" : "Data Found",
					Data = result
				};
				return getByIdUser;

			}	
		}

		public async Task<ResponseViewModel> getAllUser()
		{
			var procedureName = Common.Constant.getAllUser;

			using(var  connection = _dapperContext.createConnection())
			{
				var result = await connection.QueryAsync<User>(procedureName,null, commandType: CommandType.StoredProcedure);
				var getAllUser = new ResponseViewModel
				{
					statusCode = result.Count() == 0 ? (int)HttpStatusCode.NotFound : (int)HttpStatusCode.OK,
					Message = result.Count() == 0 ? "Data Not Found" : " Data Found",
					Data = result
				};
				return getAllUser;
			}
		}

		public async Task<ResponseViewModel> addUser(AddUserViewModel addUserViewModel)
		{
			var procedureName = Common.Constant.addUser;

			var parameters = new DynamicParameters();
			parameters.Add("@UserName",addUserViewModel.userName,DbType.String);
			parameters.Add("@Password",addUserViewModel.password,DbType.String);	
			parameters.Add("@Email",addUserViewModel.email,DbType.String);

			using (var connection = _dapperContext.createConnection())
			{
				var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName,parameters,commandType: CommandType.StoredProcedure);	
				if(result.statusCode == 0)
				{
					result.statusCode = (int)HttpStatusCode.OK;
					var createUser = new
					{
						id = (int)result.Data,
						userName = addUserViewModel.userName

					};
					result.Data = createUser;
				}
				else
				{
					result.statusCode = (int)HttpStatusCode.ExpectationFailed;
				}
				return result;
			}
		}

		public async Task<ResponseViewModel> updateUser(UpdateUserViewModel updateUserViewModel)
		{
			var procedureName = Common.Constant.updateUser;

			var parameters = new DynamicParameters();
			parameters.Add("@UserID",updateUserViewModel.userID,DbType.Int32);
			parameters.Add("@UserName",updateUserViewModel.UserName,DbType.String);
			parameters.Add("@Password",updateUserViewModel.password,DbType.String);
			parameters.Add("@Email",updateUserViewModel.email,DbType.String);

			using (var connection = _dapperContext.createConnection())
			{
				var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters,commandType: CommandType.StoredProcedure);	
				if(result.statusCode == 0)
				{
					result.statusCode = (int)HttpStatusCode.OK;
				}
				else
				{
					result.statusCode  = (int)HttpStatusCode.ExpectationFailed;
				}
				return result;
			}
		}

		public async Task<ResponseViewModel> deleteUser(DeleteUserViewModel deleteUserViewModel)
		{
			var procedureName = Common.Constant.deleteUser;

			var parameters = new DynamicParameters();
			parameters.Add("@UserID", deleteUserViewModel.userID, DbType.Int32);
			using(var  connection = _dapperContext.createConnection())
			{
				var result = await connection.QueryFirstOrDefaultAsync<ResponseViewModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);	
				if( result.statusCode == 0)
				{
					result.statusCode = (int)HttpStatusCode.OK;
				}
				else
				{
					result.statusCode = ( int)HttpStatusCode.ExpectationFailed;
				}
				return result;
			}
		}

		
	}
}

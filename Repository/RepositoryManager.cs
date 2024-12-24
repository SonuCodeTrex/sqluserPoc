using RepositoryContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly DapperContext _dapperContext;
		private readonly Lazy<IUserRepository> _userRepository;
		public RepositoryManager(DapperContext dapperContext)
		{
			_dapperContext = dapperContext;
			_userRepository = new Lazy<IUserRepository> (()=> new UserRepository(_dapperContext));
		}

		public IUserRepository UserRepository => _userRepository.Value;


			
		
	}
}

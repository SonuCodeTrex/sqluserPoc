using RepositoryContract;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public sealed class ServiceManager : IServiceManager
	{
		private readonly Lazy<IUserContract> _userContract;

		public ServiceManager(IRepositoryManager repositoryManager)
		{
			_userContract = new Lazy<IUserContract>(() => new UserService(repositoryManager));
		}

		public IUserContract UserContract => _userContract.Value;
	}
}

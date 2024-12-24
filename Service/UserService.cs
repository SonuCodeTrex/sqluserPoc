using RepositoryContract;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Service
{
	public class UserService : IUserContract
	{
		private readonly IRepositoryManager _repositoryManager;

		public UserService(IRepositoryManager repositoryManager)
		{
			_repositoryManager = repositoryManager;

		}

		public async Task<ResponseViewModel> getByIdUser(int id)
		{
			var getByIdUser = await _repositoryManager.UserRepository.getByIdUser(id);
			return getByIdUser;
		}

		public async Task<ResponseViewModel> getAllUser()
		{
			var getAllUser = await _repositoryManager.UserRepository.getAllUser();
			return getAllUser;
		}

		public async Task<ResponseViewModel> addUser(AddUserViewModel addUserViewModel)
		{
			var addUser = await _repositoryManager.UserRepository.addUser(addUserViewModel);
			return addUser;
		}

		public async Task<ResponseViewModel> updateUser(UpdateUserViewModel updateUserViewModel)
		{
			var updateUser = await _repositoryManager.UserRepository.updateUser(updateUserViewModel);
			return updateUser;
		}

		public async Task<ResponseViewModel> deleteUser(DeleteUserViewModel deleteUserViewModel)
		{
			var deleteUser = await _repositoryManager.UserRepository.deleteUser(deleteUserViewModel);
			return deleteUser;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace RepositoryContract
{
	public interface IUserRepository
	{
		public Task<ResponseViewModel> getByIdUser(int id);
		public Task<ResponseViewModel> getAllUser();
		public Task<ResponseViewModel> addUser(AddUserViewModel addUserViewModel);
		public Task<ResponseViewModel> updateUser(UpdateUserViewModel updateUserViewModel);
		public Task<ResponseViewModel> deleteUser(DeleteUserViewModel deleteUserViewModel);

	}
}
	
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContract;
using LoggerService;
using SqlUser.Utils;
using System.Net;
using ViewModel;


namespace SqlUser.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IServiceManager _serveciManager;
		private readonly ILoggerManager _logger;
		public UsersController(IServiceManager serviceManager, ILoggerManager logger)
		{
			_serveciManager = serviceManager;
			_logger = logger;

		}
		[HttpGet("getByIdUser/{UserID}")]
		public async Task<IActionResult> getByIdUser(int UserID)
		{
			_logger.logInfo($"{LoggingEvents.getByIdItem} getByIdUser UserID ${UserID}");
			var getByIdUser = await _serveciManager.UserContract.getByIdUser(UserID);
			if(getByIdUser.statusCode == (int)HttpStatusCode.NotFound)
			{
				_logger.logWarn($"{LoggingEvents.getItemNotFound},No User Found");
			}
			return Ok(getByIdUser);
		}

		[HttpGet("getAllUser")]
		public async Task<IActionResult> getAllUser()
		{
			_logger.logInfo($" {LoggingEvents.getAllItem} getAllItem");
			var getAllUser = await _serveciManager.UserContract.getAllUser();
			if(getAllUser.statusCode == (int)HttpStatusCode.NotFound)
			{
				_logger.logWarn($"{LoggingEvents.getAllItem}, No User Found");
			}
			return Ok(getAllUser);
		}

		[HttpPost("addUser")]
		public async Task<IActionResult> addUser(AddUserViewModel addUserViewModel)
		{
			_logger.logWarn($" {LoggingEvents.addItem} addItem");
			var addUser = await _serveciManager.UserContract.addUser(addUserViewModel);
			return Ok(addUser);
		}

		[HttpPost("updateUser")]
		public async Task<IActionResult> updateUser(UpdateUserViewModel updateUserViewModel)
		{
			_logger.logWarn($"{LoggingEvents.updateItem} updateItem ");
			var updateUser = await _serveciManager.UserContract.updateUser(updateUserViewModel);
			return Ok(updateUser);
		}

		[HttpPost("deleteUser")]
		public async Task<IActionResult> deleteUser(DeleteUserViewModel deleteUserViewModel)
		{
			_logger.logWarn($"{LoggingEvents.deleteItem} deleteItem");
			var deleteUser = await _serveciManager.UserContract.deleteUser(deleteUserViewModel);
			return Ok(deleteUser);
		}


	}
}

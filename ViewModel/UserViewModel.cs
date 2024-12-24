using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
	
	
		public class AddUserViewModel
		{

		[Required]
		public string userName { get; set; }
		[Required]
		public string password { get; set; }
		[Required]
		public string email { get; set; }
		
		}

		public class UpdateUserViewModel
		{
			[Required]
			public int userID { get; set; }
			[Required]
			public string UserName { get; set; }
			[Required]
			public string password { get; set; }
			[Required]
			public string email { get; set; }

		}

		public class DeleteUserViewModel
		{
			[Required]
			public int userID { get; set; }

		}


	
}

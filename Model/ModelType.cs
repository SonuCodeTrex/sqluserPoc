using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public record User(int UserID, string UserName, string Email, DateTime CreatedAt, DateTime UpdatedAt);
}

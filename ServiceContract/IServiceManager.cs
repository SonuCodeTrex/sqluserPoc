﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{
	public interface IServiceManager
	{
		IUserContract UserContract { get; }
	}
}
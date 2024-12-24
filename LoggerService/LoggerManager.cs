﻿using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoggerService
{
	public class LoggerManager : ILoggerManager
	{
		public LoggerManager()
		{

		}
		public void logInfo(string message) => Log.Information(message);
		public void logWarn(string message) => Log.Warning(message);
		public void logDebug(string message) => Log.Debug(message);

		public void logError(string message,Exception ex) => Log.Error(message,ex);

		
	}
}

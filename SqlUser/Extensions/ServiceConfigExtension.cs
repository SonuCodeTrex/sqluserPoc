
using Repository;
using RepositoryContract;
using ServiceContract;
using Service;
using LoggerService;

namespace SqlUser.Extensions
{
	public static class ServiceConfigExtension
	{
		public static void addDapperContext(this IServiceCollection services)
		{
			services.AddSingleton<DapperContext>();
		}

		public static void ConfigureRepositoryManager(this IServiceCollection service)
		{
			service.AddScoped<IRepositoryManager, RepositoryManager>();
		}

		public static void ConfigureServiceManager(this IServiceCollection service)
		{
			service.AddScoped<IServiceManager, ServiceManager>();
		}

		public static void ConfigureLoggerService(this IServiceCollection service)
		{
			service.AddScoped<ILoggerManager, LoggerManager>();	
		}
	}
}

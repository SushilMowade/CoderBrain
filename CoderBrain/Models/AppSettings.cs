using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoderBrain.Models
{
	public static class AppSettings
	{
		public static IConfiguration AppSetting { get; }
		static AppSettings()
		{
			AppSetting = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json")
					.Build();
		}
	}
}

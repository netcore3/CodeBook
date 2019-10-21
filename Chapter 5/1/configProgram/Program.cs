using System;
using System.IO;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration.Json;

namespace ConfigProgram
{
	class Program
	{
		
		static void Main(string[] args)
		{
			var conf = new ConfigurationBuilder()
				 .SetBasePath(Directory.GetCurrentDirectory())
				 .AddJsonFile("appsettings.json", true, true)
				 .Build();

					
			Console.WriteLine($"Hello Mr {conf["firstname"]} {conf["lastname"]}");

			Console.ReadKey();
		}
	}
}

using System;


namespace ConsoleApp
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World of test!");
			
		}

		public static bool isPair(int n)
		{
			int y = n ^ (n >> 1);
			y = y ^ (y >> 2);
			y = y ^ (y >> 4);
			y = y ^ (y >> 8);
			y = y ^ (y >> 16);

			if ((y & 1) > 0) return true;
			return false;
		}
	}
}

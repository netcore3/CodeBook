using System;
using System.Collections.Generic;
using System.Text;

namespace consoleFormApp
{
	public static class nativeCalls
	{
		public static string DisplayOSNameWin()
		{
			return "OS System: Windows.";
		}
		public static string DisplayOSNameLinux()
		{
			return "OS System: Linux";
		}
		public static string DisplayOSNameMac()
		{
			return "OS System: macOS";
		}
	}
}

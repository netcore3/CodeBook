using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace consoleFormApp
{
	public static class nativeFacade
	{
		public static string displayOSName()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				return nativeCalls.DisplayOSNameMac();
			}
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				return nativeCalls.DisplayOSNameWin();
			}
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				return nativeCalls.DisplayOSNameLinux();
			}
			return "OS System Unknown";
		}
	}
}

using System.IO;

namespace consoleTextEditor
{
	public static class FileOperation
	{



		public static string openRead(string filename)
		{
			string t = "";
			if (File.Exists(filename))
			{
				if (filename != null)
					t = File.ReadAllText(filename);
			}
			return t;
		}

		public static void saveFile(string fileContent, string filename)
		{

			if (filename != null)
			{
				using (StreamWriter outputFile = new StreamWriter(filename))
				{
					outputFile.Write(fileContent);
				}
			}


		}

		

	}
}

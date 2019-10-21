using System;
using System.Text;
using Terminal.Gui;

namespace consoleTextEditor
{
	public static class Gui
	{
		public static string currentOpenedPath = "";

		//Main Screen 
		public static void mainScreen()
		{
			Application.Init();
			var top = Application.Top;

			var tframe = top.Frame;
			var ntop = new Toplevel(tframe);


			//Editor Window****************************************************
			string fname = null;

			var win = new Window(fname ?? "Untitled")
			{
				X = 0,
				Y = 1,
				Width = Dim.Fill(),
				Height = Dim.Fill()
			};
			ntop.Add(win);

			fname = @"



                '##::: ##:'########:'########:::::'######:::'#######::'########::'########:::::'#######::
                 ###:: ##: ##.....::... ##..:::::'##... ##:'##.... ##: ##.... ##: ##.....:::::'##.... ##:
                 ####: ##: ##:::::::::: ##::::::: ##:::..:: ##:::: ##: ##:::: ##: ##::::::::::..::::: ##:
                 ## ## ##: ######:::::: ##::::::: ##::::::: ##:::: ##: ########:: ######:::::::'#######::
                 ##. ####: ##...::::::: ##::::::: ##::::::: ##:::: ##: ##.. ##::: ##...::::::::...... ##:
                 ##:. ###: ##:::::::::: ##::::::: ##::: ##: ##:::: ##: ##::. ##:: ##::::::::::'##:::: ##:
                 ##::. ##: ########:::: ##:::::::. ######::. #######:: ##:::. ##: ########::::. #######::
                 ..::::..::........:::::..:::::::::......::::.......:::..:::::..::........::::::.......:::";

			var text = new TextView(new Rect(0, 0, tframe.Width - 2, tframe.Height - 3));
			text.Text = fname;
			win.Add(text);

			//Menu***************************************************
			var menu = new MenuBar(new MenuBarItem[] {
			new MenuBarItem ("_File", new MenuItem [] {
				new MenuItem ("_New", "", () => NewFile(top,ntop)),
				new MenuItem ("_Open", "", () => openFileWindow(top,ntop)),
				new MenuItem ("_Exit", "", () =>{if (Quit ()) Application.RequestStop(); }),
			}),
			  new MenuBarItem ("About", new MenuItem [] {
				new MenuItem ("A_bout", "", About)
			}),
			});
			ntop.Add(menu);
			//end Menu*********************************************************

			//End editor window*****************************************************************
			Application.Run(ntop);

		}

		public static void NewFile(Toplevel top, Toplevel ntop)
		{
			var o = new OpenDialog("New File", "Create file");

			Application.Run(o);
			if (o.FilePath != "")
			{
				string filePath = o.DirectoryPath.ToString() + "\\" + o.FilePath.ToString();

				string fileContent = "";

				FileOperation.saveFile(fileContent, filePath);
				currentOpenedPath = filePath;


				var tframe = top.Frame;
				var win = new Window(o.FilePath ?? "Untitled")
				{
					X = 0,
					Y = 1,
					Width = Dim.Fill(),
					Height = Dim.Fill()
				};


				var text = new TextView(new Rect(0, 0, tframe.Width - 2, tframe.Height - 3));
				text.Text = fileContent;
				win.Add(text);

				ntop.Clear();
				//Menu***************************************************
				displayMenu(top, ntop, text);
				//end Menu*********************************************************

				ntop.Add(win);

				Application.Run(ntop);
			}

		}

		public static void openFileWindow(Toplevel top, Toplevel ntop)
		{
			var o = new OpenDialog("Open", "Open a file");
			//o.MouseEvent mouseEvent;

			Application.Run(o);

			if (o.FilePath != "")
			{
				string filePath = o.DirectoryPath.ToString() + "\\" + o.FilePath.ToString();
				string fileContent = FileOperation.openRead(filePath);

				var tframe = top.Frame;

				currentOpenedPath = filePath;

				var win = new Window(o.FilePath ?? "Untitled")
				{
					X = 0,
					Y = 1,
					Width = Dim.Fill(),
					Height = Dim.Fill()
				};


				var text = new TextView(new Rect(0, 0, tframe.Width - 2, tframe.Height - 3));
				text.Text = fileContent;

				win.Add(text);
				ntop.Clear();

				//Menu***************************************************
				displayMenu(top, ntop, text);
				//end Menu*********************************************************

				ntop.Add(win);

				Application.Run(ntop);
			}

		}

		public static void saveFileWindow(TextView txt)
		{
			var n = MessageBox.Query(60, 7, " Save File", "Are you sure you want to save the file in TextEditor?", "Yes", "No");

			if (n == 0) //true
			{
				string filePath = currentOpenedPath;
				FileOperation.saveFile(txt.Text.ToString(), filePath);
			}
		}


		public static bool Quit()
		{
			var n = MessageBox.Query(50, 7, "Quit TextEditor", "Are you sure you want to quit this TextEditor?", "Yes", "No");
			return n == 0;
		}

		public static void About()
		{
			MessageBox.Query(50, 7, "About", "NETCore3 TextEditor 2019", "Ok");
		}

		public static void displayMenu(Toplevel top, Toplevel ntop, TextView v)
		{
			var menu = new MenuBar(new MenuBarItem[] {
			new MenuBarItem ("_File", new MenuItem [] {
				new MenuItem ("_New", "", () => NewFile(top,ntop)),
				new MenuItem ("_Open", "", () => openFileWindow(top,ntop)),
				new MenuItem ("_Save", "",  () =>saveFileWindow(v)),
				new MenuItem ("_Exit", "", () =>{if (Quit ()) Application.RequestStop(); }),
			}),
			  new MenuBarItem ("About", new MenuItem [] {
				new MenuItem ("A_bout", "", About)
			}),
			});
			ntop.Clear();
			ntop.Add(menu);
		}
	}
}

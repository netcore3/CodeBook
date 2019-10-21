using System;
using Terminal.Gui;

    
    
namespace consoleFormApp {
 
	class Program {

		static void Main(string[] args)
		{
			//Console.WriteLine("Hello World!");
			Application.Init();

			Terminal.Gui.Attribute foc = Terminal.Gui.Attribute.Make(Color.Black, Color.Green);
			Terminal.Gui.Attribute hfoc = Terminal.Gui.Attribute.Make(Color.Black, Color.BrightGreen);
			Terminal.Gui.Attribute nor = Terminal.Gui.Attribute.Make(Color.Green, Color.Black);
			Terminal.Gui.Attribute hnor = Terminal.Gui.Attribute.Make(Color.BrightGreen, Color.Black);

			var classicTerminal = new ColorScheme();
			classicTerminal.Focus = foc;
			classicTerminal.HotFocus = hfoc;
			classicTerminal.Normal = nor;
			classicTerminal.HotNormal = hnor;



			var menu = new MenuBar(new MenuBarItem[] {
				new MenuBarItem ("_File", new MenuItem [] {
					new MenuItem ("_Quit", "", () => { Application.RequestStop (); })
				}),
			});


			var win = new Window("Controls TerminalUI")
			{
				X = 0,
				Y = 1,
				Width = Dim.Percent(50),
				Height = Dim.Fill()
			};

			var win2 = new Window("Display ASCII")
			{
				X = Pos.Right(win),
				Y = 1,
				Width = Dim.Fill(),
				Height = Dim.Fill()
			};
			win2.ColorScheme = classicTerminal;

			var login = new Label("Label: ") { X = 2, Y = 2 };
			var Textinput = new TextField("input")
			{
				X = Pos.Right(login),
				Y = Pos.Top(login),
				Width = 10
			};
			var push = new Button(2, 4, "Button");

			var radio = new RadioGroup(3, 6, new[] { "Option 1", "Option 2" });

			var check = new CheckBox(3, 9, "Sample Check box.");

			var group = new FrameView(new Rect(3, 10, 25, 6), "Group"){
				new CheckBox (1, 0, "Remember me"),
				new RadioGroup (1, 2, new [] { "_Personal", "_Company" }),
			};

			var list = new ListView(new Rect(3, 16, 16, 6), new string[] {
				"First row",
				"Second",
				"3",
				"4th",
				"5",
				"Whoa",
				"This is so cool"
			});

			var progress = new ProgressBar(new Rect(68, 1, 10, 1));

			win.Add(login, Textinput, push, radio, check, group, list, progress);

			//left Window
			var text = new TextView() {
				X = 0,
				Y = 0,
				Width = Dim.Fill(),
				Height = Dim.Fill()
		        };
			text.Text = @"  _____              _           _  _   _ ___ 
 |_   _|__ _ _ _ __ (_)_ _  __ _| || | | |_ _|
   | |/ -_) '_| '  \| | ' \/ _` | || |_| || | 
   |_|\___|_| |_|_|_|_|_||_\__,_|_(_)___/|___|

";
			text.Text += "  " + nativeFacade.displayOSName();
			win2.Add(text);

			Application.Top.Add (menu);

			Application.Top.Add(win);
		    Application.Top.Add(win2);

			Application.Run();

	}
    }
}

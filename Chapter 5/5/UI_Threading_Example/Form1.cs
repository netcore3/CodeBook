using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace UI_Threading_Example
{
    public delegate void workerFunctionDelegate(int totalSeconds);
	public delegate void populateTextBoxDelegate(string text);

    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }

        void populateTextBox(string text)
        {
            textBox1.Text = textBox1.Text + " " + text;
        }
        
        void workerFunction(int totalSeconds)
        {
            for (int count = 1; count <= totalSeconds ; count++)
            {
                this.Invoke(new populateTextBoxDelegate(populateTextBox), new object[] { count.ToString() });
                Thread.Sleep(500);
            }

        }

		private void buttonNewThread_Click(object sender, EventArgs e)
        {
			//good
			workerFunctionDelegate w = workerFunction;
			
			Task.Run(() => w.Invoke(11));
		}

        private void buttonCurrentThread_Click(object sender, EventArgs e)
        {
			//Not good
            workerFunction(10);
        }
                
    }
}

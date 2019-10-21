namespace UI_Threading_Example
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonNewThread = new System.Windows.Forms.Button();
            this.buttonCurrentThread = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonNewThread
            // 
            this.buttonNewThread.Location = new System.Drawing.Point(12, 38);
            this.buttonNewThread.Name = "buttonNewThread";
            this.buttonNewThread.Size = new System.Drawing.Size(217, 23);
            this.buttonNewThread.TabIndex = 0;
            this.buttonNewThread.Text = "Launch worker in new thread (good)";
            this.buttonNewThread.UseVisualStyleBackColor = true;
            this.buttonNewThread.Click += new System.EventHandler(this.buttonNewThread_Click);
            // 
            // buttonCurrentThread
            // 
            this.buttonCurrentThread.Location = new System.Drawing.Point(12, 65);
            this.buttonCurrentThread.Name = "buttonCurrentThread";
            this.buttonCurrentThread.Size = new System.Drawing.Size(217, 23);
            this.buttonCurrentThread.TabIndex = 1;
            this.buttonCurrentThread.Text = "Launch worker in current thread (bad)";
            this.buttonCurrentThread.UseVisualStyleBackColor = true;
            this.buttonCurrentThread.Click += new System.EventHandler(this.buttonCurrentThread_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 20);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 94);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonCurrentThread);
            this.Controls.Add(this.buttonNewThread);
            this.Name = "Form1";
            this.Text = "UI Threading Example";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNewThread;
        private System.Windows.Forms.Button buttonCurrentThread;
        private System.Windows.Forms.TextBox textBox1;
    }
}


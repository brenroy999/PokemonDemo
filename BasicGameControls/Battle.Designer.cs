namespace BasicGameControls
{
    partial class Battle
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
			this.components = new System.ComponentModel.Container();
			this.gameTimer = new System.Windows.Forms.Timer(this.components);
			this.heroBar = new System.Windows.Forms.ProgressBar();
			this.foeBar = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// gameTimer
			// 
			this.gameTimer.Enabled = true;
			this.gameTimer.Interval = 150;
			this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
			// 
			// heroBar
			// 
			this.heroBar.Location = new System.Drawing.Point(176, 91);
			this.heroBar.Name = "heroBar";
			this.heroBar.Size = new System.Drawing.Size(48, 3);
			this.heroBar.TabIndex = 1;
			this.heroBar.Value = 100;
			// 
			// foeBar
			// 
			this.foeBar.Location = new System.Drawing.Point(53, 32);
			this.foeBar.Name = "foeBar";
			this.foeBar.Size = new System.Drawing.Size(48, 3);
			this.foeBar.TabIndex = 2;
			this.foeBar.Value = 100;
			// 
			// Battle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::BasicGameControls.Properties.Resources.grass;
			this.ClientSize = new System.Drawing.Size(240, 160);
			this.Controls.Add(this.foeBar);
			this.Controls.Add(this.heroBar);
			this.DoubleBuffered = true;
			this.Name = "Battle";
			this.Text = "Battle";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Battle_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Battle_KeyDown);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
		private System.Windows.Forms.ProgressBar heroBar;
		private System.Windows.Forms.ProgressBar foeBar;
	}
}
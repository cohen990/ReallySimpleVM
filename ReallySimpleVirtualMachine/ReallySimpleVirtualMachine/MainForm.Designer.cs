namespace ReallySimpleVirtualMachine
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.msMainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlRegisters = new System.Windows.Forms.Panel();
            this.lblRegisters = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.speedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mS14SecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mS12SecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mS1SecondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mS2SecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mS3SecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mS4SecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mS5SecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realTimeNoDelayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reallySimpleScreen1 = new ReallySimpleVirtualMachine.ReallySimpleScreen();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.pnlRegisters.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMainMenu,
            this.pauseToolStripMenuItem,
            this.resumeToolStripMenuItem,
            this.restartToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(644, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // msMainMenu
            // 
            this.msMainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.speedToolStripMenuItem});
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(37, 20);
            this.msMainMenu.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // pnlRegisters
            // 
            this.pnlRegisters.Controls.Add(this.lblRegisters);
            this.pnlRegisters.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRegisters.Location = new System.Drawing.Point(0, 301);
            this.pnlRegisters.Name = "pnlRegisters";
            this.pnlRegisters.Size = new System.Drawing.Size(644, 54);
            this.pnlRegisters.TabIndex = 2;
            // 
            // lblRegisters
            // 
            this.lblRegisters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRegisters.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisters.Location = new System.Drawing.Point(0, 0);
            this.lblRegisters.Name = "lblRegisters";
            this.lblRegisters.Size = new System.Drawing.Size(644, 54);
            this.lblRegisters.TabIndex = 0;
            this.lblRegisters.Text = "label1";
            this.lblRegisters.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "B32";
            this.openFileDialog1.Filter = "B32 Files | *.B32";
            // 
            // speedToolStripMenuItem
            // 
            this.speedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mS14SecondToolStripMenuItem,
            this.mS12SecondToolStripMenuItem,
            this.mS1SecondToolStripMenuItem,
            this.mS2SecondsToolStripMenuItem,
            this.mS3SecondsToolStripMenuItem,
            this.mS4SecondsToolStripMenuItem,
            this.mS5SecondsToolStripMenuItem,
            this.realTimeNoDelayToolStripMenuItem});
            this.speedToolStripMenuItem.Name = "speedToolStripMenuItem";
            this.speedToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.speedToolStripMenuItem.Text = "Speed";
            // 
            // mS14SecondToolStripMenuItem
            // 
            this.mS14SecondToolStripMenuItem.Name = "mS14SecondToolStripMenuItem";
            this.mS14SecondToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.mS14SecondToolStripMenuItem.Text = "250 MS (1/4 Second)";
            this.mS14SecondToolStripMenuItem.Click += new System.EventHandler(this.mS14SecondToolStripMenuItem_Click);
            // 
            // mS12SecondToolStripMenuItem
            // 
            this.mS12SecondToolStripMenuItem.Name = "mS12SecondToolStripMenuItem";
            this.mS12SecondToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.mS12SecondToolStripMenuItem.Text = "500 MS (1/2 Second)";
            this.mS12SecondToolStripMenuItem.Click += new System.EventHandler(this.mS12SecondToolStripMenuItem_Click);
            // 
            // mS1SecondToolStripMenuItem
            // 
            this.mS1SecondToolStripMenuItem.Name = "mS1SecondToolStripMenuItem";
            this.mS1SecondToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.mS1SecondToolStripMenuItem.Text = "1000 MS (1 Second)";
            this.mS1SecondToolStripMenuItem.Click += new System.EventHandler(this.mS1SecondToolStripMenuItem_Click);
            // 
            // mS2SecondsToolStripMenuItem
            // 
            this.mS2SecondsToolStripMenuItem.Name = "mS2SecondsToolStripMenuItem";
            this.mS2SecondsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.mS2SecondsToolStripMenuItem.Text = "2000 MS (2 Seconds)";
            this.mS2SecondsToolStripMenuItem.Click += new System.EventHandler(this.mS2SecondsToolStripMenuItem_Click);
            // 
            // mS3SecondsToolStripMenuItem
            // 
            this.mS3SecondsToolStripMenuItem.Name = "mS3SecondsToolStripMenuItem";
            this.mS3SecondsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.mS3SecondsToolStripMenuItem.Text = "3000 MS (3 Seconds)";
            this.mS3SecondsToolStripMenuItem.Click += new System.EventHandler(this.mS3SecondsToolStripMenuItem_Click);
            // 
            // mS4SecondsToolStripMenuItem
            // 
            this.mS4SecondsToolStripMenuItem.Name = "mS4SecondsToolStripMenuItem";
            this.mS4SecondsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.mS4SecondsToolStripMenuItem.Text = "4000 MS (4 Seconds)";
            this.mS4SecondsToolStripMenuItem.Click += new System.EventHandler(this.mS4SecondsToolStripMenuItem_Click);
            // 
            // mS5SecondsToolStripMenuItem
            // 
            this.mS5SecondsToolStripMenuItem.Name = "mS5SecondsToolStripMenuItem";
            this.mS5SecondsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.mS5SecondsToolStripMenuItem.Text = "5000 MS (5 Seconds)";
            this.mS5SecondsToolStripMenuItem.Click += new System.EventHandler(this.mS5SecondsToolStripMenuItem_Click);
            // 
            // realTimeNoDelayToolStripMenuItem
            // 
            this.realTimeNoDelayToolStripMenuItem.Name = "realTimeNoDelayToolStripMenuItem";
            this.realTimeNoDelayToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.realTimeNoDelayToolStripMenuItem.Text = "Real Time (No Delay)";
            this.realTimeNoDelayToolStripMenuItem.Click += new System.EventHandler(this.realTimeNoDelayToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // resumeToolStripMenuItem
            // 
            this.resumeToolStripMenuItem.Name = "resumeToolStripMenuItem";
            this.resumeToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.resumeToolStripMenuItem.Text = "Resume";
            this.resumeToolStripMenuItem.Click += new System.EventHandler(this.resumeToolStripMenuItem_Click);
            // 
            // reallySimpleScreen1
            // 
            this.reallySimpleScreen1.AutoScroll = true;
            this.reallySimpleScreen1.BackColor = System.Drawing.Color.Black;
            this.reallySimpleScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reallySimpleScreen1.Location = new System.Drawing.Point(0, 24);
            this.reallySimpleScreen1.Name = "reallySimpleScreen1";
            this.reallySimpleScreen1.ScreenMemoryLocation = ((ushort)(40960));
            this.reallySimpleScreen1.Size = new System.Drawing.Size(644, 331);
            this.reallySimpleScreen1.TabIndex = 0;
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 355);
            this.Controls.Add(this.pnlRegisters);
            this.Controls.Add(this.reallySimpleScreen1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlRegisters.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReallySimpleScreen reallySimpleScreen1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Panel pnlRegisters;
        private System.Windows.Forms.Label lblRegisters;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem speedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mS14SecondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mS12SecondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mS1SecondToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mS2SecondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mS3SecondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mS4SecondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mS5SecondsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realTimeNoDelayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
    }
}


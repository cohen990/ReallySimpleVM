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
            this.reallySimpleScreen1 = new ReallySimpleVirtualMachine.ReallySimpleScreen();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.msMainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlRegisters = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblRegisters = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.pnlRegisters.SuspendLayout();
            this.SuspendLayout();
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMainMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(644, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // msMainMenu
            // 
            this.msMainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(37, 20);
            this.msMainMenu.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "B32";
            this.openFileDialog1.Filter = "B32 Files | *.B32";
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
    }
}


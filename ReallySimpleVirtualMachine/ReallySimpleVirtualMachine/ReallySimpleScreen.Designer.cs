using System.Drawing;
using System.Windows.Forms;

namespace ReallySimpleVirtualMachine
{
    partial class ReallySimpleScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ReallySimpleScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.Name = "ReallySimpleScreen";
            this.Size = new System.Drawing.Size(429, 408);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ReallySimpleScreen_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private void ReallySimpleScreen_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            Graphics bmpGraphics = Graphics.FromImage(bmp);
            Font f = new Font("Courier New", 10f, FontStyle.Bold);
            int xLoc = 0;
            int yLoc = 0;
            for (int i = 0; i < 4000; i += 2)
            {
                SolidBrush bgBrush = null;
                SolidBrush fgBrush = null;
                if ((m_ScreenMemory[i + 1] & 112) == 112)
                {
                    bgBrush = new SolidBrush(Color.Gray);
                }
                if ((m_ScreenMemory[i + 1] & 112) == 96)
                {
                    bgBrush = new SolidBrush(Color.Brown);
                }
                if ((m_ScreenMemory[i + 1] & 112) == 80)
                {
                    bgBrush = new SolidBrush(Color.Magenta);
                }
                if ((m_ScreenMemory[i + 1] & 112) == 64)
                {
                    bgBrush = new SolidBrush(Color.Red);
                }
                if ((m_ScreenMemory[i + 1] & 112) == 48)
                {
                    bgBrush = new SolidBrush(Color.Cyan);
                }
                if ((m_ScreenMemory[i + 1] & 112) == 32)
                {
                    bgBrush = new SolidBrush(Color.Green);
                }
                if ((m_ScreenMemory[i + 1] & 112) == 16)
                {
                    bgBrush = new SolidBrush(Color.Blue);
                }
                if ((m_ScreenMemory[i + 1] & 112) == 0)
                {
                    bgBrush = new SolidBrush(Color.Black);
                }
                if ((m_ScreenMemory[i + 1] & 7) == 0)
                {
                    if ((m_ScreenMemory[i + 1] & 8) == 8)
                    {
                        fgBrush = new SolidBrush(Color.Gray);
                    }
                    else
                    {
                        fgBrush = new SolidBrush(Color.Black);
                    }
                }
                if ((m_ScreenMemory[i + 1] & 7) == 1)
                {
                    if ((m_ScreenMemory[i + 1] & 8) == 8)
                    {
                        fgBrush = new SolidBrush(Color.LightBlue);
                    }
                    else
                    {
                        fgBrush = new SolidBrush(Color.Blue);
                    }
                }
                if ((m_ScreenMemory[i + 1] & 7) == 2)
                {
                    if ((m_ScreenMemory[i + 1] & 8) == 8)
                    {
                        fgBrush = new SolidBrush(Color.LightGreen);
                    }
                    else
                    {
                        fgBrush = new SolidBrush(Color.Green);
                    }
                }
                if ((m_ScreenMemory[i + 1] & 7) == 3)
                {
                    if ((m_ScreenMemory[i + 1] & 8) == 8)
                    {
                        fgBrush = new SolidBrush(Color.LightCyan);
                    }
                    else
                    {
                        fgBrush = new SolidBrush(Color.Cyan);
                    }
                }
                if ((m_ScreenMemory[i + 1] & 7) == 4)
                {
                    if ((m_ScreenMemory[i + 1] & 8) == 8)
                    {
                        fgBrush = new SolidBrush(Color.Pink);
                    }
                    else
                    {
                        fgBrush = new SolidBrush(Color.Red);
                    }
                }
                if ((m_ScreenMemory[i + 1] & 7) == 5)
                {
                    if ((m_ScreenMemory[i + 1] & 8) == 8)
                    {
                        fgBrush = new SolidBrush(Color.Fuchsia);
                    }
                    else
                    {
                        fgBrush = new SolidBrush(Color.Magenta);
                    }
                }
                if ((m_ScreenMemory[i + 1] & 7) == 6)
                {
                    if ((m_ScreenMemory[i + 1] & 8) == 8)
                    {
                        fgBrush = new SolidBrush(Color.Yellow);

                    }
                }
                else
                {
                    fgBrush = new SolidBrush(Color.Brown);
                }

                if ((m_ScreenMemory[i + 1] & 7) == 7)
                {
                    if ((m_ScreenMemory[i + 1] & 8) == 8)
                    {
                        fgBrush = new SolidBrush(Color.White);
                    }
                    else
                    {
                        fgBrush = new SolidBrush(Color.Gray);
                    }
                }
                if (bgBrush == null)
                    bgBrush = new SolidBrush(Color.Black);
                if (fgBrush == null)
                    fgBrush = new SolidBrush(Color.Gray);
                if (((xLoc % 640) == 0) && (xLoc != 0))
                {
                    yLoc += 11;
                    xLoc = 0;
                }
                string s =
               System.Text.Encoding.ASCII.GetString(m_ScreenMemory, i, 1);
                PointF pf = new PointF(xLoc, yLoc);
                bmpGraphics.FillRectangle(bgBrush, xLoc + 2, yLoc + 2, 8f, 11f);
                bmpGraphics.DrawString(s, f, fgBrush, pf);
                xLoc += 8;
            }
            e.Graphics.DrawImage(bmp, new Point(0, 0));
            bmpGraphics.Dispose();
            bmp.Dispose();
        }
    }
}


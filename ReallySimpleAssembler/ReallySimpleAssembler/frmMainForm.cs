using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using static ReallySimpleAssembler.ParserGlobalState;
using static ReallySimpleAssembler.Parser;

namespace ReallySimpleAssembler
{
    public partial class frmMainForm : Form
    {

        public frmMainForm()
        {
            InitializeComponent();

            LabelTable = new Hashtable(50);
            CurrentNdx = 0;
            AsLength = 0;
            ExecutionAddress = 0;
            IsEnd = false;
            SourceProgram = "";
            txtOrigin.Text = "1000";
        }

        private void btnSourceBrowse_Click(object sender, EventArgs e)
        {
            fdSourceFile.ShowDialog();
            txtSourceFileName.Text = fdSourceFile.FileName;
        }

        private void btnOutputBrowse_Click(object sender, EventArgs e)
        {
            fdDestinationFile.ShowDialog();
            txtOutputFileName.Text = fdDestinationFile.FileName;
        }

        private void btnAssemble_Click(object sender, EventArgs e)
        {
            AsLength = Convert.ToUInt16(txtOrigin.Text, 16);
            BinaryWriter output;
            TextReader input;
            FileStream fs = new FileStream(txtOutputFileName.Text, FileMode.Create);
            output = new BinaryWriter(fs);
            input = File.OpenText(txtSourceFileName.Text);
            SourceProgram = input.ReadToEnd();
            input.Close();
            output.Write('B');
            output.Write('3');
            output.Write('2');
            output.Write(Convert.ToUInt16(txtOrigin.Text, 16));
            output.Write((ushort)0);
            Parse(output, txtOrigin.Text);
            output.Seek(5, SeekOrigin.Begin);
            output.Write(ExecutionAddress);
            output.Close();
            fs.Close();
            MessageBox.Show("Done!");
        }
    }
}

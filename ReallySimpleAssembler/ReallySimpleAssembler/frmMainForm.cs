using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace ReallySimpleAssembler
{
    public partial class frmMainForm : Form
    {
        private string SourceProgram;
        private Hashtable LabelTable;
        private int CurrentNdx;
        private ushort AsLength;
        private bool IsEnd;
        private ushort ExecutionAddress;

        private enum Registers
        {
            Unknown = 0,
            A = 4,
            B = 2,
            D = 1,
            X = 16,
            Y = 8
        }

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
            Parse(output);
            output.Seek(5, SeekOrigin.Begin);
            output.Write(ExecutionAddress);
            output.Close();
            fs.Close();
            MessageBox.Show("Done!");
        }

        private void Parse(BinaryWriter OutputFile)
        {
            CurrentNdx = 0;
            while (IsEnd == false)
                LabelScan(OutputFile, true);
            IsEnd = false;
            CurrentNdx = 0;
            AsLength = Convert.ToUInt16(txtOrigin.Text, 16);
            while (IsEnd == false)
                LabelScan(OutputFile, false);
        }

        private void LabelScan(BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (char.IsLetter(SourceProgram[CurrentNdx]))
            {
                // Must be a label
                if (IsLabelScan) LabelTable.Add(GetLabelName(), AsLength);
                while (SourceProgram[CurrentNdx] != '\n')
                    CurrentNdx++;
                CurrentNdx++;
                return;
            }
            EatWhiteSpaces();
            ReadMneumonic(OutputFile, IsLabelScan);
        }

        // Added myself - be ready to delete if it's wrong.
        private void EatWhiteSpaces()
        {
            while(char.IsWhiteSpace(SourceProgram[CurrentNdx]))
            {
                CurrentNdx++;
            }
        }

        // Added myself - be ready to delete if it's wrong.
        private string GetLabelName()
        {
            string lblname = "";
            while (char.IsLetterOrDigit(SourceProgram[CurrentNdx]))
            {
                if (SourceProgram[CurrentNdx] == ':')
                {
                    CurrentNdx++;
                    break;
                }
                lblname = lblname + SourceProgram[CurrentNdx];
                CurrentNdx++;
            }
            return lblname.ToUpper();
        }

        private void ReadMneumonic(BinaryWriter OutputFile, bool IsLabelScan)
        {
            string Mneumonic = "";
            while (!(char.IsWhiteSpace(SourceProgram[CurrentNdx])))
            {
                Mneumonic = Mneumonic + SourceProgram[CurrentNdx];
                CurrentNdx++;
            }
            if (Mneumonic.ToUpper() == "LDX")
                InterpretLDX(OutputFile, IsLabelScan);
            if (Mneumonic.ToUpper() == "LDA")
                InterpretLDA(OutputFile, IsLabelScan);
            if (Mneumonic.ToUpper() == "STA")
                InterpretSTA(OutputFile, IsLabelScan);
            if (Mneumonic.ToUpper() == "END")
            {
                IsEnd = true;
                DoEnd(OutputFile, IsLabelScan);
                EatWhiteSpaces();
                ExecutionAddress = (ushort)LabelTable[(GetLabelName())];
                return;
            }
            while (SourceProgram[CurrentNdx] != '\n')
            {
                CurrentNdx++;
            }
            CurrentNdx++;
        }

        private void InterpretLDA(BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                byte val = ReadByteValue();
                AsLength += 2;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x01);
                    OutputFile.Write(val);
                }
            }
        }


        private void InterpretLDX(BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                ushort val = ReadWordValue();
                AsLength += 3;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x02);
                    OutputFile.Write(val);
                }
            }
        }

        private void InterpretSTA(BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if(SourceProgram[CurrentNdx] == ',')
            {
                Registers r;
                byte opcode = 0x00;

                CurrentNdx++;
                EatWhiteSpaces();

                r = ReadRegister();

                switch (r)
                {
                    case Registers.X:
                        opcode = 0x03;
                        break;
                }

                AsLength += 1;

                if (!IsLabelScan)
                {
                    OutputFile.Write(opcode);
                }
            }
        }

        private void DoEnd(BinaryWriter OutputFile, bool IsLabelScan)
        {
            AsLength++;
            if (!IsLabelScan)
            {
                OutputFile.Write((byte)0x04);
            }
        }

        private Registers ReadRegister()
        {
            Registers r = Registers.Unknown;

            // How it should be done
            //Enum.TryParse(SourceProgram[CurrentNdx].ToString(), out r);

            // How it is being done
            if ((SourceProgram[CurrentNdx] == 'X') ||
            (SourceProgram[CurrentNdx] == 'x'))
                r = Registers.X;
            if ((SourceProgram[CurrentNdx] == 'Y') ||
            (SourceProgram[CurrentNdx] == 'y'))
                r = Registers.Y;
            if ((SourceProgram[CurrentNdx] == 'D') ||
            (SourceProgram[CurrentNdx] == 'd'))
                r = Registers.D;
            if ((SourceProgram[CurrentNdx] == 'A') ||
            (SourceProgram[CurrentNdx] == 'a'))
                r = Registers.A;
            if ((SourceProgram[CurrentNdx] == 'B') ||
            (SourceProgram[CurrentNdx] == 'b'))
                r = Registers.B;

            CurrentNdx++;
            return r;
        }

        private ushort ReadWordValue()
        {
            ushort val = 0;
            bool isHex = false;
            string sval = "";

            if (SourceProgram[CurrentNdx] == '$')
            {
                CurrentNdx++;
                isHex = true;
            }

            while (char.IsLetterOrDigit(SourceProgram[CurrentNdx]))
            {
                sval = sval + SourceProgram[CurrentNdx];
                CurrentNdx++;
            }

            if (isHex)
            {
                val = Convert.ToUInt16(sval, 16);
            }
            else
            {
                val = ushort.Parse(sval);
            }

            return val;
        }

        private byte ReadByteValue()
        {
            byte val = 0;
            bool isHex = false;
            string sval = "";

            if (SourceProgram[CurrentNdx] == '$')
            {
                CurrentNdx++;
                isHex = true;
            }

            while (char.IsLetterOrDigit(SourceProgram[CurrentNdx]))
            {
                sval = sval + SourceProgram[CurrentNdx];
                CurrentNdx++;
            }

            if (isHex)
            {
                val = Convert.ToByte(sval, 16);
            }
            else
            {
                val = byte.Parse(sval);
            }

            return val;
        }
    }
}

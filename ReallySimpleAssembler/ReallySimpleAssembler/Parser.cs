using System;
using System.IO;
using static ReallySimpleAssembler.ParserGlobalState;
using static ReallySimpleAssembler.Interpreter;

namespace ReallySimpleAssembler
{
    static class Parser
    {
        public static string GetLabelName()
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

        public static void EatWhiteSpaces()
        {
            while (char.IsWhiteSpace(SourceProgram[CurrentNdx]))
            {
                CurrentNdx++;
            }
        }

        public static ushort ReadWordValue()
        {
            ushort val = 0;
            bool isHex = false;
            string sval = "";

            if (SourceProgram[CurrentNdx] == '$')
            {
                CurrentNdx++;
                isHex = true;
            }

            if ((isHex == false) && (char.IsLetter(SourceProgram[CurrentNdx])))
            {
                val = (ushort)LabelTable[GetLabelName()];
                return val;
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

        public static byte ReadByteValue()
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

        public static Registers ReadRegister()
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

        public static void Parse(BinaryWriter OutputFile, string originText)
        {
            CurrentNdx = 0;
            while (IsEnd == false)
                LabelScan(OutputFile, true);
            IsEnd = false;
            CurrentNdx = 0;
            AsLength = Convert.ToUInt16(originText, 16);
            while (IsEnd == false)
                LabelScan(OutputFile, false);
        }

        public static void LabelScan(BinaryWriter OutputFile, bool IsLabelScan)
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
            ReadMnemonic(OutputFile, IsLabelScan);
        }


        public static void ReadMnemonic(BinaryWriter OutputFile, bool IsLabelScan)
        {
            string Mnemonic = "";
            while (!(char.IsWhiteSpace(SourceProgram[CurrentNdx])))
            {
                Mnemonic = Mnemonic + SourceProgram[CurrentNdx];
                CurrentNdx++;
            }
            if (Mnemonic.ToUpper() == "LDX")
                InterpretLDX(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "LDA")
                InterpretLDA(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "STA")
                InterpretSTA(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "CMPA")
                InterpretCMPA(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "CMPB")
                InterpretCMPB(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "CMPX")
                InterpretCMPX(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "CMPY")
                InterpretCMPY(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "CMPD")
                InterpretCMPD(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "JMP")
                InterpretJMP(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "JEQ")
                InterpretJEQ(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "JNE")
                InterpretJNE(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "JGT")
                InterpretJGT(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "JLT")
                InterpretJLT(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "INCA")
                InterpretINCA(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "INCB")
                InterpretINCB(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "INCX")
                InterpretINCX(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "INCY")
                InterpretINCY(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "INCD")
                InterpretINCD(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "DECA")
                InterpretDECA(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "DECB")
                InterpretDECB(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "DECX")
                InterpretDECX(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "DECY")
                InterpretDECY(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "DECD")
                InterpretDECD(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "ROLA")
                InterpretROLA(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "ROLB")
                InterpretROLB(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "RORA")
                InterpretRORA(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "RORB")
                InterpretRORB(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "ADCA")
                InterpretADCA(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "ADCB")
                InterpretADCB(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "ADDA")
                InterpretADDA(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "ADDB")
                InterpretADDB(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "ADDAB")
                InterpretADDAB(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "LDY")
                InterpretLDY(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "LDB")
                InterpretLDB(OutputFile, IsLabelScan);
            if (Mnemonic.ToUpper() == "END")
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

        public static void DoEnd(BinaryWriter OutputFile, bool IsLabelScan)
        {
            AsLength++;
            if (!IsLabelScan)
            {
                OutputFile.Write((byte)0x04);
            }
        }
    }
}

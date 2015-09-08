using System.IO;
using static ReallySimpleAssembler.ParserGlobalState;
using static ReallySimpleAssembler.Parser;

namespace ReallySimpleAssembler
{
    public static class Interpreter
    {
        private static void WriteSimpleMnemonic(BinaryWriter outputFile, bool isLabelScan, byte operatorByte)
        {
            if (!isLabelScan)
            {
                outputFile.Write(operatorByte);
            }
            AsLength++;
        }
        private static void WriteMnemonicWithByte(BinaryWriter outputFile, bool isLabelScan, byte operatorByte)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                byte val = ReadByteValue();
                AsLength += 2;
                if (!isLabelScan)
                {
                    outputFile.Write(operatorByte);
                    outputFile.Write(val);
                }
            }
        }

        private static void WriteMnemonicWithWord(BinaryWriter outputFile, bool isLabelScan, byte operatorByte, bool returnEarly = false)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                AsLength += 3;
                if (returnEarly && isLabelScan) return;
                ushort val = ReadWordValue();
                if (!isLabelScan)
                {
                    outputFile.Write(operatorByte);
                    outputFile.Write(val);
                }
            }
        }

        public static void InterpretLDA(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithByte(OutputFile, IsLabelScan, 0x01);
        }


        public static void InterpretLDX(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithWord(OutputFile, IsLabelScan, 0x02);
        }

        public static void InterpretLDB(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithByte(OutputFile, IsLabelScan, 0x22);
        }


        public static void InterpretLDY(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithWord(OutputFile, IsLabelScan, 0x23);
        }

        public static void InterpretSTA(BinaryWriter OutputFile, bool IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == ',')
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

        public static void InterpretCMPA(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithByte(OutputFile, IsLabelScan, 0x05);
        }

        public static void InterpretCMPB(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithByte(OutputFile, IsLabelScan, 0x06);
        }

        public static void InterpretCMPX(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithWord(OutputFile, IsLabelScan, 0x07);
        }

        public static void InterpretCMPY(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithWord(OutputFile, IsLabelScan, 0x08);
        }

        public static void InterpretCMPD(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithWord(OutputFile, IsLabelScan, 0x09);
        }

        public static void InterpretJMP(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithWord(OutputFile, IsLabelScan, 0x0A, true);
        }

        public static void InterpretJEQ(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithWord(OutputFile, IsLabelScan, 0x0B, true);
        }

        public static void InterpretJNE(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithWord(OutputFile, IsLabelScan, 0x0C, true);
        }

        public static void InterpretJGT(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithWord(OutputFile, IsLabelScan, 0x0D, true);
        }

        public static void InterpretJLT(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithWord(OutputFile, IsLabelScan, 0x0E, true);
        }

        public static void InterpretINCA(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x0F);
        }

        public static void InterpretINCB(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x10);
        }

        public static void InterpretINCX(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x11);
        }

        public static void InterpretINCY(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x12);
        }

        public static void InterpretINCD(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x13);
        }

        public static void InterpretDECA(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x14);
        }

        public static void InterpretDECB(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x15);
        }

        public static void InterpretDECX(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x16);
        }

        public static void InterpretDECY(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x17);
        }

        public static void InterpretDECD(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x18);
        }

        public static void InterpretADCA(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x1D);
        }

        public static void InterpretADCB(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x1E);
        }

        public static void InterpretADDA(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithByte(OutputFile, IsLabelScan, 0x1F);
        }

        public static void InterpretADDB(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteMnemonicWithByte(OutputFile, IsLabelScan, 0x20);
        }

        public static void InterpretROLB(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x1A);
        }

        public static void InterpretROLA(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x19);
        }

        public static void InterpretRORB(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x1C);
        }

        public static void InterpretRORA(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x1B);
        }

        public static void InterpretADDAB(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteSimpleMnemonic(OutputFile, IsLabelScan, 0x21);
        }
    }
}

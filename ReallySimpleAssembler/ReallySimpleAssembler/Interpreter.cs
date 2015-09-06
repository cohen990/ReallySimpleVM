using System.IO;
using static ReallySimpleAssembler.ParserGlobalState;
using static ReallySimpleAssembler.Parser;

namespace ReallySimpleAssembler
{
    public static class Interpreter
    {
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
    }
}

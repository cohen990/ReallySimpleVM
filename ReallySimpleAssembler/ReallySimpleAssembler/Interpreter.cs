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
        private static void WriteNmemonicWithWord(BinaryWriter outputFile, bool isLabelScan, byte operatorByte)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                ushort val = ReadWordValue();
                AsLength += 3;
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
            WriteNmemonicWithWord(OutputFile, IsLabelScan, 0x02);
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
            WriteNmemonicWithWord(OutputFile, IsLabelScan, 0x07);
        }

        public static void InterpretCMPY(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteNmemonicWithWord(OutputFile, IsLabelScan, 0x08);
        }

        public static void InterpretCMPD(BinaryWriter OutputFile, bool IsLabelScan)
        {
            WriteNmemonicWithWord(OutputFile, IsLabelScan, 0x09);
        }
    }
}

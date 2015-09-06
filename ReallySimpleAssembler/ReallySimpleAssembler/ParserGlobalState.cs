using System.Collections;

namespace ReallySimpleAssembler
{
    static class ParserGlobalState
    {
        public static string SourceProgram;
        public static Hashtable LabelTable;
        public static int CurrentNdx;
        public static ushort AsLength;
        public static bool IsEnd;
        public static ushort ExecutionAddress;

        public enum Registers
        {
            Unknown = 0,
            A = 4,
            B = 2,
            D = 1,
            X = 16,
            Y = 8
        }

        static ParserGlobalState()
        {
            LabelTable = new Hashtable(50);
            CurrentNdx = 0;
            AsLength = 0;
            ExecutionAddress = 0;
            IsEnd = false;
            SourceProgram = "";
        }
    }
}

using System;
using System.Windows.Forms;

namespace ReallySimpleVirtualMachine
{
    public partial class ReallySimpleScreen : UserControl
    {
        private ushort m_ScreenMemoryLocation;
        private byte[] m_ScreenMemory;

        public ushort ScreenMemoryLocation
        {
            get
            {
                return m_ScreenMemoryLocation;
            }
            set
            {
                m_ScreenMemoryLocation = value;
            }
        }

        public ReallySimpleScreen()
        {
            InitializeComponent();
            m_ScreenMemoryLocation = 0xA000;
            m_ScreenMemory = new byte[4000];
            for (int i = 0; i < 4000; i += 2)
            {
                m_ScreenMemory[i] = 32;
                m_ScreenMemory[i + 1] = 7;
            }
        }

        public void Poke(ushort Address, byte Value)
        {
            ushort MemLoc;

            try
            {
                MemLoc = (ushort)(Address - m_ScreenMemoryLocation);
            }
            catch (Exception)
            {
                return;
            }

            if(MemLoc < 0 || MemLoc > 3999)
            {
                return;
            }

            m_ScreenMemory[MemLoc] = Value;
            Refresh();
        }

        public byte Peek(ushort Address)
        {
            ushort MemLoc;

            try
            {
                MemLoc = (ushort)(Address - m_ScreenMemoryLocation);
            }
            catch (Exception)
            {
                return (byte)0;
            }

            if (MemLoc < 0 || MemLoc > 3999)
            {
                return (byte)0;
            }

            return m_ScreenMemory[MemLoc];
        }
    }
}

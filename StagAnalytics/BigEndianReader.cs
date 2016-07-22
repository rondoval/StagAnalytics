using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StagAnalytics
{
    class BigEndianReader : BinaryReader
    {
        public BigEndianReader(Stream stream, Encoding enc) : base(stream, enc) { }

        public override short ReadInt16()
        {
            byte[] a = ReadBytes(2);
            Array.Reverse(a);
            return BitConverter.ToInt16(a, 0);
        }

        public override ushort ReadUInt16()
        {
            byte[] a = ReadBytes(2);
            Array.Reverse(a);
            return BitConverter.ToUInt16(a, 0);
        }

        public override int ReadInt32()
        {
            byte[] a = ReadBytes(4);
            Array.Reverse(a);
            return BitConverter.ToInt32(a, 0);
        }

        public override uint ReadUInt32()
        {
            byte[] a = ReadBytes(4);
            Array.Reverse(a);
            return BitConverter.ToUInt32(a, 0);
        }

        public override long ReadInt64()
        {
            byte[] a = ReadBytes(8);
            Array.Reverse(a);
            return BitConverter.ToInt64(a, 0);
        }

        public override ulong ReadUInt64()
        {
            byte[] a = ReadBytes(8);
            Array.Reverse(a);
            return BitConverter.ToUInt64(a, 0);
        }
    }
}

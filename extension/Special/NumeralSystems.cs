using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Extensions.NumeralSystems
{
    public static class BitEx
    {
        private static string InsertSeparators(int byteCount, string separator, string str)
        {
            int len = separator.Length;
            for (int i = 1; i < byteCount; i++)
                str = str.Insert(8 * i + len * (i - 1), separator);
            return str;
        }
        public static string Bin(this byte x)
        {
            return Convert.ToString(x, 2).PadLeft(8, '0');
        }
        public static string Bin(this sbyte x)
        {
            return Convert.ToString(x, 2).PadLeft(8, '0');
        }
        public static string Bin(this short x)
        {
            return Convert.ToString(x, 2).PadLeft(16, '0');
        }
        public static string SeparatedBin(this short x, string separator = " ")
        {
            return InsertSeparators(2, separator, Convert.ToString(x, 2).PadLeft(16, '0'));
        }
        public static string Bin(this int x)
        {
            return Convert.ToString(x, 2).PadLeft(32, '0');
        }
        public static string SeparatedBin(this int x, string separator = " ")
        {
            return InsertSeparators(4, separator, Convert.ToString(x, 2).PadLeft(32, '0'));
        }
        public static string Bin(this long x)
        {
            return Convert.ToString(x, 2).PadLeft(64, '0');
        }
        public static string SeparatedBin(this long x, string separator = " ")
        {
            return InsertSeparators(8, separator, Convert.ToString(x, 2).PadLeft(64, '0'));
        }
        public static string Bin(this ushort x)
        {
            return ((short)x).Bin();
        }
        public static string SeparatedBin(this ushort x, string separator = " ")
        {
            return ((short)x).SeparatedBin(separator);
        }
        public static string Bin(this uint x)
        {
            return ((int)x).Bin();
        }
        public static string SeparatedBin(this uint x, string separator = " ")
        {
            return ((int)x).SeparatedBin(separator);
        }
        public static string Bin(this ulong x)
        {
            return ((long)x).Bin();
        }
        public static string SeparatedBin(this ulong x, string separator = " ")
        {
            return ((long)x).SeparatedBin(separator);
        }
    }
    public static class HexEx
    {
        private static string InsertSeparators(int byteCount, string separator, string str)
        {
            int len = separator.Length;
            for (int i = 1; i < byteCount; i++)
                str = str.Insert(2 * i + len * (i - 1), separator);
            return str;
        }
        public static string Hex(this byte x)
        {
            return Convert.ToString(x, 16).PadLeft(2, '0');
        }
        public static string Hex(this sbyte x)
        {
            return Convert.ToString(x, 16).PadLeft(2, '0');
        }
        public static string Hex(this short x)
        {
            return Convert.ToString(x, 16).PadLeft(4, '0');
        }
        public static string SeparatedHex(this short x, string separator = " ")
        {
            return InsertSeparators(2, separator, Convert.ToString(x, 16).PadLeft(4, '0'));
        }
        public static string Hex(this int x)
        {
            return Convert.ToString(x, 16).PadLeft(8, '0');
        }
        public static string SeparatedHex(this int x, string separator = " ")
        {
            return InsertSeparators(4, separator, Convert.ToString(x, 16).PadLeft(8, '0'));
        }
        public static string Hex(this long x)
        {
            return Convert.ToString(x, 16).PadLeft(16, '0');
        }
        public static string SeparatedHex(this long x, string separator = " ")
        {
            return InsertSeparators(8, separator, Convert.ToString(x, 16).PadLeft(16, '0'));
        }
        public static string Hex(this ushort x)
        {
            return ((short)x).Hex();
        }
        public static string SeparatedHex(this ushort x, string separator = " ")
        {
            return ((short)x).SeparatedHex(separator);
        }
        public static string Hex(this uint x)
        {
            return ((int)x).Hex();
        }
        public static string SeparatedHex(this uint x, string separator = " ")
        {
            return ((int)x).SeparatedHex(separator);
        }
        public static string Hex(this ulong x)
        {
            return ((long)x).Hex();
        }
        public static string SeparatedHex(this ulong x, string separator = " ")
        {
            return ((long)x).SeparatedHex(separator);
        }
    }
    public static class ByteEx
    {
        public static byte[] GetBytes(this short value)
        {
            return BitConverter.GetBytes(value);
        }
        public static byte[] GetBytes(this ushort value)
        {
            return BitConverter.GetBytes(value);
        }
        public static byte[] GetBytes(this int value)
        {
            return BitConverter.GetBytes(value);
        }
        public static byte[] GetBytes(this uint value)
        {
            return BitConverter.GetBytes(value);
        }
        public static byte[] GetBytes(this long value)
        {
            return BitConverter.GetBytes(value);
        }
        public static byte[] GetBytes(this ulong value)
        {
            return BitConverter.GetBytes(value);
        }
    }
}
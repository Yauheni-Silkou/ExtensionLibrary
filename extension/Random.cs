using System;
using System.Numerics;

namespace Extensions
{
    public static class Rnd
    {
        public static byte Byte(byte min, byte max)
        {
            return (byte)BigInt(min, max);
        }
        public static sbyte SByte(sbyte min, sbyte max)
        {
            return (sbyte)BigInt(min, max);
        }
        public static short Short(short min, short max)
        {
            return (short)BigInt(min, max);
        }
        public static ushort UShort(ushort min, ushort max)
        {
            return (ushort)BigInt(min, max);
        }
        public static int Int(int min, int max)
        {
            return (int)BigInt(min, max);
        }
        public static uint UInt(uint min, uint max)
        {
            return (uint)BigInt(min, max);
        }
        public static long Long(long min, long max)
        {
            return (long)BigInt(min, max);
        }
        public static ulong ULong(ulong min, ulong max)
        {
            return (ulong)BigInt(min, max);
        }
        public static BigInteger BigInt(BigInteger min, BigInteger max)
        {
            if (max <= min) return max;
            var x = max - min + 2;
            return RandomBigInteger(x) + min - 1;
        }
        static Random rand = new Random();

        // returns a evenly distributed random BigInteger from 1 to N.
        static BigInteger RandomBigInteger(BigInteger N)
        {
            BigInteger result = 0;
            do
            {
                int length = (int)Math.Ceiling(BigInteger.Log(N, 2));
                int numBytes = (int)Math.Ceiling(length / 8.0);
                byte[] data = new byte[numBytes];
                rand.NextBytes(data);
                result = new BigInteger(data);
            } while (result >= N || result <= 0);
            return result;
        }
    }
}

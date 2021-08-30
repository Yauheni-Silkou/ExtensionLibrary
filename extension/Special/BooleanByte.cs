using Extensions.NumeralSystems;
using System;
using System.Linq;

namespace Extensions.BooleanByte
{
    public static class BoolByte
    {
        static int Ch(this bool b)
        {
            return b ? 1 : 0;
        }
        public static Tuple<bool, bool, bool, bool, bool, bool, bool, Tuple<bool>> BooleanValues(this byte x)
        {
            var array = x.Bin().Select(c => c == '1').ToArray();
            return new Tuple<bool, bool, bool, bool, bool, bool, bool, Tuple<bool>>
                (array[0], array[1], array[2], array[3], array[4], array[5], array[6], new Tuple<bool>(array[7]));
        }
        public static byte PackToByte(this Tuple<bool, bool, bool, bool, bool, bool, bool, Tuple<bool>> tuple)
        {
            var (x1, x2, x3, x4, x5, x6, x7, x8) = tuple;
            string s = $"{x1.Ch()}{x2.Ch()}{x3.Ch()}{x4.Ch()}{x5.Ch()}{x6.Ch()}{x7.Ch()}{x8.Ch()}";
            return Convert.ToByte(s, 2);
        }
    }
}

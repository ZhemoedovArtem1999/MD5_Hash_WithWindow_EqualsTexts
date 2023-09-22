using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace MD5
{
    public class Funcs
    {
        public UInt32 F(UInt32 X, UInt32 Y, UInt32 Z)
        {

            return (X & Y) | (~X & Z);
        }

        public UInt32 G(UInt32 X, UInt32 Y, UInt32 Z)
        {
            return (X & Z) | (Y & ~Z);
        }

        public UInt32 H(UInt32 X, UInt32 Y, UInt32 Z)
        {
            return X ^ Y ^ Z;
        }

        public UInt32 I(UInt32 X, UInt32 Y, UInt32 Z)
        {
            return Y ^ (X | ~Z);
        }

        public UInt32 rotateLeft(UInt32 x, UInt32 n)
        {
            uint ux = x;
            int un = Convert.ToInt32(n);

            uint levo = (ux << un);
            uint pravo = (ux >> (32 - un));
            uint vmeste = levo | pravo;
            //Console.WriteLine(levo + " " + pravo + " " + vmeste);

            return (UInt32)vmeste;//Math.Abs((((int)x << (int)n) | ((int)x >> (int)(32 - n))));
        }


        public UInt32[] byteToUintArr(byte[] buf)
        {
            UInt32[] words = new UInt32[buf.Length / 4];

            for (int i = 0; i < buf.Length; i += 4)
            {
                words[i / 4] += (UInt32)buf[i] << 0;
                words[i / 4] += (UInt32)buf[i + 1] << 8;
                words[i / 4] += (UInt32)buf[i + 2] << 16;
                words[i / 4] += (UInt32)buf[i + 3] << 24;
            }
            //foreach (var item in words)
            //{
            //    Console.WriteLine(item);
            //}


            return words;
        }



        public string rawMD5ToHEX(UInt32 value)
        {
            string res = "";

            for (int i = 0; i < 4; i++)
            {
                res += string.Format("{0:X2}", value % 256);

                value /= 256;

            }

            return res;

        }



    }
}

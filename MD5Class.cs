using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MD5
{
    public class MD5Class
    {

        UInt32 A, B, C, D;
        UInt32[] T = new UInt32[64]
        {
            0xd76aa478,0xe8c7b756,0x242070db,0xc1bdceee,
            0xf57c0faf,0x4787c62a,0xa8304613,0xfd469501,
            0x698098d8,0x8b44f7af,0xffff5bb1,0x895cd7be,
            0x6b901122,0xfd987193,0xa679438e,0x49b40821,
            0xf61e2562,0xc040b340,0x265e5a51,0xe9b6c7aa,
            0xd62f105d,0x02441453,0xd8a1e681,0xe7d3fbc8,
            0x21e1cde6,0xc33707d6,0xf4d50d87,0x455a14ed,
            0xa9e3e905,0xfcefa3f8,0x676f02d9,0x8d2a4c8a,
            0xfffa3942,0x8771f681,0x6d9d6122,0xfde5380c,
            0xa4beea44,0x4bdecfa9,0xf6bb4b60,0xbebfbc70,
            0x289b7ec6,0xeaa127fa,0xd4ef3085,0x04881d05,
            0xd9d4d039,0xe6db99e5,0x1fa27cf8,0xc4ac5665,
            0xf4292244,0x432aff97,0xab9423a7,0xfc93a039,
            0x655b59c3,0x8f0ccc92,0xffeff47d,0x85845dd1,
            0x6fa87e4f,0xfe2ce6e0,0xa3014314,0x4e0811a1,
            0xf7537e82,0xbd3af235,0x2ad7d2bb,0xeb86d391
        };

        Funcs funcs = new Funcs();
        public string HashMD5(StringBuilder text)
        {
            byte[] inBytes = Encoding.UTF8.GetBytes(text.ToString());
            List<byte> buf = inBytes.ToList<byte>();

            uint dataLen = (uint)(buf.Count * 8);
            //Console.WriteLine(dataLen);
            //Console.WriteLine(buf.Count);
            //foreach (var item in buf)
            //{
            //    Console.WriteLine(item);
            //}


            appendPaddingBytes(buf);
            //Console.WriteLine("проверка");
            //foreach (var item in buf)
            //{
            //    Console.WriteLine(item);
            //}


            //Console.WriteLine(buf.Count);
            appendLength(buf, dataLen);
            //Console.WriteLine("проверка2");
            //foreach (var item in buf)
            //{
            //    Console.WriteLine(item);
            //}


            //Console.WriteLine(buf.Count);
            initMDbuf();
            //Console.WriteLine(buf.Count);


            UInt32[] bytesAsInts = buf.Select(x => (UInt32)x).ToArray();
            //foreach (UInt32 i in bytesAsInts)
            //{ Console.WriteLine(i); }
            UInt32[] bytesAsInts1 = funcs.byteToUintArr(buf.ToArray());
            processMsgIn16WordBlocks(bytesAsInts1);



            return funcs.rawMD5ToHEX(A) + funcs.rawMD5ToHEX(B) + funcs.rawMD5ToHEX(C) + funcs.rawMD5ToHEX(D);

        }

        // запись единицы в конец буфера
        private void appendPaddingBytes(List<byte> buf)
        {
            buf.Add(128);

            while (buf.Count % 64 != 56)
            {
                buf.Add(0);
            }

        }

        // запись длинны текста в Little Endian
        private void appendLength(List<byte> buf, UInt64 length)
        {
            byte[] buffer = new byte[64];

            BinaryPrimitives.WriteUInt64LittleEndian(buffer, length);

            //List<byte> listBuffer = new List<byte>(buffer);

            //int kol = buf.Count;
            //int kolClaster = kol / 64;
            //if (kol % 64 == 0)
            //{

            //}
            //else
            //{
            int i = 0;
            while (buf.Count % 64 != 0)
            {
                buf.Add(buffer[i]);

                i++;
                //buf.RemoveRange(64, buf.Count - 64);
            }
            //}

            //buf.AddRange(buffer);
            // поработать под большие данные
            //buf.RemoveRange(64, buf.Count - 64);


        }

        // инициализация 
        private void initMDbuf()
        {
            A = 0x67452301;

            B = 0xEFCDAB89;

            C = 0x98BADCFE;

            D = 0x10325476;


            //for (int i = 0; i < 64; i++)
            //{
            //    T[i] = Convert.ToUInt32(Math.Pow(2, 32) * Math.Abs(Math.Sin((double)(i + 1))));

            //}
        }

        // создание хэша
        private void processMsgIn16WordBlocks(UInt32[] buf)
        {
            for (int n = 0; n < buf.Length; n += 16)
            {
                UInt32 AA = A;
                UInt32 BB = B;
                UInt32 CC = C;
                UInt32 DD = D;



                // Round 1

                A = B + funcs.rotateLeft((A + funcs.F(B, C, D) + buf[n + 0] + T[0]), 7);
                //Console.WriteLine(funcs.F(B, C, D));
                //Console.WriteLine(A + " " + B + " " + buf[n+0] + " " + T[0]);
                D = A + funcs.rotateLeft((D + funcs.F(A, B, C) + buf[n + 1] + T[1]), 12);

                C = D + funcs.rotateLeft((C + funcs.F(D, A, B) + buf[n + 2] + T[2]), 17);

                B = C + funcs.rotateLeft((B + funcs.F(C, D, A) + buf[n + 3] + T[3]), 22);


                A = B + funcs.rotateLeft((A + funcs.F(B, C, D) + buf[n + 4] + T[4]), 7);

                D = A + funcs.rotateLeft((D + funcs.F(A, B, C) + buf[n + 5] + T[5]), 12);

                C = D + funcs.rotateLeft((C + funcs.F(D, A, B) + buf[n + 6] + T[6]), 17);

                B = C + funcs.rotateLeft((B + funcs.F(C, D, A) + buf[n + 7] + T[7]), 22);


                A = B + funcs.rotateLeft((A + funcs.F(B, C, D) + buf[n + 8] + T[8]), 7);

                D = A + funcs.rotateLeft((D + funcs.F(A, B, C) + buf[n + 9] + T[9]), 12);

                C = D + funcs.rotateLeft((C + funcs.F(D, A, B) + buf[n + 10] + T[10]), 17);

                B = C + funcs.rotateLeft((B + funcs.F(C, D, A) + buf[n + 11] + T[11]), 22);


                A = B + funcs.rotateLeft((A + funcs.F(B, C, D) + buf[n + 12] + T[12]), 7);

                D = A + funcs.rotateLeft((D + funcs.F(A, B, C) + buf[n + 13] + T[13]), 12);

                C = D + funcs.rotateLeft((C + funcs.F(D, A, B) + buf[n + 14] + T[14]), 17);

                B = C + funcs.rotateLeft((B + funcs.F(C, D, A) + buf[n + 15] + T[15]), 22);

                // Round 2

                A = B + funcs.rotateLeft((A + funcs.G(B, C, D) + buf[n + 1] + T[16]), 5);
                D = A + funcs.rotateLeft((D + funcs.G(A, B, C) + buf[n + 6] + T[17]), 9);
                C = D + funcs.rotateLeft((C + funcs.G(D, A, B) + buf[n + 11] + T[18]), 14);
                B = C + funcs.rotateLeft((B + funcs.G(C, D, A) + buf[n + 0] + T[19]), 20);


                A = B + funcs.rotateLeft((A + funcs.G(B, C, D) + buf[n + 5] + T[20]), 5);
                D = A + funcs.rotateLeft((D + funcs.G(A, B, C) + buf[n + 10] + T[21]), 9);
                C = D + funcs.rotateLeft((C + funcs.G(D, A, B) + buf[n + 15] + T[22]), 14);
                B = C + funcs.rotateLeft((B + funcs.G(C, D, A) + buf[n + 4] + T[23]), 20);


                A = B + funcs.rotateLeft((A + funcs.G(B, C, D) + buf[n + 9] + T[24]), 5);
                D = A + funcs.rotateLeft((D + funcs.G(A, B, C) + buf[n + 14] + T[25]), 9);
                C = D + funcs.rotateLeft((C + funcs.G(D, A, B) + buf[n + 3] + T[26]), 14);
                B = C + funcs.rotateLeft((B + funcs.G(C, D, A) + buf[n + 8] + T[27]), 20);


                A = B + funcs.rotateLeft((A + funcs.G(B, C, D) + buf[n + 13] + T[28]), 5);
                D = A + funcs.rotateLeft((D + funcs.G(A, B, C) + buf[n + 2] + T[29]), 9);
                C = D + funcs.rotateLeft((C + funcs.G(D, A, B) + buf[n + 7] + T[30]), 14);
                B = C + funcs.rotateLeft((B + funcs.G(C, D, A) + buf[n + 12] + T[31]), 20);

                // Round 3

                A = B + funcs.rotateLeft((A + funcs.H(B, C, D) + buf[n + 5] + T[32]), 4);
                D = A + funcs.rotateLeft((D + funcs.H(A, B, C) + buf[n + 8] + T[33]), 11);
                C = D + funcs.rotateLeft((C + funcs.H(D, A, B) + buf[n + 11] + T[34]), 16);
                B = C + funcs.rotateLeft((B + funcs.H(C, D, A) + buf[n + 14] + T[35]), 23);


                A = B + funcs.rotateLeft((A + funcs.H(B, C, D) + buf[n + 1] + T[36]), 4);
                D = A + funcs.rotateLeft((D + funcs.H(A, B, C) + buf[n + 4] + T[37]), 11);
                C = D + funcs.rotateLeft((C + funcs.H(D, A, B) + buf[n + 7] + T[38]), 16);
                B = C + funcs.rotateLeft((B + funcs.H(C, D, A) + buf[n + 10] + T[39]), 23);


                A = B + funcs.rotateLeft((A + funcs.H(B, C, D) + buf[n + 13] + T[40]), 4);
                D = A + funcs.rotateLeft((D + funcs.H(A, B, C) + buf[n + 0] + T[41]), 11);
                C = D + funcs.rotateLeft((C + funcs.H(D, A, B) + buf[n + 3] + T[42]), 16);
                B = C + funcs.rotateLeft((B + funcs.H(C, D, A) + buf[n + 6] + T[43]), 23);


                A = B + funcs.rotateLeft((A + funcs.H(B, C, D) + buf[n + 9] + T[44]), 4);
                D = A + funcs.rotateLeft((D + funcs.H(A, B, C) + buf[n + 12] + T[45]), 11);
                C = D + funcs.rotateLeft((C + funcs.H(D, A, B) + buf[n + 15] + T[46]), 16);
                B = C + funcs.rotateLeft((B + funcs.H(C, D, A) + buf[n + 2] + T[47]), 23);

                // Round 4

                A = B + funcs.rotateLeft((A + funcs.I(B, C, D) + buf[n + 0] + T[48]), 6);
                D = A + funcs.rotateLeft((D + funcs.I(A, B, C) + buf[n + 7] + T[49]), 10);
                C = D + funcs.rotateLeft((C + funcs.I(D, A, B) + buf[n + 14] + T[50]), 15);
                B = C + funcs.rotateLeft((B + funcs.I(C, D, A) + buf[n + 5] + T[51]), 21);


                A = B + funcs.rotateLeft((A + funcs.I(B, C, D) + buf[n + 12] + T[52]), 6);
                D = A + funcs.rotateLeft((D + funcs.I(A, B, C) + buf[n + 3] + T[53]), 10);
                C = D + funcs.rotateLeft((C + funcs.I(D, A, B) + buf[n + 10] + T[54]), 15);
                B = C + funcs.rotateLeft((B + funcs.I(C, D, A) + buf[n + 1] + T[55]), 21);


                A = B + funcs.rotateLeft((A + funcs.I(B, C, D) + buf[n + 8] + T[56]), 6);
                D = A + funcs.rotateLeft((D + funcs.I(A, B, C) + buf[n + 15] + T[57]), 10);
                C = D + funcs.rotateLeft((C + funcs.I(D, A, B) + buf[n + 6] + T[58]), 15);
                B = C + funcs.rotateLeft((B + funcs.I(C, D, A) + buf[n + 13] + T[59]), 21);


                A = B + funcs.rotateLeft((A + funcs.I(B, C, D) + buf[n + 4] + T[60]), 6);
                D = A + funcs.rotateLeft((D + funcs.I(A, B, C) + buf[n + 11] + T[61]), 10);
                C = D + funcs.rotateLeft((C + funcs.I(D, A, B) + buf[n + 2] + T[62]), 15);
                B = C + funcs.rotateLeft((B + funcs.I(C, D, A) + buf[n + 9] + T[63]), 21);

                //Console.WriteLine(A);
                //Console.WriteLine(B);
                //Console.WriteLine(C);
                //Console.WriteLine(D);

                A += AA;

                B += BB;

                C += CC;

                D += DD;

            }

        }
    }
}

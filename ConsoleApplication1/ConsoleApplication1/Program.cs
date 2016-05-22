﻿using System;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Path to the format");
            string path = Console.ReadLine();
            if (!File.Exists(path))
            {
                Console.WriteLine("Doesn't exist");
                Console.ReadKey();
                goto exit;
            }
            Console.WriteLine("Path to code");
            string path2 = Console.ReadLine();
            if (!File.Exists(path2))
            {
                Console.WriteLine("Doesn't exist");
                Console.ReadKey();
                goto exit;
            }
            var formatfileread = File.OpenRead(path);
            string ss = File.ReadAllText(path2);
            string s = ss;
            long count = formatfileread.Position;
            long wut = ss.Length % formatfileread.Length;
            long columns = ss.Length;
            int readByte;
            long count2 = 0;
            long positionofSS;
            while (true)
            {
                columns = ss.Length;
                count = formatfileread.Position;
                readByte = formatfileread.ReadByte();
                positionofSS = count + count2;
                if (readByte == (byte)'\n')
                {
                    if (count + count2 >= columns)
                    {
                        positionofSS = ss.Length - 1;
                        goto writeMore;
                    }
                    if (ss.ToCharArray()[positionofSS] != (byte)'\n')
                    {
                        ss = ss.Insert((int)(positionofSS), "\n");
                        positionofSS++;
                    }
                }
                if (readByte == (byte)' ')
                {
                    if (count + count2 >= columns)
                    {
                        positionofSS = ss.Length - 1;
                        goto writeMore;
                    }
                    if (ss.ToCharArray()[positionofSS] != (byte)' ')
                    {
                        ss = ss.Insert((int)positionofSS, @" ");
                        positionofSS++;
                    }
                }
                Console.WriteLine(formatfileread.Position);
                if (formatfileread.Position == formatfileread.Length - 1)
                {
                    ss = ss.Insert((int)positionofSS, "\n");
                    formatfileread.Position = 0;
                    wut = ss.Length % formatfileread.Length;
                    if (wut == 0 && formatfileread.Length == ss.Length)
                    {
                        goto exit;
                    }
                    count2 += count;
                }
            }
            #region afterdone
            writeMore:
            formatfileread.Position = count;
            while (formatfileread.Position + 1 != formatfileread.Length)
            {
                readByte = formatfileread.ReadByte();
                if (readByte == (byte)'\n')
                {
                    ss += '\n';
                }
                else if (readByte == (byte)' ')
                {
                    ss += ' ';
                }
                else
                {
                    ss += (char)readByte;
                }
            }
            ;
            Console.WriteLine("Choose a save path");
            string save = Console.ReadLine();
            ss += '\n';
            formatfileread.Dispose();
            File.WriteAllText(save, ss);
            File.WriteAllText(path2, ss);
            #endregion
            exit:
            ;
        }
    }
}


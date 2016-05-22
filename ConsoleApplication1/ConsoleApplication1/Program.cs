using System;
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
            int readByte;
            long extra = 0;
            long count2 = 0;
            long positionofSS;
            while (true)
            {
                count = formatfileread.Position;
                readByte = formatfileread.ReadByte();
                positionofSS = count + count2;
                if (readByte == (byte)'\n')
                {
                    if (count + count2 >= ss.Length)
                    {
                        positionofSS = ss.Length;
                        goto writeMore;
                    }
                    if (ss.ToCharArray()[positionofSS] != (byte)'\n')
                    {
                        ss = ss.Insert((int)(positionofSS), "\n");
                    }
                }
                if (readByte == (byte)' ')
                {
                    if (count + count2 >= ss.Length)
                    {
                        positionofSS = ss.Length;
                        goto writeMore;
                    }
                    if (ss.ToCharArray()[positionofSS] != (byte)' ')
                    {
                        ss = ss.Insert((int)positionofSS, @" ");
                    }
                }
                Console.WriteLine(formatfileread.Position + ": % done is: {0}", 100*((double)positionofSS / ss.Length));
                if (formatfileread.Position == formatfileread.Length)
                {
                    ss = ss.Insert((int)positionofSS, "\n");
                    extra++;
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
            positionofSS = ss.Length;
            formatfileread.Position = (ss.Length % formatfileread.Length) + extra;
            while (formatfileread.Position != formatfileread.Length)
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
            formatfileread.Dispose();
            ss += File.ReadAllText(path);
            ss += '\n';
            File.WriteAllText(path2, ss);
            Console.WriteLine("Would you like to append another file aswell? (y/n)");
            if(Console.ReadLine() == "y")
            {
                Console.WriteLine("Type file to append");
                string sss = Console.ReadLine();
                if (!File.Exists(sss))
                {
                    Console.WriteLine("Doesn't exist");
                    Console.ReadKey();
                    goto exit;
                }
                ss += format(sss, s);
                File.WriteAllText(path2, ss);
            }
            #endregion
            exit:
            ;
        }
        static string format(string path, string previous)
        {
            var formatfileread = File.OpenRead(path);
            string ss = previous;
            string s = ss;
            long count = formatfileread.Position;
            long wut = ss.Length % formatfileread.Length;
            int readByte;
            long extra = 0;
            long count2 = 0;
            long positionofSS;
            while (true)
            {
                count = formatfileread.Position;
                readByte = formatfileread.ReadByte();
                positionofSS = count + count2;
                if (readByte == (byte)'\n')
                {
                    if (count + count2 >= ss.Length)
                    {
                        positionofSS = ss.Length;
                        goto writeMore;
                    }
                    if (ss.ToCharArray()[positionofSS] != (byte)'\n')
                    {
                        ss = ss.Insert((int)(positionofSS), "\n");
                    }
                }
                if (readByte == (byte)' ')
                {
                    if (count + count2 >= ss.Length)
                    {
                        positionofSS = ss.Length;
                        goto writeMore;
                    }
                    if (ss.ToCharArray()[positionofSS] != (byte)' ')
                    {
                        ss = ss.Insert((int)positionofSS, @" ");
                    }
                }
                Console.WriteLine(formatfileread.Position + ": % done is: {0}",100*((double)positionofSS / ss.Length));
                if (formatfileread.Position == formatfileread.Length)
                {
                    ss = ss.Insert((int)positionofSS, "\n");
                    extra++;
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
            positionofSS = ss.Length;
            formatfileread.Position = (ss.Length % formatfileread.Length) + extra;
            while (formatfileread.Position != formatfileread.Length)
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
            formatfileread.Dispose();
            ss += File.ReadAllText(path) + '\n';
            Console.WriteLine("Would you like to append another file aswell? (y/n)");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("Type file to append");
                string sss = Console.ReadLine();
                if (!File.Exists(sss))
                {
                    Console.WriteLine("Doesn't exist");
                    Console.ReadKey();
                    goto exit;
                }
                ss += format(sss, s);
            }
            #endregion
            exit:
            return ss;
            ;
        }
    }
}


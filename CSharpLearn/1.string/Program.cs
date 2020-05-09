using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.InteropServices;
using System.Collections;
using System.Threading;
using System.Globalization;

namespace _1.@string
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 1,Toupper函数学习
            //String str = "xuexi";
            //str = str.ToUpper();
            //Console.WriteLine(str);

            Task task = AwaitOperator.Main();
            // AwaitOperator.Main();


            //callStringConstruction();
            //callStringOperator();
            //callStringSubString();
            //callFormatMethod();
            //WriteStream();
            //StringComparisonTest();
            //SurrogateTest();
            //StringIndexTest();
            //CloneTest();
            //CompareCopyClone();
            //CompareTest();
            //ReverseStringComparer reverStringComparer = new ReverseStringComparer();
            //TestReverseStringComparer tc = new TestReverseStringComparer();
            //tc.test();

            //StringBuilder sb = new StringBuilder();
            //for (int i=0;i<2;i++)
            //sb.Append("2");

            //Console.WriteLine(sb);

            //Console.Write("{0,10}", sb);


            Console.ReadLine();
        }





        //使用类的构造函数
        static void callStringConstruction()
        {
            char[] chars = { 'w', 'o', 'r', 'd' };
            sbyte[] bytes = { 0x41, 0x42, 0x43, 0x44, 0x45, 0x00 };

            // Create a string from a character array.
            string string1 = new string(chars);
            Console.WriteLine(string1);

            // Create a string that consists of a character repeated 20 times.
            string string2 = new string('c', 20);
            Console.WriteLine(string2);

            string stringFromBytes = null;
            string stringFromChars = null;
            unsafe
            {
                fixed (sbyte* pbytes = bytes)
                {
                    // Create a string from a pointer to a signed byte array.
                    stringFromBytes = new string(pbytes);
                }
                fixed (char* pchars = chars)
                {
                    // Create a string from a pointer to a character array.
                    stringFromChars = new string(pchars);
                }
            }
            Console.WriteLine(stringFromBytes);
            Console.WriteLine(stringFromChars);
        }

        //+ 连接
        static void callStringOperator()
        {
            string string1 = "Today is " + DateTime.Now.ToString("D") + ".";
            Console.WriteLine(string1);

            string string2 = "This is one sentence. " + "This is a second. ";
            string2 += "This is a third sentence.";
            Console.WriteLine(string2);
        }

        //substring 取一部分
        static void callStringSubString()
        {
            string sentence = "This sentence has five words.";
            // Extract the second word.
            int startPosition = sentence.IndexOf(" ") + 1;
            string word2 = sentence.Substring(startPosition,
                                              sentence.IndexOf(" ", startPosition) - startPosition);
            Console.WriteLine("Second word: " + word2);
            // The example displays the following output:
            //       Second word: sentence
        }

        //显示格式
        static void callFormatMethod()
        {
            DateTime dateAndTime = new DateTime(2011, 7, 6, 7, 32, 0);
            double temperature = 68.3;
            string result = String.Format("At {0:t} on {0:D}, the temperature was {1:F1} degrees Fahrenheit.",
                                          dateAndTime, temperature);
            Console.WriteLine(result);
            // The example displays the following output:
            //       At 7:32 AM on Wednesday, July 06, 2011, the temperature was 68.3 degrees Fahrenheit.
        }

        static void WriteStream()
        {
            StreamWriter sw = new StreamWriter(@".\graphemes.txt");
            string grapheme = "\u0061\u0308";
            sw.WriteLine(grapheme);

            string singleChar = "\u00e4";
            sw.WriteLine(singleChar);

            sw.WriteLine("{0} = {1} (Culture-sensitive): {2}", grapheme, singleChar,
                         String.Equals(grapheme, singleChar,
                                       StringComparison.CurrentCulture));
            sw.WriteLine("{0} = {1} (Ordinal): {2}", grapheme, singleChar,
                         String.Equals(grapheme, singleChar,
                                       StringComparison.Ordinal));
            sw.WriteLine("{0} = {1} (Normalized Ordinal): {2}", grapheme, singleChar,
                         String.Equals(grapheme.Normalize(),
                                       singleChar.Normalize(),
                                       StringComparison.Ordinal));
            sw.Close();

            // The example produces the following output:
            //       ä
            //       ä
            //       ä = ä (Culture-sensitive): True
            //       ä = ä (Ordinal): False
            //       ä = ä (Normalized Ordinal): True
        }
        static void StringComparisonTest()
        {
            string s1 = "visualstudio";
            string s2 = "windows";

            //StringComparison.Ordinal
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); //当前的区域信息是美国
            Console.WriteLine(String.Compare(s1, s2, StringComparison.Ordinal)); //输出"-1"

            Thread.CurrentThread.CurrentCulture = new CultureInfo("sv-SE"); //当前的区域信息是瑞典 
            Console.WriteLine(String.Compare(s1, s2, StringComparison.Ordinal)); //输出"-1"

            //StringComparison.CurrentCulture
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); //当前的区域信息是美国
            Console.WriteLine(String.Compare(s1, s2, StringComparison.CurrentCulture)); //输出"-1"

            Thread.CurrentThread.CurrentCulture = new CultureInfo("sv-SE"); //当前的区域信息是瑞典 
            Console.WriteLine(String.Compare(s1, s2, StringComparison.CurrentCulture)); //输出"1"

            //StringComparison.InvariantCulture
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); //当前的区域信息是美国
            Console.WriteLine(String.Compare(s1, s2, StringComparison.InvariantCulture)); //输出"-1"

            Thread.CurrentThread.CurrentCulture = new CultureInfo("sv-SE"); //当前的区域信息是瑞典
            Console.WriteLine(String.Compare(s1, s2, StringComparison.InvariantCulture)); //输出"-1"

        }

        static void SurrogateTest()
        {
            string surrogate = "\uD800\uDC03";
            for (int ctr = 0; ctr < surrogate.Length; ctr++)
                Console.Write("U+{0:X2} ", Convert.ToUInt16(surrogate[ctr]));

            Console.WriteLine();
            Console.WriteLine("   Is Surrogate Pair: {0}",
                              Char.IsSurrogatePair(surrogate[0], surrogate[1]));
            // The example displays the following output:
            //       U+D800 U+DC03
            //          Is Surrogate Pair: True
        }

        static void StringIndexTest()
        {
            string s1 = "This string consists of a single short sentence.";
            int nWords = 0;

            s1 = s1.Trim();
            for (int ctr = 0; ctr < s1.Length; ctr++)
            {
                if (Char.IsPunctuation(s1[ctr]) | Char.IsWhiteSpace(s1[ctr]))
                    nWords++;
            }
            Console.WriteLine("The sentence\n   {0}\nhas {1} words.",
                              s1, nWords);
            // The example displays the following output:
            //       The sentence
            //          This string consists of a single short sentence.
            //       has 8 words.
        }

        static void CloneTest()
        {
            // Create a Unicode String with 5 Greek Alpha characters
            String szGreekAlpha = new String('\u0319', 5);//Alpha
            // Create a Unicode String with a Greek Omega character
            String szGreekOmega = new String(new char[] { '\u03A9', '\u03A9', '\u03A9' }, 2, 1);// Omega

            String szGreekLetters = String.Concat(szGreekOmega, szGreekAlpha, szGreekOmega.Clone());

            // Examine the result
            Console.WriteLine(szGreekLetters);

            // The first index of Alpha
            int ialpha = szGreekLetters.IndexOf('\u0319');
            // The last index of Omega
            int iomega = szGreekLetters.LastIndexOf('\u03A9');

            Console.WriteLine("The Greek letter Alpha first appears at index " + ialpha +
                " and Omega last appears at index " + iomega + " in this String.");
        }

        static void CompareCopyClone()
        {
            string testr = "sss";
           
            //char[] destination = new char[1];
            //testr.CopyTo(0, destination, 0, 1);

            //Console.WriteLine("des="+destination[0]);

            //destination[0] = 'd';

            //Console.WriteLine("changedes=" + destination[0]+",testr="+testr);

            string cloneStr = testr.Clone().ToString();
            Console.WriteLine("cloneStr="+cloneStr + ",teststr=" + testr);
            Console.WriteLine("cloneStr addr=" + GetMemory(cloneStr) + "testr addr=" + GetMemory(testr));

            //cloneStr = "ccc";
            //Console.WriteLine("change cloneStr=" + cloneStr+",teststr="+testr);

            string testc = String.Copy(testr);
            Console.WriteLine("testc=" + testc + ",teststr=" + testr);
            Console.WriteLine("testc addr=" + GetMemory(testc) + "testr addr=" + GetMemory(testr));

            //testc = "ddd";
            //Console.WriteLine("change testc=" + testc + ",teststr=" + testr);
            //Console.WriteLine("testc addr="+ GetMemory(testc)+ "testr addr=" + GetMemory(testr));

            //testr = "mmmm";
            //Console.WriteLine("change testc=" + testc + ",teststr=" + testr);
        }
        public static string GetMemory(Object o)
        {
            GCHandle h = GCHandle.Alloc(o, GCHandleType.Pinned);
            IntPtr addr = h.AddrOfPinnedObject();
            return "0x" + addr.ToString("X");
        }

        static void CompareTest()
        {
            // Create upper-case characters from their Unicode code units.
            String stringUpper = "\x0041\x0042\x0043";

            // Create lower-case characters from their Unicode code units.
            String stringLower = "\x0061\x0062\x0063";

            // Display the strings.
            Console.WriteLine("Comparing '{0}' and '{1}':",
                            stringUpper, stringLower);

            // Compare the uppercased strings; the result is true.
            Console.WriteLine("The Strings are equal when capitalized? {0}",
                            String.Compare(stringUpper.ToUpper(), stringLower.ToUpper()) == 0
                                           ? "true" : "false");

            // The previous method call is equivalent to this Compare method, which ignores case.
            Console.WriteLine("The Strings are equal when case is ignored? {0}",
                            String.Compare(stringUpper, stringLower, true) == 0
                                           ? "true" : "false");

            // The example displays the following output:
            //       Comparing 'ABC' and 'abc':
            //       The Strings are equal when capitalized? true
            //       The Strings are equal when case is ignored? true
        }
    }

    public class AwaitOperator
    {
        public static async Task Main()
        {
            Task<int> downloading = DownloadDocsMainPageAsync();
            Console.WriteLine($"{nameof(Main)}: Launched downloading.");

            int bytesLoaded = await downloading;
            Console.WriteLine($"{nameof(Main)}: Downloaded {bytesLoaded} bytes.");
        }

        private static async Task<int> DownloadDocsMainPageAsync()
        {
            Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}: About to start downloading.");

            var client = new HttpClient();
            //byte[] content = await client.GetByteArrayAsync("https://docs.microsoft.com/en-us/");
            byte[] content = await client.GetByteArrayAsync("https://note.youdao.com/web/#/file/recent/note/WEBc3a447079740ad8a54b18542be5c0da0/");

            Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}: Finished downloading.");
            return content.Length;
        }
    }
}

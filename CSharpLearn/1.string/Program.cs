using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            Console.ReadLine();
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

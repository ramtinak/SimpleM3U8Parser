/*
 * Developer: Ramtin Jokar [ Ramtinak@live.com ] [ My Telegram Account: https://t.me/ramtinak ]
 * 
 * 
 * License: MIT
 * 
 */

using System;
using SimpleM3U8Parser;
using System.IO;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var m3u8Content = File.ReadAllText("../../../Sample.m3u8");
            var m3u8 = M3u8Parser.Parse(m3u8Content);

            foreach (var item in m3u8.Medias)
                Console.WriteLine(item.Path);

            Console.WriteLine("Duration: " + m3u8.Duration);
            Console.ReadLine();
        }
    }
}

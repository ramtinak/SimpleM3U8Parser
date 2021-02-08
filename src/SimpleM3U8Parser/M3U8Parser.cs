/*
 * Developer: Ramtin Jokar [ Ramtinak@live.com ] [ My Telegram Account: https://t.me/ramtinak ]
 * 
 * 
 * License: MIT
 * 
 */

using SimpleM3U8Parser.Exceptions;
using SimpleM3U8Parser.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SimpleM3U8Parser
{
    public class M3u8Parser
    {
        const string M3U8_TAG = "#EXTM3U";

        const string PATTERN = @"EXTINF:(?<duration>.*),\n(?<link>(\S+))";


        static public M3u8MediaContainer Parse(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException("M3u8Parser.Parse(content)");
            if (!content.Contains(M3U8_TAG))
                throw new ParserException("'content' is not a `m3u/m3u8` file.");
            var mediaList = new List<M3u8Media>();
            foreach (Match m in Regex.Matches(content, PATTERN))
            {
                var path = m.Groups["link"]?.Value;
                var duration = m.Groups["duration"]?.Value;
                if (!string.IsNullOrEmpty(path) && double.TryParse(duration, out double durationAsDouble))
                    mediaList.Add(new M3u8Media { Duration = durationAsDouble, Path = path });
            }
            var durations = mediaList.Select(m => m.Duration).ToArray();
            var container = new M3u8MediaContainer
            {
                Medias = mediaList,
                Duration = TimeSpan.FromSeconds(durations.Sum())
            };
            return container;
        }
    }
}
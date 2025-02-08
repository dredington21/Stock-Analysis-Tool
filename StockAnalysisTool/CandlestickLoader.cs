using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.LinkLabel;

namespace Project2
{
    public class CandlestickLoader
    {

        public static List<Candlestick> LoadFromFile(string filePath)
        {
            var candlesticks = new List<Candlestick>();
            // Return an empty list if the file does not exist
            if (!File.Exists(filePath))
            {

                return candlesticks;
            }
            // reads all lines from specified file
            var lines = File.ReadAllLines(filePath);
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                //string split options remove empty entries
                // make array of delimiters to remove comma and double quotes
                char[] delimiters = { ',', '"' };
                var parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                // parse in format yyyy--mm--dd
                var date = DateTime.Parse(parts[0], CultureInfo.InvariantCulture);
                // formats all variables in csv into a candlestick
                var open = decimal.Parse(parts[1]);
                var high = decimal.Parse(parts[2]);
                var low = decimal.Parse(parts[3]);
                var close = decimal.Parse(parts[4]);
                var volume = long.Parse(parts[5]);
                // adds each candlestick to a list of candlesticks
                candlesticks.Add(new Candlestick(date, open, high, low, close, volume));
            }
            // returns list of candlesticks
            return candlesticks;
        }
    }
}


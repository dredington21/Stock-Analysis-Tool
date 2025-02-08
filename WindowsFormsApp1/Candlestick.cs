using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class Candlestick
    {
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }

        public Candlestick(DateTime date, decimal open, decimal high, decimal low, decimal close, long volume)
        {
            Date = date;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            Volume = volume;
        }

        public override string ToString()
        {
            return $"Date: {Date}, Open: {Open}, High: {High}, Low: {Low}, Close: {Close}, Volume: {Volume}";
        }
    }
}
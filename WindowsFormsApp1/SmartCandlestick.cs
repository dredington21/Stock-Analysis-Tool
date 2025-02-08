using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class SmartCandlestick : Candlestick
    {
        // constructor for making smart candlestick from values
        public SmartCandlestick(DateTime date, decimal open, decimal high, decimal low, decimal close, long volume)
            : base(date, open, high, low, close, volume)
        {
        }
        // constructor for making smart candlestick from a candlestick
        public SmartCandlestick(Candlestick candlestick)
            : base(candlestick.Date, candlestick.Open, candlestick.High, candlestick.Low, candlestick.Close, candlestick.Volume)
        {
        }

        public decimal Range => High - Low;
        public decimal BodyRange => Math.Abs(Close - Open);
        public decimal TopPrice => Math.Max(Open, Close);
        public decimal BottomPrice => Math.Min(Open, Close);
        public decimal UpperTail => High - TopPrice;
        public decimal LowerTail => BottomPrice - Low;

        // switch statement to call appropriate function based on input
        public bool IsPattern(string pattern)
        {
            switch (pattern.ToLower())
            {
                case "marubozu":
                    return IsMarubozu();
                case "hammer":
                    return IsHammer();
                case "doji":
                    return IsDoji();
                case "dragonfly doji":
                    return IsDragonflyDoji();
                case "gravestone doji":
                    return IsGravestoneDoji();
                case "bullish":
                    return IsBullish();
                case "bearish":
                    return IsBearish();
                default:
                    return false;
            }
        }
        // Functions to determine if it is each type of pattern
        private bool IsBullish() => Close > Open;
        private bool IsBearish() => Close < Open;
        private bool IsMarubozu() => Open == Low && Close == High;
        private bool IsHammer() => BodyRange < (Range * 0.3m) && LowerTail > (BodyRange * 2);
        private bool IsDoji() => BodyRange < (Range * 0.1m);
        private bool IsDragonflyDoji() => IsDoji() && Open == High;
        private bool IsGravestoneDoji() => IsDoji() && Open == Low;
    }
}
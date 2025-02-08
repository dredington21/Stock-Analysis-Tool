using Project2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class Wave
    {
        public static Dictionary<string, decimal> ComputeFibonacciLevels(decimal high, decimal low)
        {
            decimal diff = high - low;
            return new Dictionary<string, decimal>
            {
                { "0%", low },
                { "23.6%", low + 0.236m * diff },
                { "38.2%", low + 0.382m * diff },
                { "50%", low + 0.5m * diff },
                { "61.8%", low + 0.618m * diff },
                { "76.4%", low + 0.764m * diff },
                { "100%", high }
            };
        }

        public static decimal ComputeInitialBeauty(List<Candlestick> candlesticks, Dictionary<string, decimal> fibonacciLevels)
        {
            
            decimal beauty = 0;
            foreach (var candlestick in candlesticks)
            {
                foreach (var level in fibonacciLevels.Values)
                {
                    if (candlestick.Low <= level && level <= candlestick.High)
                    {
                        beauty += 1;
                    }
                }
            }
            return beauty;
        }

        public static (List<decimal> prices, List<decimal> beautyValues) BeautyVsPrice(List<Candlestick> candlesticks, decimal initialBeauty, decimal startPrice, decimal endPrice, decimal step)
        {
            List<decimal> prices = new List<decimal>();
            List<decimal> beautyValues = new List<decimal>();

            for (decimal price = startPrice; price >= endPrice; price -= step)
            {
                prices.Add(price);

                // Recompute Fibonacci levels for the current price
                Dictionary<string, decimal> fibonacciLevels = Wave.ComputeFibonacciLevels(startPrice, price);

                // Recompute beauty for the current price
                decimal beauty = Wave.ComputeInitialBeauty(candlesticks, fibonacciLevels);
                beautyValues.Add(beauty);
            }

            return (prices, beautyValues);
        }
    }

    
}
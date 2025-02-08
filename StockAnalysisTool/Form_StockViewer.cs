using Microsoft.Win32.SafeHandles;
using Project2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace WindowsFormsApp1
{
    public partial class Form_StockViewer : Form
    {
        public Form_StockViewer()
        {
            InitializeComponent();
            //setDisplayType();
        }
        // List of all possible pattern options
        List<string> patterns = new List<string>
        {
            "Bullish",
            "Bearish",
            "Neutral",
            "Marubozu",
            "Hammer",
            "Doji",
            "Dragonfly doji",
            "Gravestone doji"
        };

        public Form_StockViewer(DateTime startDate, DateTime endDate, String filename)
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Opens file selector
            openFileDialog_load.ShowDialog();
            
        }

        private void openFileDialog_load_FileOk(object sender, CancelEventArgs e)
        {
            // Recieves name of opened file
            Text = openFileDialog_load.FileName;
            // Recieves string if multiple files selected
            string[] selectedFiles = openFileDialog_load.FileNames;
            // Records number of files selected
            int numberOfFilesSelected = selectedFiles.Length;
            

            // Load candlesticks
            var candlesticks = CandlestickLoader.LoadFromFile(Text);
            //Load dates selected
            DateTime startDate = dateTimePicker_startDate.Value;
            DateTime endDate = dateTimePicker_endDate.Value;
            // Filters candlesticks by date
            var filteredCandlesticks = candlesticks
            .Where(c => c.Date >= startDate && c.Date <= endDate)
            .ToList();
            // Normalizes max and min for chart to use
            
            decimal maxHigh = filteredCandlesticks.Max(c => c.High);
            decimal minLow = filteredCandlesticks.Min(c => c.Low);
            decimal adjustedMax = maxHigh * 1.02m;
            decimal adjustedMin = minLow * 0.98m;
            
            // Binding list of candlesticks
            var candlestickFinal = new BindingList<Candlestick>(filteredCandlesticks);

            // Clears previes data
            chart_stockData.Series.Clear();


            // Create and configure the candlestick series to specific chart area with normalized min and max
            Series candlestickSeries = new Series("Candlesticks");
            candlestickSeries.ChartType = SeriesChartType.Candlestick;
            candlestickSeries.ChartArea = "ChartArea_Candlesticks";
            candlestickSeries.IsXValueIndexed = true;
            chart_stockData.ChartAreas["ChartArea_Candlesticks"].AxisY.Minimum = (int)adjustedMin;
            chart_stockData.ChartAreas["ChartArea_Candlesticks"].AxisY.Maximum = (int)adjustedMax;


            // Create and configure the volume series to specific chart area with normalized min and max
            Series volumeSeries = new Series("Volume");
            volumeSeries.ChartType = SeriesChartType.Column;
            volumeSeries.ChartArea = "ChartArea_Volume";
            volumeSeries.IsXValueIndexed = true;

            // Add the series to the chart
            chart_stockData.Series.Add(candlestickSeries);
            chart_stockData.Series.Add(volumeSeries);

            // Bind the data to the candlestick series
            candlestickSeries.Points.DataBind(candlestickFinal, "Date", "High,Low,Open,Close", null);

            // Bind the data to the volume series
            volumeSeries.Points.DataBind(candlestickFinal, "Date", "Volume", null);

            candlestickSeries["PriceUpColor"] = "Green"; // Color for up candlesticks
            candlestickSeries["PriceDownColor"] = "Red"; // Color for down candlesticks
            // Adds appropriate options to combo box
            comboBox_candlestick.DataSource = filteredCandlesticks.Select(c =>c.Date).ToList();
            comboBox_pattern.DataSource = patterns;
            // Calls function to detect and anotate peaks and valleys
            DetectAndAnnotatePeaksAndValleys(filteredCandlesticks);
            List<Candlestick> PeaksAndValleys = new List<Candlestick>();
            for (int l = 1; l < filteredCandlesticks.Count - 1; l++)
            {
                var prev = filteredCandlesticks[l - 1];
                var current = filteredCandlesticks[l];
                var next = filteredCandlesticks[l + 1];

                // Determine if peak
                if (current.High > prev.High && current.High > next.High)
                {
                    // if peak add annotation
                    PeaksAndValleys.Add(current);
                }
                // Determine if valley
                else if (current.Low < prev.Low && current.Low < next.Low)
                {
                    // if valley add annotation 
                    PeaksAndValleys.Add(current);
                }
            }
            comboBox_PeaksValleys.DataSource = PeaksAndValleys;
            comboBox_PeaksValleys.DisplayMember = "Date";

            comboBox_secondCandlestick.DataSource = filteredCandlesticks;
            comboBox_secondCandlestick.DisplayMember = "Date"; // or any other property you want to display



            // Occurs if multiple files selected
            if (numberOfFilesSelected > 1)
            {
                // Loops through files excluding the first one which is the main form still
                for (int i = 2; i < numberOfFilesSelected + 1; i++)
                {
                    // creates new form and passess file name to each
                    Form_StockViewer newForm = new Form_StockViewer();
                    string[] fileNames = openFileDialog_load.FileNames;
                    newForm.Text = fileNames[i - 1];
                    // Loads candlesticks from appropraite file
                    candlesticks = CandlestickLoader.LoadFromFile(newForm.Text);

                    // filters candlesticks
                    filteredCandlesticks = candlesticks
                    .Where(c => c.Date >= startDate && c.Date <= endDate)
                    .ToList();
                    // normalizes data for charts
                    maxHigh = filteredCandlesticks.Max(c => c.High);
                    minLow = filteredCandlesticks.Min(c => c.Low);
                    adjustedMax = maxHigh * 1.02m;
                    adjustedMin = minLow * 0.98m;
                    // makes binding list
                    candlestickFinal = new BindingList<Candlestick>(filteredCandlesticks);
                    //clears previous data
                    newForm.chart_stockData.Series.Clear();

                    // Create and configure the candlestick series (same as above)
                    candlestickSeries = new Series("Candlesticks");
                    candlestickSeries.ChartType = SeriesChartType.Candlestick;
                    candlestickSeries.ChartArea = "ChartArea_Candlesticks";
                    candlestickSeries.IsXValueIndexed = true;
                    chart_stockData.ChartAreas["ChartArea_Candlesticks"].AxisY.Minimum = (int)adjustedMin;
                    chart_stockData.ChartAreas["ChartArea_Candlesticks"].AxisY.Maximum = (int)adjustedMax;

                    // Create and configure the volume series (same as above)
                    volumeSeries.ChartType = SeriesChartType.Column;
                    volumeSeries.ChartArea = "ChartArea_Volume";
                    volumeSeries.IsXValueIndexed = true;

                    // Add the series to the chart
                    newForm.chart_stockData.Series.Add(candlestickSeries);
                    newForm.chart_stockData.Series.Add(volumeSeries);

                    // Bind the data to the candlestick series
                    candlestickSeries.Points.DataBind(candlestickFinal, "Date", "High,Low,Open,Close", null);

                    // Bind the data to the volume series
                    volumeSeries.Points.DataBind(candlestickFinal, "Date", "Volume", null);

                    candlestickSeries["PriceUpColor"] = "Green"; // Color for up candlesticks
                    candlestickSeries["PriceDownColor"] = "Red"; // Color for down candlesticks

                    // pases values to combo box
                    newForm.comboBox_candlestick.DataSource = filteredCandlesticks.Select(c => c.Date).ToList();
                    newForm.comboBox_pattern.DataSource = patterns;
                    // calls detect and annotate peaks and valleys
                    DetectAndAnnotatePeaksAndValleys(filteredCandlesticks);
                    //var PeaksAndValleys = filteredCandlesticks;
                    PeaksAndValleys = new List<Candlestick>();
                    for (int l = 1; l < filteredCandlesticks.Count - 1; l++)
                    {
                        var prev = filteredCandlesticks[l - 1];
                        var current = filteredCandlesticks[l];
                        var next = filteredCandlesticks[l + 1];
                        
                        // Determine if peak
                        if (current.High > prev.High && current.High > next.High)
                        {
                            // if peak add annotation
                            PeaksAndValleys.Add(current);
                        }
                        // Determine if valley
                        else if (current.Low < prev.Low && current.Low < next.Low)
                        {
                            // if valley add annotation 
                            PeaksAndValleys.Add(current);
                        }
                    }
                    newForm.comboBox_PeaksValleys.DataSource = PeaksAndValleys;
                    newForm.comboBox_PeaksValleys.DisplayMember = "Date"; // or any other property you want to display
                    // make form visible
                    newForm.Show();
                    


                }
                // update the first form with default info ( it was glitching when multiple files were selected)
                button_update_Click(sender, e);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chart_stockData_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void chart_stockData_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_startDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form_StockViewer_Load(object sender, EventArgs e)
        {

        }

        public void button_update_Click(object sender, EventArgs e)
        {
            // load candlesticks
            var candlesticks = CandlestickLoader.LoadFromFile(Text);
            
            // load dates
            DateTime startDate = dateTimePicker_startDate.Value;
            DateTime endDate = dateTimePicker_endDate.Value;
            // filters based on dates
            var filteredCandlesticks = candlesticks
            .Where(c => c.Date >= startDate && c.Date <= endDate)
            .ToList();
            // Normalize min and max for chart
            decimal maxHigh = filteredCandlesticks.Max(c => c.High);
            decimal minLow = filteredCandlesticks.Min(c => c.Low);
            decimal adjustedMax = maxHigh * 1.02m;
            decimal adjustedMin = minLow * 0.98m;
            
            // make binding list
            var candlestickFinal = new BindingList<Candlestick>(filteredCandlesticks);

            // clear out previous data
            chart_stockData.Series.Clear();

            // Create and configure the candlestick series (same as above)
            Series candlestickSeries = new Series("Candlesticks");
            candlestickSeries.ChartType = SeriesChartType.Candlestick;
            candlestickSeries.ChartArea = "ChartArea_Candlesticks";
            candlestickSeries.IsXValueIndexed = true;

            chart_stockData.ChartAreas["ChartArea_Candlesticks"].AxisY.Minimum = (int)adjustedMin;
            chart_stockData.ChartAreas["ChartArea_Candlesticks"].AxisY.Maximum = (int)adjustedMax;

            // Create and configure the volume series (same as above)
            Series volumeSeries = new Series("Volume");
            volumeSeries.ChartType = SeriesChartType.Column;
            volumeSeries.ChartArea = "ChartArea_Volume";
            volumeSeries.IsXValueIndexed = true;


            // Add the series to the chart
            chart_stockData.Series.Add(candlestickSeries);
            chart_stockData.Series.Add(volumeSeries);

            // Bind the data to the candlestick series
            candlestickSeries.Points.DataBind(candlestickFinal, "Date", "High,Low,Open,Close", null);

            // Bind the data to the volume series
            volumeSeries.Points.DataBind(candlestickFinal, "Date", "Volume", null);

            candlestickSeries["PriceUpColor"] = "Green"; // Color for up candlesticks
            candlestickSeries["PriceDownColor"] = "Red"; // Color for down candlesticks
            // Detect and annotate peaks and valleys
            DetectAndAnnotatePeaksAndValleys(filteredCandlesticks);
            // pass values to combo boxes
            comboBox_candlestick.DataSource = filteredCandlesticks.Select(c => c.Date).ToList();
            comboBox_pattern.DataSource = patterns;

            List<Candlestick> PeaksAndValleys = new List<Candlestick>();
            for (int l = 1; l < filteredCandlesticks.Count - 1; l++)
            {
                var prev = filteredCandlesticks[l - 1];
                var current = filteredCandlesticks[l];
                var next = filteredCandlesticks[l + 1];

                // Determine if peak
                if (current.High > prev.High && current.High > next.High)
                {
                    // if peak add annotation
                    PeaksAndValleys.Add(current);
                }
                // Determine if valley
                else if (current.Low < prev.Low && current.Low < next.Low)
                {
                    // if valley add annotation 
                    PeaksAndValleys.Add(current);
                }
            }
            comboBox_PeaksValleys.DataSource = PeaksAndValleys;
            comboBox_PeaksValleys.DisplayMember = "Date";

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_candlestick_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_checkResult_Click(object sender, EventArgs e)
        {
            // recieve values from combo boxes
            string selectedCandlestick = comboBox_candlestick.Text;
            string selectedPattern = comboBox_pattern.Text;
            DateTime targetDate = DateTime.Parse(selectedCandlestick);
            // load candlesticks and find the one that is specified
            var candlesticks = CandlestickLoader.LoadFromFile(Text);
            Candlestick foundCandlestick = candlesticks.FirstOrDefault(c => c.Date == targetDate);
            // convert it to a smart candlestick
            SmartCandlestick smartCandlestick = new SmartCandlestick(foundCandlestick);
            // check if it is the specified pattern
            bool patternResult = smartCandlestick.IsPattern(selectedPattern);
            // depending on result change the value in the label_answer to reflect it
            if (patternResult == true)
            {
                label_answer.Text = "Answer:  True";
            }
            if (patternResult == false)
            {
                label_answer.Text = "Answer:  False";
            }
        }

        void DetectAndAnnotatePeaksAndValleys(List<Candlestick> candlesticks)
        {
            // clear previous annotations
            chart_stockData.Annotations.Clear();
            // for each candlestick loop
            
            for (int i = 1; i < candlesticks.Count - 1; i++)
            {
                var prev = candlesticks[i - 1];
                var current = candlesticks[i];
                var next = candlesticks[i + 1];
                
                // Determine if peak
                if (current.High > prev.High && current.High > next.High)
                {
                    // if peak add annotation
                    AddAnnotation(current.Date, current.High, "Peak", Color.Green);
                }
                // Determine if valley
                else if (current.Low < prev.Low && current.Low < next.Low)
                {
                    // if valley add annotation
                    AddAnnotation(current.Date, current.Low, "Valley", Color.Red);
                }
            }
            //return finalcandlesticks;
        }
        void AddAnnotation(DateTime date, decimal price, string label, Color color)
        {
            // create annotation
            var annotation = new TextAnnotation
            {
                Text = label,
                X = date.ToOADate(),
                Y = (double)price,
                ForeColor = color,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
            // add annotation to chart
            chart_stockData.Annotations.Add(annotation);
            // add horizontal line annotation
            var line = new HorizontalLineAnnotation
            {
                AxisX = chart_stockData.ChartAreas[0].AxisX,
                AxisY = chart_stockData.ChartAreas[0].AxisY,
                IsInfinitive = true,
                ClipToChartArea = chart_stockData.ChartAreas[0].Name,
                LineColor = color,
                LineWidth = 2,
                Y = (double)price
            };
            // add line annotation
            chart_stockData.Annotations.Add(line);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox_PeaksValleys_SelectedIndexChanged(object sender, EventArgs e)
        {
            var candlesticks = CandlestickLoader.LoadFromFile(Text);

            // load dates
            DateTime startDate = dateTimePicker_startDate.Value;
            DateTime endDate = dateTimePicker_endDate.Value;
            // filters based on dates
            var filteredCandlesticks = candlesticks
            .Where(c => c.Date >= startDate && c.Date <= endDate)
            .ToList();
            // calculate candlesticks within the selected beauty
            var beautyCandlesticks= candlesticks
            .Where(c => c.Date >= startDate && c.Date <= endDate)
            .ToList();


            var candlestick1 = comboBox_PeaksValleys.SelectedItem;
            // assign values to combo box for Peaks and Valleys
            if (comboBox_PeaksValleys.SelectedItem is Candlestick selectedCandlestick)
            {
                DateTime selectedDate = selectedCandlestick.Date;

                var filteredAfterSelectedDate = filteredCandlesticks
                .Where(c => c.Date > selectedDate)
                .ToList();

                //comboBox_secondCandlestick.DataSource = filteredAfterSelectedDate.Select(c => c.Date).ToList();
                comboBox_secondCandlestick.DataSource = filteredAfterSelectedDate;
                comboBox_secondCandlestick.DisplayMember = "Date"; // or any other property you want to display
            }




        }

        private void button_calculate_Beauty_Click(object sender, EventArgs e)
        {

            var candlesticks = CandlestickLoader.LoadFromFile(Text);
            DateTime startDate = dateTimePicker_startDate.Value;
            DateTime endDate = dateTimePicker_endDate.Value;

            // Filter based on dates
            var filteredCandlesticks = candlesticks
                .Where(c => c.Date >= startDate && c.Date <= endDate)
                .ToList();
            // checks to make sure combo boxes contain candlesticks
            if (comboBox_PeaksValleys.SelectedItem is Candlestick candlestick1 &&
                comboBox_secondCandlestick.SelectedItem is Candlestick candlestick2)
            {
                if (candlestick1.High > candlestick2.High || candlestick1.Low < candlestick2.Low)
                {
                    // step is the value difference between beauties
                    decimal step = 0.5m;
                    Dictionary<string, decimal> fibonacciLevels;
                    decimal initialBeauty;
                    List<decimal> prices, beautyValues;
                    // If down wave
                    if (candlestick1.High > candlestick2.High)
                    {
                        fibonacciLevels = Wave.ComputeFibonacciLevels(candlestick1.High, candlestick2.Low*(1-(numericUpDown_extendWave.Value *0.01m)));
                        AddFibonacciLevels(chart_stockData, "ChartArea_Candlesticks", fibonacciLevels);
                        initialBeauty = Wave.ComputeInitialBeauty(filteredCandlesticks, fibonacciLevels);
                        //Console.WriteLine(initialBeauty.ToString(), "Initial");
                        (prices, beautyValues) = Wave.BeautyVsPrice(filteredCandlesticks, initialBeauty, candlestick1.High, candlestick2.Low * (1 - (numericUpDown_extendWave.Value * 0.01m)), step);
                        //Console.WriteLine(prices.ToString(), " prices");
                        AddFibonacciAnnotations(chart_stockData, "Candlesticks", fibonacciLevels);
                    }
                    // If up wave
                    else
                    {
                        fibonacciLevels = Wave.ComputeFibonacciLevels(candlestick2.High * (1+(numericUpDown_extendWave.Value *.01m)), candlestick1.Low);
                        AddFibonacciLevels(chart_stockData, "ChartArea_Candlesticks", fibonacciLevels);
                        initialBeauty = Wave.ComputeInitialBeauty(filteredCandlesticks, fibonacciLevels);
                       // Console.WriteLine(initialBeauty.ToString(), "Initial");
                        (prices, beautyValues) = Wave.BeautyVsPrice(filteredCandlesticks, initialBeauty, candlestick2.High * (1 + (numericUpDown_extendWave.Value * .01m)), candlestick1.Low, step);
                        AddFibonacciAnnotations(chart_stockData, "Candlesticks", fibonacciLevels);
                    }

                    // Clear existing series in the chart area
                    foreach (var series in chart_stockData.Series.ToList())
                    {
                        if (series.ChartArea == "ChartArea_Volume")
                        {
                            chart_stockData.Series.Remove(series);
                        }
                    }

                    // Create and configure the new series
                    Series beautySeries = new Series("Beauty")
                    {
                        ChartType = SeriesChartType.Line,
                        ChartArea = "ChartArea_Volume",
                        IsXValueIndexed = false
                    };
                    chart_stockData.Series.Add(beautySeries);

                    // Set the axis ranges
                    chart_stockData.ChartAreas["ChartArea_Volume"].AxisX.Minimum = Math.Round((double)prices.Min(), 2);
                    chart_stockData.ChartAreas["ChartArea_Volume"].AxisX.Maximum = Math.Round((double)prices.Max(), 2);
                    chart_stockData.ChartAreas["ChartArea_Volume"].AxisY.Minimum = (double)beautyValues.Min() * 0.75;
                    chart_stockData.ChartAreas["ChartArea_Volume"].AxisY.Maximum = (double)beautyValues.Max() * 1.25;

                    
                    // Bind the data to the series
                    beautySeries.Points.DataBindXY(prices, beautyValues);
                    
                }
                else
                {
                    Console.WriteLine("The selected wave is not valid. Please select a valid wave.");
                }
            }
            else
            {
                Console.WriteLine("Please select both candlesticks.");
            }
        }


        private void AddFibonacciLevels(Chart chart, string chartArea, Dictionary<string, decimal> levels)
        {
            // Clear existing annotations
            chart.Annotations.Clear();

            // Calculate the minimum and maximum Y values
            if (levels.Count > 0)
            {
                decimal minValue = levels.Values.Min();
                decimal maxValue = levels.Values.Max();

                double minimum = Math.Round((double)(minValue * 0.98m), 2); // 2% less than the lowest value, rounded to 2 decimals
                double maximum = Math.Round((double)(maxValue * 1.02m), 2); // 2% more than the highest value, rounded to 2 decimals

                // Set the Y-axis range
                chart.ChartAreas[chartArea].AxisY.Minimum = minimum;
                chart.ChartAreas[chartArea].AxisY.Maximum = maximum;
            }

            double minX = 0; // Set the starting X value
            double maxX = 1000; // Set the ending X value

            foreach (var level in levels)
            {
                HorizontalLineAnnotation line = new HorizontalLineAnnotation
                {
                    AxisX = chart.ChartAreas[chartArea].AxisX,
                    AxisY = chart.ChartAreas[chartArea].AxisY,
                    Y = (double)level.Value,
                    LineColor = Color.Blue, // Change the color to blue
                    LineWidth = 1, // Increase the width
                    LineDashStyle = ChartDashStyle.Solid, // Change the style to solid
                    X = minX, // Set the starting X value
                    Width = maxX - minX // Set the width to span from minX to maxX
                };
                chart.Annotations.Add(line);

                // Add a text annotation for the label
                TextAnnotation label = new TextAnnotation
                {
                    AxisX = chart.ChartAreas[chartArea].AxisX,
                    AxisY = chart.ChartAreas[chartArea].AxisY,
                    AnchorY = (double)level.Value,
                    Text = level.Key,
                    ForeColor = Color.Black, // Customize the text color
                    Font = new Font("Arial", 10, FontStyle.Bold) // Customize the font
                };
                chart.Annotations.Add(label);

                Console.WriteLine($"Drawing line at level: {level.Key} with value: {level.Value}");
            }

            // Refresh the chart to ensure annotations are displayed
            chart.Invalidate();
        }

        public void AddFibonacciAnnotations(Chart chart, string seriesName, Dictionary<string, decimal> levels)
        {
            // Ensure the series exists
            Series candlestickSeries = chart.Series.FirstOrDefault(s => s.Name == seriesName);
            Console.WriteLine(candlestickSeries);
            if (candlestickSeries == null)
            {
                throw new ArgumentException($"Series '{seriesName}' does not exist in the chart.");
            }

            // Add annotations for Fibonacci levels
            foreach (var level in levels.Values)
            {
                foreach (var point in candlestickSeries.Points)
                {
                    double high = point.YValues[1];
                    double low = point.YValues[2];
                    // determine if sequence meets a point
                    if ((low <= (double)level && (double)level <= high) || (high <= (double)level && (double)level <= low))
                    {
                        TextAnnotation annotation = new TextAnnotation
                        {
                            Text = "•",
                            AnchorDataPoint = point,
                            AnchorY = (double)level,
                            Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                            ForeColor = System.Drawing.Color.Red,
                            Alignment = ContentAlignment.MiddleCenter
                        };
                        chart.Annotations.Add(annotation);
                        
                    }
                }
            }
        }
    }

}

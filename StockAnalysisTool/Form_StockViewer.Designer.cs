namespace WindowsFormsApp1
{
    partial class Form_StockViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart_stockData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_loadStocks = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.openFileDialog_load = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_candlestick = new System.Windows.Forms.ComboBox();
            this.comboBox_pattern = new System.Windows.Forms.ComboBox();
            this.label_patternResult = new System.Windows.Forms.Label();
            this.label_patternSelect = new System.Windows.Forms.Label();
            this.candlestickSelect = new System.Windows.Forms.Label();
            this.button_checkResult = new System.Windows.Forms.Button();
            this.label_answer = new System.Windows.Forms.Label();
            this.comboBox_PeaksValleys = new System.Windows.Forms.ComboBox();
            this.label_Peak_or_Valley = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_secondCandlestick = new System.Windows.Forms.ComboBox();
            this.button_calculate_Beauty = new System.Windows.Forms.Button();
            this.numericUpDown_extendWave = new System.Windows.Forms.NumericUpDown();
            this.label_extendWave = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_extendWave)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_stockData
            // 
            chartArea3.Name = "ChartArea_Candlesticks";
            chartArea4.Name = "ChartArea_Volume";
            this.chart_stockData.ChartAreas.Add(chartArea3);
            this.chart_stockData.ChartAreas.Add(chartArea4);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chart_stockData.Legends.Add(legend2);
            this.chart_stockData.Location = new System.Drawing.Point(58, 29);
            this.chart_stockData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chart_stockData.Name = "chart_stockData";
            series3.ChartArea = "ChartArea_Candlesticks";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.XValueMember = "Date";
            series3.YValueMembers = "High, Low, Open, Close";
            series3.YValuesPerPoint = 4;
            series4.ChartArea = "ChartArea_Volume";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.IsXValueIndexed = true;
            series4.Legend = "Legend1";
            series4.Name = "Series2";
            series4.XValueMember = "Date";
            series4.YValueMembers = "Volume";
            this.chart_stockData.Series.Add(series3);
            this.chart_stockData.Series.Add(series4);
            this.chart_stockData.Size = new System.Drawing.Size(473, 244);
            this.chart_stockData.TabIndex = 0;
            this.chart_stockData.Text = "chart1";
            this.chart_stockData.BindingContextChanged += new System.EventHandler(this.chart_stockData_BindingContextChanged);
            this.chart_stockData.Click += new System.EventHandler(this.chart_stockData_Click);
            // 
            // button_loadStocks
            // 
            this.button_loadStocks.Location = new System.Drawing.Point(84, 391);
            this.button_loadStocks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_loadStocks.Name = "button_loadStocks";
            this.button_loadStocks.Size = new System.Drawing.Size(86, 24);
            this.button_loadStocks.TabIndex = 1;
            this.button_loadStocks.Text = "Pick a Stock";
            this.button_loadStocks.UseVisualStyleBackColor = true;
            this.button_loadStocks.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(281, 390);
            this.button_update.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(112, 25);
            this.button_update.TabIndex = 2;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(266, 350);
            this.dateTimePicker_endDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(177, 20);
            this.dateTimePicker_endDate.TabIndex = 3;
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(45, 350);
            this.dateTimePicker_startDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(169, 20);
            this.dateTimePicker_startDate.TabIndex = 4;
            this.dateTimePicker_startDate.Value = new System.DateTime(2022, 1, 1, 13, 50, 0, 0);
            this.dateTimePicker_startDate.ValueChanged += new System.EventHandler(this.dateTimePicker_startDate_ValueChanged);
            // 
            // openFileDialog_load
            // 
            this.openFileDialog_load.FileName = "openFileDialog1";
            this.openFileDialog_load.Filter = "All Files|*-*.csv|Monthly| *-Month.csv|Weekly|*-Week.csv|Daily|*-Day.csv";
            this.openFileDialog_load.Multiselect = true;
            this.openFileDialog_load.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_load_FileOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 304);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Start Date";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 304);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select End Date";
            // 
            // comboBox_candlestick
            // 
            this.comboBox_candlestick.FormattingEnabled = true;
            this.comboBox_candlestick.Location = new System.Drawing.Point(607, 73);
            this.comboBox_candlestick.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_candlestick.Name = "comboBox_candlestick";
            this.comboBox_candlestick.Size = new System.Drawing.Size(104, 21);
            this.comboBox_candlestick.TabIndex = 8;
            this.comboBox_candlestick.SelectedIndexChanged += new System.EventHandler(this.comboBox_candlestick_SelectedIndexChanged);
            // 
            // comboBox_pattern
            // 
            this.comboBox_pattern.FormattingEnabled = true;
            this.comboBox_pattern.Location = new System.Drawing.Point(598, 185);
            this.comboBox_pattern.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_pattern.Name = "comboBox_pattern";
            this.comboBox_pattern.Size = new System.Drawing.Size(102, 21);
            this.comboBox_pattern.TabIndex = 9;
            // 
            // label_patternResult
            // 
            this.label_patternResult.AutoSize = true;
            this.label_patternResult.Location = new System.Drawing.Point(698, 177);
            this.label_patternResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_patternResult.Name = "label_patternResult";
            this.label_patternResult.Size = new System.Drawing.Size(0, 13);
            this.label_patternResult.TabIndex = 10;
            // 
            // label_patternSelect
            // 
            this.label_patternSelect.AutoSize = true;
            this.label_patternSelect.Location = new System.Drawing.Point(579, 132);
            this.label_patternSelect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_patternSelect.Name = "label_patternSelect";
            this.label_patternSelect.Size = new System.Drawing.Size(195, 13);
            this.label_patternSelect.TabIndex = 11;
            this.label_patternSelect.Text = "What Pattern Would you like to Check?";
            this.label_patternSelect.Click += new System.EventHandler(this.label4_Click);
            // 
            // candlestickSelect
            // 
            this.candlestickSelect.AutoSize = true;
            this.candlestickSelect.Location = new System.Drawing.Point(579, 29);
            this.candlestickSelect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.candlestickSelect.Name = "candlestickSelect";
            this.candlestickSelect.Size = new System.Drawing.Size(224, 13);
            this.candlestickSelect.TabIndex = 12;
            this.candlestickSelect.Text = "What Candlestick Would You like to Analyze?";
            // 
            // button_checkResult
            // 
            this.button_checkResult.Location = new System.Drawing.Point(598, 262);
            this.button_checkResult.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_checkResult.Name = "button_checkResult";
            this.button_checkResult.Size = new System.Drawing.Size(100, 36);
            this.button_checkResult.TabIndex = 13;
            this.button_checkResult.Text = "Check";
            this.button_checkResult.UseVisualStyleBackColor = true;
            this.button_checkResult.Click += new System.EventHandler(this.button_checkResult_Click);
            // 
            // label_answer
            // 
            this.label_answer.AutoSize = true;
            this.label_answer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_answer.Location = new System.Drawing.Point(619, 334);
            this.label_answer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_answer.Name = "label_answer";
            this.label_answer.Size = new System.Drawing.Size(48, 13);
            this.label_answer.TabIndex = 14;
            this.label_answer.Text = "Answer: ";
            // 
            // comboBox_PeaksValleys
            // 
            this.comboBox_PeaksValleys.FormattingEnabled = true;
            this.comboBox_PeaksValleys.Location = new System.Drawing.Point(893, 185);
            this.comboBox_PeaksValleys.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_PeaksValleys.Name = "comboBox_PeaksValleys";
            this.comboBox_PeaksValleys.Size = new System.Drawing.Size(92, 21);
            this.comboBox_PeaksValleys.TabIndex = 15;
            this.comboBox_PeaksValleys.SelectedIndexChanged += new System.EventHandler(this.comboBox_PeaksValleys_SelectedIndexChanged);
            // 
            // label_Peak_or_Valley
            // 
            this.label_Peak_or_Valley.AutoSize = true;
            this.label_Peak_or_Valley.Location = new System.Drawing.Point(877, 132);
            this.label_Peak_or_Valley.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Peak_or_Valley.Name = "label_Peak_or_Valley";
            this.label_Peak_or_Valley.Size = new System.Drawing.Size(108, 13);
            this.label_Peak_or_Valley.TabIndex = 16;
            this.label_Peak_or_Valley.Text = "Select Peak or Valley";
            this.label_Peak_or_Valley.Click += new System.EventHandler(this.label3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(858, 243);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Select Second Candlestick for Beauty";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // comboBox_secondCandlestick
            // 
            this.comboBox_secondCandlestick.FormattingEnabled = true;
            this.comboBox_secondCandlestick.Location = new System.Drawing.Point(895, 296);
            this.comboBox_secondCandlestick.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_secondCandlestick.Name = "comboBox_secondCandlestick";
            this.comboBox_secondCandlestick.Size = new System.Drawing.Size(92, 21);
            this.comboBox_secondCandlestick.TabIndex = 18;
            // 
            // button_calculate_Beauty
            // 
            this.button_calculate_Beauty.Location = new System.Drawing.Point(888, 350);
            this.button_calculate_Beauty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_calculate_Beauty.Name = "button_calculate_Beauty";
            this.button_calculate_Beauty.Size = new System.Drawing.Size(97, 19);
            this.button_calculate_Beauty.TabIndex = 19;
            this.button_calculate_Beauty.Text = "Calculate Beauty";
            this.button_calculate_Beauty.UseVisualStyleBackColor = true;
            this.button_calculate_Beauty.Click += new System.EventHandler(this.button_calculate_Beauty_Click);
            // 
            // numericUpDown_extendWave
            // 
            this.numericUpDown_extendWave.Location = new System.Drawing.Point(895, 73);
            this.numericUpDown_extendWave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_extendWave.Name = "numericUpDown_extendWave";
            this.numericUpDown_extendWave.Size = new System.Drawing.Size(90, 20);
            this.numericUpDown_extendWave.TabIndex = 20;
            // 
            // label_extendWave
            // 
            this.label_extendWave.AutoSize = true;
            this.label_extendWave.Location = new System.Drawing.Point(826, 29);
            this.label_extendWave.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_extendWave.Name = "label_extendWave";
            this.label_extendWave.Size = new System.Drawing.Size(218, 13);
            this.label_extendWave.TabIndex = 21;
            this.label_extendWave.Text = "What Percentage Would You Like to Extend";
            // 
            // Form_StockViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 444);
            this.Controls.Add(this.label_extendWave);
            this.Controls.Add(this.numericUpDown_extendWave);
            this.Controls.Add(this.button_calculate_Beauty);
            this.Controls.Add(this.comboBox_secondCandlestick);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_Peak_or_Valley);
            this.Controls.Add(this.comboBox_PeaksValleys);
            this.Controls.Add(this.label_answer);
            this.Controls.Add(this.button_checkResult);
            this.Controls.Add(this.candlestickSelect);
            this.Controls.Add(this.label_patternSelect);
            this.Controls.Add(this.label_patternResult);
            this.Controls.Add(this.comboBox_pattern);
            this.Controls.Add(this.comboBox_candlestick);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.button_update);
            this.Controls.Add(this.button_loadStocks);
            this.Controls.Add(this.chart_stockData);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form_StockViewer";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_StockViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_stockData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_extendWave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_stockData;
        private System.Windows.Forms.Button button_loadStocks;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.OpenFileDialog openFileDialog_load;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_candlestick;
        private System.Windows.Forms.ComboBox comboBox_pattern;
        private System.Windows.Forms.Label label_patternResult;
        private System.Windows.Forms.Label label_patternSelect;
        private System.Windows.Forms.Label candlestickSelect;
        private System.Windows.Forms.Button button_checkResult;
        private System.Windows.Forms.Label label_answer;
        private System.Windows.Forms.ComboBox comboBox_PeaksValleys;
        private System.Windows.Forms.Label label_Peak_or_Valley;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_secondCandlestick;
        private System.Windows.Forms.Button button_calculate_Beauty;
        private System.Windows.Forms.NumericUpDown numericUpDown_extendWave;
        private System.Windows.Forms.Label label_extendWave;
    }
}


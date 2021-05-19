using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MazeSolverQLearning
{
    public partial class ChartForm : Form
    {
        public Chart chart = null;
        public ChartForm()
        {
            InitializeComponent();
        }

        private void Chart_Load(object sender, EventArgs e)
        {
         

            CreateChart();
        }

        private void CreateChart()
        {
            chart = new Chart();
            chart.Dock = DockStyle.Fill;
            chart.Location = new Point(10, 10);
            chart.Width = 1153;
            chart.Height = 593;
            chart.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            firstSeries();
            secondSeries();
            chart.Series[0].IsVisibleInLegend = true;
            chart.Legends.Add(new Legend("Legend2"));
            chart.Legends[0].Docking = Docking.Top;
            this.Controls.Add(chart);
        }

        private void firstSeries()
        {
            ChartArea chartArea = new ChartArea();
            chartArea.Name = "First Area";
            chart.ChartAreas.Add(chartArea);


            chartArea.BackColor = Color.Azure;
            chartArea.BackGradientStyle = GradientStyle.HorizontalCenter;
            chartArea.BackHatchStyle = ChartHatchStyle.LargeGrid;
            chartArea.BorderDashStyle = ChartDashStyle.Solid;
            chartArea.BorderWidth = 1;
            chartArea.BorderColor = Color.Red;
            chartArea.ShadowColor = Color.Purple;
            chartArea.ShadowOffset = 0;
            chart.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;
            chart.ChartAreas[0].Axes[1].MajorGrid.Enabled = false;
            chartArea.CursorX.IsUserEnabled = true;
            chartArea.CursorX.AxisType = AxisType.Primary;
            chartArea.CursorX.Interval = 1;
            chartArea.CursorX.LineWidth = 1;
            chartArea.CursorX.LineDashStyle = ChartDashStyle.Dash;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.CursorX.SelectionColor = Color.Yellow;
            chartArea.CursorX.AutoScroll = true;

            chartArea.CursorY.IsUserEnabled = true;
            chartArea.CursorY.AxisType = AxisType.Primary;
            chartArea.CursorY.Interval = 1;
            chartArea.CursorY.LineWidth = 1;
            chartArea.CursorY.LineDashStyle = ChartDashStyle.Dash;
            chartArea.CursorY.IsUserSelectionEnabled = true;
            chartArea.CursorY.SelectionColor = Color.Yellow;
            chartArea.CursorY.AutoScroll = true;

            chartArea.AxisY.Title = @"Adım Sayısı - Kazanç";
            chartArea.AxisX.Minimum = 0d;
            chartArea.AxisX.Maximum = Convert.ToDouble(Game.SuccessScore.Count);
            chartArea.AxisX.IsLabelAutoFit = true;
            chartArea.AxisX.LabelAutoFitMinFontSize = 5;
            chartArea.AxisX.LabelStyle.Angle = -20;
            chartArea.AxisX.LabelStyle.IsEndLabelVisible = true;
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chartArea.AxisX.IntervalType = DateTimeIntervalType.NotSet;
            chartArea.AxisX.Title = @"İterasyonlar";
            chartArea.AxisX.TextOrientation = TextOrientation.Auto;
            chartArea.AxisX.LineWidth = 2;
            chartArea.AxisX.LineColor = Color.DarkOrchid;
            chartArea.AxisX.Enabled = AxisEnabled.True;
            chartArea.AxisX.ScaleView.MinSizeType = DateTimeIntervalType.Months;
            chartArea.AxisX.ScrollBar = new AxisScrollBar();

            Series series1 = new Series();
            series1.ChartArea = "First Area";
            chart.Series.Add(series1);

            series1.Name = @"series：Test One";
            series1.ChartType = SeriesChartType.Line;
            series1.BorderWidth = 2;
            series1.Color = Color.Blue;
            series1.XValueType = ChartValueType.Int32;
            series1.YValueType = ChartValueType.Int32;

            series1.MarkerStyle = MarkerStyle.Circle;
            series1.MarkerSize = 8;
            series1.MarkerStep = 1;
            series1.MarkerColor = Color.Blue;
            series1.ToolTip = @"ToolTip";

            series1.IsValueShownAsLabel = true;
            series1.SmartLabelStyle.Enabled = true;
            series1.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
            series1.LabelForeColor = Color.Gray;
            series1.LabelToolTip = @"LabelToolTip";

            series1.Label = "#VALY{#.###}";

            DataPointCustomProperties p = new DataPointCustomProperties();
            p.Color = Color.Blue;
            series1.EmptyPointStyle = p;
            series1.IsVisibleInLegend = true;
            series1.LegendText = "Kazanç";
            series1.LegendToolTip = @"LegendToolTip";


            int x = 0;

            foreach (float v in Game.SuccessScore)
            {
                series1.Points.AddXY(x, v);
                x++;
            }
        }

        private void secondSeries()
        {
            Series series1 = new Series("");
            chart.Series.Add(series1);
            chart.Series[1].YAxisType = AxisType.Secondary;

            series1.Name = @"series：Test Two";
            series1.ChartType = SeriesChartType.Spline;
            series1.BorderWidth = 2;
            series1.Color = Color.Orange;
            series1.XValueType = ChartValueType.Int32;
            series1.YValueType = ChartValueType.Int32;

            series1.MarkerStyle = MarkerStyle.Circle;
            series1.MarkerSize = 8;
            series1.MarkerStep = 1;
            series1.MarkerColor = Color.Orange;
            series1.ToolTip = @"ToolTip";

            series1.IsValueShownAsLabel = true;
            series1.SmartLabelStyle.Enabled = true;
            series1.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
            series1.LabelForeColor = Color.Red;
            series1.LabelToolTip = @"LabelToolTip";

            series1.IsVisibleInLegend = true;
            series1.LegendText = "Adım Sayısı";
            series1.LegendToolTip = @"LegendToolTip";

            int x = 0;
    
            foreach (float v in Game.StepCount)
            {
                series1.Points.AddXY(x, v);
                x++;
            }
        }

    }
}

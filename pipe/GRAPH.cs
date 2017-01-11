using System;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace pipe
{
    public partial class GRAPH : Form
    {
        public GRAPH()
        {
            InitializeComponent();
        }
        public void DO_GRAPH(Chart chart_name, int flag)
        {
            chart_name.Series[0].Points.Clear();
            chart_name.Series[0].ChartType = SeriesChartType.Spline;
            chart_name.Series[0].BorderWidth = 5;
            switch (flag)
            {
                case 1:
                    chart_name.ChartAreas[0].AxisX.Title = "Диаметр, [м]";
                    chart_name.ChartAreas[0].AxisY.Title = "Скорость, [м/с]";
                    double flow = 28000;
                    double[] diameter = new double[12];

                    for (int i = 1; i < diameter.Length; i++)
                    {
                        diameter[i] = i;
                        chart_name.Series[0].Points.AddXY(diameter[i], flow / (0.785 * Math.Pow(diameter[i], 2) * 1 * 3600));

                    }
                    break;

                case 2:
                    chart_name.ChartAreas[0].AxisX.Title = "Скорость, [м/с]";
                    chart_name.ChartAreas[0].AxisY.Title = "Гидравлическое сопротивление, [Па]";
                    double e = 144.15;
                    double p = 0.886;
                    double[] speed = new double[120];
                    for (int i = 1; i < speed.Length; i++)
                    {
                        speed[i] = i;
                        chart_name.Series[0].Points.AddXY(speed[i], e * p * (Math.Pow(speed[i],2)/2)/1000);

                    }
                    break;
            }
        }

        private void GRAPH_Load(object sender, EventArgs e)
        {
            DO_GRAPH(chart1, 1);
            DO_GRAPH(chart2, 2);
        }

       
    }
}

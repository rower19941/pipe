using System.Windows;
using System;
using HelixToolkit.Wpf;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using System.Globalization;
using System.Threading;

namespace pipe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class Cleaner
    {
        public double _flow_rate;
        public double _diameter;
        public double _optimal_speed;
        public double _hydro_resistance;
        
        public double d_Flow_rate
        {
            get { return _flow_rate;  }
            set { _flow_rate = value; }
        }
        public double d_Diameter
        {
            get { return _diameter;  }
            set { _diameter = value; }
        }
        public double d_Optimal_speed
        {
            get { return _optimal_speed;  }
            set { _optimal_speed = value; }
        }
        public double d_Hydro_resistance
        {
            get { return _hydro_resistance;  }
            set { _hydro_resistance = value; }
        }
        public double Calculate_real_speed()
        {  
            return (d_Flow_rate) / ((Math.PI / 4) * Math.Pow(d_Diameter, 2) * 3600);
        }
        public double Calculate_hydro_resistance(double k1, double k2, double e500)
        {
            return k1*k2*e500;
        }
        public double Calcualte_diameter(double flow_rate, double optimal_speed)
        {
            return Math.Sqrt(flow_rate / (0.785 * optimal_speed * 3600 * 1));
        }
        public double Calculate_cyclon_total_area(double flow_rate, double optimal_speed)
        {
            return Math.Round(flow_rate / (optimal_speed * 3600),3);
        }
        public double Calculate_speed_deviation(double real_speed, double optimal_speed)
        {
            return (Math.Abs(real_speed - optimal_speed) * 100) / optimal_speed;
        }
    }
   
    public partial class MainWindow : Window
    {

        public double real_density = 0;//действительная плотность
        public  double mT = 0;//действительноя вязкость
        private CultureInfo myCulture;

        public MainWindow()
        {
            
            InitializeComponent();
          
            //для разделителя целой и дробной части
            myCulture = new CultureInfo("en-US") { /* Тут можно доопределить специфику культуры */ };
            Thread.CurrentThread.CurrentCulture = myCulture;
            Thread.CurrentThread.CurrentUICulture = myCulture;

            txb_flow_rate.Text = "8000";
            txb_optimal_speed.Text = "3.5";
            txb_e500.Text = "155";
            txb_flow_temp.Text = "135";
            btn_create.IsEnabled = false;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
       
        private void timer_Tick( object sender, EventArgs e )
        {
            txb_Memory.Text = string.Format("{0:0.00} MB",GC.GetTotalMemory(true) / 1024.0 / 1024.0);
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            txb_results.Clear(); 
            Cleaner test = new Cleaner();
           
            test.d_Optimal_speed = double.Parse(txb_optimal_speed.Text);
            test.d_Flow_rate = double.Parse(txb_flow_rate.Text);
            test.d_Hydro_resistance = double.Parse(txb_e500.Text);
            test.d_Diameter = test.Calcualte_diameter(test.d_Flow_rate,test.d_Optimal_speed);//расчет диаметра

            double d_real_speed = Math.Round(test.Calculate_real_speed(), 3);
            double d_hydro_resistance = test.Calculate_hydro_resistance(1, 0.93, test.d_Hydro_resistance);
            double d_delta_pressure = d_hydro_resistance * real_density * Math.Pow(d_real_speed,2)/2;
            double d_CycTotalArea = test.Calculate_cyclon_total_area(test.d_Flow_rate, test.d_Optimal_speed);
            double d_delta_speed = test.Calculate_speed_deviation(d_real_speed, test.d_Optimal_speed);

            string s_result = String.Format(
                "Действительная скорость = {0}, м/с \nКоэффициент гидравлического сопротивления одиночного циклона = {1} \nПотери давления в циклоне = {2}, Па \nДиаметр циклона = {3}, м \nPT = {4} кг/м3 \nμТ = {5}, Па*с \nF = {6} м^2",
                d_real_speed, d_hydro_resistance, Math.Round(d_delta_pressure, 5), Math.Round(test.d_Diameter, 3), Math.Round(real_density,3), Math.Round(mT,6) ,d_CycTotalArea );
            string s_result1 = String.Format("\nΔw = {0}, %", Math.Round(d_delta_speed,3));
            txb_results.Text += s_result + s_result1;
           
            this.DataContext = new Create_main_model(test.d_Diameter);// создание модели
            view1.ZoomExtents();
            cuttingGroup1.CuttingPlanes.Clear();
            cuttingGroup1.CuttingPlanes.Add(new Plane3D(new Point3D(0, 0, -4.25 * test.d_Diameter), new Vector3D(0, 0, 1)));
            
            //btn_create.IsEnabled = false;
            d_hydro_resistance = 0;
            d_delta_pressure   = 0;
            real_density       = 0;
           
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            experement_window exp_windows = new experement_window();
            exp_windows.Show();
            btn_flow.IsEnabled = false;
        }
       
        private void About_Program_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow form = new AboutWindow();
            form.Show();
        }

        private void About_Process_Click(object sender, RoutedEventArgs e)
        {
            AboutProcess form = new AboutProcess();
            form.Show();
        }

        private void Grap_Click(object sender, RoutedEventArgs e)
        {
            GRAPH gr = new GRAPH();
            gr.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            view1.ZoomExtents();
        }
        
    }
}
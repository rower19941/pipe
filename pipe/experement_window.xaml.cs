using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace pipe
{
    /// <summary>
    /// Логика взаимодействия для experement_window.xaml
    /// </summary>
    public partial class experement_window : Window
    {
        public experement_window()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            txb_Name.Text = "Закись азота";
            txb_Percentag.Text = "0.06";
            txb_Density.Text = "1.9804";
            txb_Viscosity.Text = "13.7";
            txb_correction_factor.Text = "450";
        }
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        public double d_summary_density = 0;
        public double d_real_density = 0;
        public ObservableCollection<Chemical_composition> ListofChemicals = new ObservableCollection<Chemical_composition>();

        public void RecalculateSummaryDensity(ObservableCollection<Chemical_composition> list)
        {
            test_txb.Clear();
            for (int index_of_element = 0; index_of_element < list.Count; index_of_element++)
            {
                d_summary_density += list[index_of_element].d_percentage * list[index_of_element].d_density;
            }
            MainWindow wnd = (MainWindow)App.Current.MainWindow;
            d_real_density = (d_summary_density * 273) / (273 + double.Parse(wnd.txb_flow_temp.Text));

            test_txb.Text += String.Format(
                "Плотность газовой смеси = {0}, кг/м3 \nПлотность газовой смеси в рабочих условиях = {1} , кг/м3", 
                d_summary_density, Math.Round(d_real_density,3)
                );
            d_summary_density = 0;
            //d_real_density = 0;
        }

        /// <summary>
        /// Расчет вязкости m0
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public void RecalcutateViscosity(ObservableCollection<Chemical_composition> list)//Все ок! или я отупел, поправить расчеты в оформлении
        {
            double d_recalculated_viscosity = 0;
            double d_recalculated_visc_result = 0;
            double d_recalculated_overall_corr_fact = 0;
            double T = 0;
            double temp1 = 0;
            double temp2 = 0;

            for (int element = 0; element < list.Count; element++)
            {
                temp1 += list[element].Rec_visc_up();
                temp2 += list[element].Rec_visc_down();
                d_recalculated_overall_corr_fact += list[element].Rec_corr_fact();
            }
            d_recalculated_viscosity = temp1 / temp2;
            MainWindow wnd = (MainWindow)App.Current.MainWindow;
            T = double.Parse(wnd.txb_flow_temp.Text) + 273;
            d_recalculated_visc_result = d_recalculated_viscosity * ((273 + d_recalculated_overall_corr_fact) / (T + d_recalculated_overall_corr_fact)) * Math.Pow(T/273,3/2);
            wnd.mT = d_recalculated_visc_result;
            test_txb.Text += String.Format("\nμ0 = {0} Па*с \nk = {1} ",Math.Round( d_recalculated_viscosity, 6), d_recalculated_overall_corr_fact);
           
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                test_txb.Clear();
                var data = new Chemical_composition
                {
                    s_Name = txb_Name.Text,
                    d_percentage = double.Parse(txb_Percentag.Text),
                    d_density = double.Parse(txb_Density.Text),
                    d_viscosity = double.Parse(txb_Viscosity.Text),
                    d_correction_factor = double.Parse(txb_correction_factor.Text)
                };
                if (data.d_percentage >= 1)
                {
                    MessageBox.Show("Ошибка ввода: концентрация вводится в диапазоне [0;1].");
                }
                else
                {
                    ListofChemicals.Add(data);
                    dtg_chemical_composition.Items.Add(data);
                    ListofChemicals[0].d_percentage -= data.d_percentage;
                    dtg_chemical_composition.Items.Refresh();
                    RecalculateSummaryDensity(ListofChemicals);
                    RecalcutateViscosity(ListofChemicals);
                    d_real_density = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dtg_chemical_composition_Loaded(object sender, RoutedEventArgs e)
        {

            var oxygen = new Chemical_composition { s_Name = "Воздух", d_percentage = 1, d_density = 1.292, d_viscosity = 17.2, d_T_crit = 132.2, d_correction_factor = 124};
            var SO2    = new Chemical_composition { s_Name = "Оксид серы", d_percentage = 0.02, d_density = 2.927, d_viscosity = 11.7,d_T_crit = 430.7, d_correction_factor = 396 };
            //var Cl = new Chemical_composition { s_Name = "Хлор", d_percentage = 0.04, d_density = 3.214, d_viscosity = 385 };
            ListofChemicals.Add(oxygen);
            ListofChemicals.Add(SO2);
            //ListofChemicals.Add(Cl);

            ListofChemicals[0].d_percentage -= SO2.d_percentage;// + Cl.d_percentage;

            dtg_chemical_composition.Items.Refresh();
            dtg_chemical_composition.Items.Add(oxygen);
            dtg_chemical_composition.Items.Add(SO2);
            //dtg_chemical_composition.Items.Add(Cl);
            
            RecalculateSummaryDensity(ListofChemicals);
            RecalcutateViscosity(ListofChemicals);
            MainWindow wnd = (MainWindow)App.Current.MainWindow;
            wnd.real_density = d_real_density;

            d_real_density = 0;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)//TODO:Selected itmems remove
        {
            try
            {
                ListofChemicals[0].d_percentage += ListofChemicals[Convert.ToInt16(txb_remove.Text)].d_percentage;
                dtg_chemical_composition.Items.RemoveAt(Convert.ToInt16(txb_remove.Text));
                ListofChemicals.RemoveAt(Convert.ToInt16(txb_remove.Text));

                RecalculateSummaryDensity(ListofChemicals);
                RecalcutateViscosity(ListofChemicals);
                dtg_chemical_composition.Items.Refresh();
                d_real_density = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //код в этих двух события одинаковый - чтобы при закрытии окна тоже принимался состав газа
        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow wnd = (MainWindow)App.Current.MainWindow;//обращение к текущему открытому главному окну
            wnd.btn_flow.IsEnabled = true;//разлочиваем кнопку
            wnd.btn_create.IsEnabled = true;

            RecalculateSummaryDensity(ListofChemicals);
            RecalcutateViscosity(ListofChemicals);

            wnd.real_density = d_real_density;
            this.Close();
        }
        private void btn_accept_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wnd = (MainWindow)App.Current.MainWindow;//обращение к текущему открытому главному окну
            wnd.btn_flow.IsEnabled = true;//разлочиваем кнопку
            wnd.btn_create.IsEnabled = true;

            RecalculateSummaryDensity(ListofChemicals);
            RecalcutateViscosity(ListofChemicals);

            wnd.real_density = d_real_density;
            this.Close();
        }

    }

    public class Chemical_composition
    {
        public string s_Name       { get; set; }
        public double d_percentage { get; set; }
        public double d_density    { get; set; }
        public double d_viscosity  { get; set; }
        public double d_correction_factor { get; set; }
        public double d_T_crit     { get; set; }
        public double Rec_visc_up()
        {
            return d_viscosity * Math.Pow(10,-6) * d_percentage * Math.Sqrt(d_viscosity * Math.Pow(10, -6) * d_T_crit);
        }
        public double Rec_visc_down()
        {          
            return d_percentage * Math.Sqrt(d_viscosity * Math.Pow(10, -6) * d_T_crit);
        }
        public double Rec_corr_fact()
        {
            return d_percentage * d_correction_factor;
        }
    }
}

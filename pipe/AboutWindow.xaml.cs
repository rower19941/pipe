using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace pipe
{
    /// <summary>
    /// Логика взаимодействия для AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
            DoubleAnimation dblAnim = new DoubleAnimation();
            dblAnim.From = 0.0;
            dblAnim.To = 1.0;
            dblAnim.Duration = new Duration(TimeSpan.FromMilliseconds(4000));
            GG.BeginAnimation(Image.OpacityProperty, dblAnim);
            
        }
    }
}

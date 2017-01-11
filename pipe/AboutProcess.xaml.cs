using System;
using System.Windows;
using System.Windows.Documents;
using System.IO;

namespace pipe
{
    /// <summary>
    /// Логика взаимодействия для AboutProcess.xaml
    /// </summary>
    public partial class AboutProcess : Window
    {
        public AboutProcess()
        {
            InitializeComponent();
            try
            {
                string[] text = File.ReadAllLines(@"test.txt");

                FlowDocument document = new FlowDocument();
                Paragraph paragraph = new Paragraph();
                foreach (string line in text)
                {
                    paragraph.Inlines.Add(new Bold(new Run(line)));
                }
                document.Blocks.Add(paragraph);
                rtb_info.Document = document;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

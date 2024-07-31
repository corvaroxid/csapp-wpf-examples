using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSApp.WPF.Part2.Example2.StackRoutedEventsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_Click(object sender, RoutedEventArgs eventArgs)
        {
            FrameworkElement feSource = eventArgs.Source as FrameworkElement;
            double a = Double.Parse(txtBox.Text);
            switch (feSource.Name)
            {
                case "buttonAdd":
                    a += a;
                    break;
                case "buttonMult":
                    a *= a;
                    break;
                case "buttonSqrt":
                    a = Math.Sqrt(a);
                    break;
            }
            eventArgs.Handled = true;
            txtBox.Text = String.Format("{0:#.##}", a);
        }
    }
}

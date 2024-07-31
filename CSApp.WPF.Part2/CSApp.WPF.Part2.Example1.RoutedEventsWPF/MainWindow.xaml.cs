using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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

namespace CSApp.WPF.Part2.Example1.RoutedEventsWPF
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

        private void TextBoxTextChanged(object sender, TextChangedEventArgs eventArgs)
        {
            MessageBox.Show("Textbox event");
            eventArgs.Handled = (bool)txtBoxEventsRadio.IsChecked;
        }

        private void GridTextChanged(object sender, TextChangedEventArgs eventArgs)
        {
            MessageBox.Show("Grid event");
            eventArgs.Handled = (bool)gridEventsRadio.IsChecked;
        }

        private void WindowTextChanged(object sender, TextChangedEventArgs eventArgs)
        {
            MessageBox.Show("Window event");
            eventArgs.Handled = (bool)windowEventsRadio.IsChecked;
        }
    }
}

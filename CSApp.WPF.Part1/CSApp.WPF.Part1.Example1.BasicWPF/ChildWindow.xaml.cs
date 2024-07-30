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
using System.Windows.Shapes;

namespace CSApp.WPF.Part1.Example1.BasicWPF
{
    /// <summary>
    /// Interaction logic for ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window
    {
        private bool _close;
        private MainWindow _parentWindow = null;

        public ChildWindow()
        {
            InitializeComponent();
        }

        public new void Close()
        {
            _close = true;
            base.Close();
        }

        private void ChildWindowClosing(object sender, System.ComponentModel.CancelEventArgs eventArgs)
        {
            if (_close)
            {
                return;
            }

            eventArgs.Cancel = true;
            Hide();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            _parentWindow = Owner as MainWindow;
            if (_parentWindow != null)
            {
                _parentWindow.txtBlock.Text = textBox.Text;
                PrintLogFile();
            }
            Close();
        }

        private void ChildWindowClosed(object sender, EventArgs e)
        {
            _parentWindow.childWindow = null;
        }

        private void PrintLogFile()
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("ChildWindow.log", true))
            {
                writer.WriteLine("Input {0}: {1} ", textBox.Text,
                DateTime.Now.ToShortDateString() + ", time: " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }
        }
    }
}

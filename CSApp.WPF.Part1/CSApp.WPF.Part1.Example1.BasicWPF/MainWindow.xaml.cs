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

namespace CSApp.WPF.Part1.Example1.BasicWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDataDirty = false;

        public ChildWindow childWindow { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            lbl.Content = "Common content";
            setButton.IsEnabled = false;
            returnButton.IsEnabled = false;
            Top = 25;
            Left = 25;
        }

        private void SetButtonClick(object sender, RoutedEventArgs e)
        {
            System.IO.StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter("username.txt");
                sw.WriteLine(setText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sw != null) 
                { 
                    sw.Close();
                }
                isDataDirty = false;
            }
        }

        private void ReturnButtonClick(object sender, RoutedEventArgs e)
        {
            System.IO.StreamReader streamReader = null;
            try
            {
                using (streamReader = new System.IO.StreamReader("username.txt")) 
                {
                    returnLabel.Content = "Hello!" + streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                returnButton.IsEnabled = true;
            }
        }

        private void SetTextChanged(object sender, TextChangedEventArgs e)
        {
            setButton.IsEnabled = true;
            isDataDirty = true;
        }

        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs eventArgs)
        {
            if (this.isDataDirty)
            {
                const string msg = "The data has been changed, but not saved!\n Close the window without saving ? ";
                MessageBoxResult result = MessageBox.Show(msg, "Data control", 
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);
                
                if (result == MessageBoxResult.No)
                {
                    eventArgs.Cancel = true;
                }
            }
        }

        private void MenuItemClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenChildWindowButtonClick(object sender, RoutedEventArgs e)
        {
            if (childWindow == null) 
            {
                childWindow = new ChildWindow();
                childWindow.Owner = this;
            }

            var location = openChildWindowButton.PointToScreen(new Point(0, 0));
            childWindow.Left = location.X + openChildWindowButton.Width;
            childWindow.Top = location.Y;
            childWindow.Show();
        }
    }
}

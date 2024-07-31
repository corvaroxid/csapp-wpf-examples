using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CSApp.WPF.Part1.Example1.BasicWPF
{
    internal class CustomCommands
    {
        public static RoutedUICommand Launch { get; }

        static CustomCommands()
        {
            InputGestureCollection myInputGestures = new
            InputGestureCollection();
            myInputGestures.Add(new KeyGesture(Key.L, ModifierKeys.Control));
            Launch = new RoutedUICommand("Run", "Launch",
            typeof(CustomCommands), myInputGestures);
        }
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Diagnostics;

namespace PrimesApp.Views
{
    public sealed partial class ResultsPage : Page, INotifyPropertyChanged
    {
        public ResultsPage()
        {
            InitializeComponent();
            Returns.Text = "";
            Returns.TextWrapping = TextWrapping.Wrap;
            DefaultValueWarning.Visibility = Visibility.Collapsed;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button.IsEnabled = false;

            if (Maths.DefaultValuesUsed)
            {
                DefaultValueWarning.Visibility = Visibility.Visible;
            }
            else
            {
                DefaultValueWarning.Visibility = Visibility.Collapsed;
            }

            var timer = new Stopwatch();
            timer.Start();

            Returns.Text = Maths.ReturnModeX();
            timer.Stop();

            Returns.Text += $"\nCalculation took {timer.ElapsedMilliseconds} ms.";

            Button.IsEnabled = true;

        }



    }
}

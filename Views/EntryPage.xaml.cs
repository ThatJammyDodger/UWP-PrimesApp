using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Windows.UI.Xaml.Controls;

namespace PrimesApp.Views
{
    public sealed partial class EntryPage : Page, INotifyPropertyChanged
    {

        public int RadioChoice;
        public EntryPage()
        {
            InitializeComponent();

            RadioSubmit.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            RadioCover.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            RadioSelectionConfirmation.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            PrimesMaxTextBox.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            NumberEntryWarning.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            NumberEntryWarning2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            NumberCover.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            NumberSubmit.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            NumberAcceptanceMessage.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

            Maths.DefaultValuesUsed = true;
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


        private void ModeOne_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            RadioSubmit.Visibility = Windows.UI.Xaml.Visibility.Visible;
            RadioChoice = 1;
            RadioSelectionConfirmation.Text = $"Thank you. Mode {RadioChoice} has been confirmed.\n\nNow please enter the number of primes that you would like output:";
        }

        private void ModeTwo_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            RadioSubmit.Visibility = Windows.UI.Xaml.Visibility.Visible;
            RadioChoice = 2;
            RadioSelectionConfirmation.Text = $"Thank you. Mode {RadioChoice} has been confirmed.\n\nNow please enter the number up until which you would like prime numbers output:";
        }

        private void RadioSubmit_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            RadioCover.Visibility = Windows.UI.Xaml.Visibility.Visible;
            RadioSelectionConfirmation.Visibility = Windows.UI.Xaml.Visibility.Visible;
            PrimesMaxTextBox.Visibility = Windows.UI.Xaml.Visibility.Visible;

            if (RadioChoice == 1)
            {
                NumberEntryWarning.Text += "5000.";
            }
            else if (RadioChoice == 2)
            {
                NumberEntryWarning.Text += "50,000.";
            }
        }

        private void PrimesMaxTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NumberSubmit.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void NumberSubmit_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            NumberEntryWarning.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            NumberEntryWarning2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            int parse;
            bool NumberValid = int.TryParse(PrimesMaxTextBox.Text, out parse);
            if ((!NumberValid || parse < 3 || parse > 5000) && (RadioChoice == 1))
            {
                NumberEntryWarning.Visibility = Windows.UI.Xaml.Visibility.Visible;
                NumberEntryWarning2.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else if ((!NumberValid || parse < 3 || parse > 50000) && (RadioChoice == 2))
            {
                NumberEntryWarning.Visibility = Windows.UI.Xaml.Visibility.Visible;
                NumberEntryWarning2.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                NumberAcceptanceMessage.Visibility = Windows.UI.Xaml.Visibility.Visible;
                Maths.Maximum = parse;
                Maths.Mode = RadioChoice;
                Maths.DefaultValuesUsed = false;
                NumberCover.Visibility = Windows.UI.Xaml.Visibility.Visible;


            }
        }






    }
}

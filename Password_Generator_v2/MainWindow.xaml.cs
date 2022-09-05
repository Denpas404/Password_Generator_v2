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

namespace Password_Generator_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppLogic _appLogic;
        int passwordLength;
        
        public MainWindow()
        {
            InitializeComponent();
            passwordLength_slider.Minimum = 6;
            passwordLength_slider.Maximum = 24;
        }

        //Slider 
        private void passwordLength_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _appLogic = new AppLogic();

            passwordLength_label.Content = "Password length: " + passwordLength_slider.Value.ToString();
            passwordLength = (int)passwordLength_slider.Value;

            password_txtbox.Text = _appLogic.CreateNewPassword((bool)uppercase_checkBox.IsChecked, (bool)lowercase_checkBox.IsChecked, (bool)numbers_checkBox.IsChecked, (bool)symbols_checkBox.IsChecked, passwordLength);
        }

        //Button
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(password_txtbox.Text.ToString());
        }
    }
}

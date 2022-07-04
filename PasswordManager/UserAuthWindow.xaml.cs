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
using System.IO;
using System.Text.Json;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for UserAuthWindow.xaml
    /// </summary>
    public partial class UserAuthWindow : Window
    {
        string settingsPath = "settings.json";
        public UserAuthWindow()
        {
            InitializeComponent();
        }

        private void CreateUser(object sender, RoutedEventArgs e)
        {
            if (username.Text.Length < 3 && password.Text.Length < 3)
            {
                MessageBox.Show("Please ensure the username and password are not empty and at least longer than 3", "User Requirments", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var uName = username.Text;
                var pw = password.Text;
                User u1 = new User(uName, pw);

                StreamWriter sw = new StreamWriter(settingsPath);
                string userToSerial = JsonSerializer.Serialize(u1);
                sw.WriteLine(userToSerial);
                sw.Close();
                this.Close();
            }
        }


    }
}

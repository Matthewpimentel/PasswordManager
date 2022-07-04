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
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        string settingsPath = "settings.json";
        public bool flag = false;
        public LogInWindow()
        {
            InitializeComponent();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader(settingsPath);
            string json = sr.ReadToEnd();
            User savedUser = JsonSerializer.Deserialize<User>(json);

            var savedUsername = savedUser.Username;
            var savedPassword = savedUser.Password;

            if (savedUsername != username.Text)
            {
                MessageBox.Show("Username not found!");
            }
            else if (savedPassword != password.Text)
            {
                MessageBox.Show("Password does not match user");
            }
            else
            {
                flag = true;
                this.Close();
            }
        }

    }
}

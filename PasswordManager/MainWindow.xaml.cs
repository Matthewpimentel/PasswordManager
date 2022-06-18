using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
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
using System.Diagnostics;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Password> pw = new List<Password>();
        List<Password> hold = new List<Password>();
        string path = "passwords.json";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(path))
            {
               using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    pw = JsonSerializer.Deserialize<List<Password>>(json);
                }
                passwords.ItemsSource = pw;
                passwords.Items.Refresh();

            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var program = programName.Text;
            var user = userName.Text;
            var password = passwordInput.Text;

            if(program != null && user != null && password != null)
            {
                pw.Add(new Password(program, user, password));
                passwords.ItemsSource = pw;
                passwords.Items.Refresh();

                programName.Clear();
                userName.Clear();
                passwordInput.Clear();
            }    
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Password> search = new List<Password>();

            for(int i = 0; i < pw.Count; i++)
            {
                if (pw[i].Program.ToUpper().Contains(searchBox.Text.ToUpper()))
                {
                    search.Add(pw[i]);
                    passwords.ItemsSource = search;
                    passwords.Items.Refresh();
                }
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
     
                StreamWriter tw = new StreamWriter(path);
      
                string listToString = JsonSerializer.Serialize(pw);

                if (pw.Count > 0)
                {
                    tw.WriteLine(listToString);
                }

                tw.Close();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(passwords.SelectedItem != null)
            {
               
                
               
            }
        }
    }
}

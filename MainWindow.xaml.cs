using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace HelloS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement el in MainRoot.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }

        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            int last = textLabel.Text.Length - 1;
            if (str == "AC") { textLabel.Text = ""; }
            else if (str == "+" || str == "*" || str == "/" || str == "-")
            {
                string lastSimvol = (Convert.ToString(textLabel.Text[last]));
                if (lastSimvol == "+" || lastSimvol == "*" || lastSimvol == "/" || lastSimvol == "-")
                {
                    textLabel.Text = (textLabel.Text).Remove(last);
                    textLabel.Text += str;
                }
                else { textLabel.Text += str; }
            }
            else if (str == "=")
            {
                if (textLabel.Text!="")
                {
                    string lastSimvol = (Convert.ToString(textLabel.Text[last]));
                    if (lastSimvol == "+" || lastSimvol == "*" || lastSimvol == "/" || lastSimvol == "-")
                    {
                        textLabel.Text = (textLabel.Text).Remove(last);
                        string value = new DataTable().Compute(textLabel.Text, null).ToString();
                        textLabel.Text = value.Replace(",",".");
                    }
                    else
                    {
                        string value = new DataTable().Compute(textLabel.Text, null).ToString();
                        textLabel.Text = value.Replace(",", ".");
                    }
                }
            }
            else { textLabel.Text += str; }

        }
    }
}

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

namespace AzeriChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void SendMessage()
        {
            if (MessageTextBox.Text != string.Empty)
            {
                Grid grid = new Grid()
                {
                    Margin = new Thickness(0, 3, 0, 3)
                };
                Style style = new Style(typeof(Border));
                style.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(7)));
                TextBox textBox = new TextBox()
                {
                    IsReadOnly = true,
                    Text = MessageTextBox.Text,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Margin = new Thickness(0, 4, 10, 4),
                    FontFamily = new FontFamily("Global User Interface"),
                    BorderThickness = new Thickness(0),
                    Padding = new Thickness(3, 4, 3, 4),
                    FontSize = 16,
                    TextWrapping = TextWrapping.Wrap,
                    MaxWidth = 250,
                };
                textBox.Resources.Add(typeof(Border), style);
                Label label = new Label()
                {
                    Content = DateTime.Now.ToString("HH:mm"),
                    FontFamily = new FontFamily("Arial Rounded MT Bold"),
                    Margin = new Thickness(0, 4, 0, 4)
                };
                grid.Children.Add(textBox);
                grid.Children.Add(label);
                MessagePanel.Children.Add(grid);
                MessageTextBox.Clear();
                scrolll.ScrollToEnd();
            }
        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e) => SendMessage();

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) SendMessage();
        }
    }
}


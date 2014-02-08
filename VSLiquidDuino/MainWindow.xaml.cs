using System;
using System.IO.Ports;
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

namespace VSLiquidDuino
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Screen 
        private Screen screen;

        // Constructor
        public MainWindow() {

            InitializeComponent();
            screen = new Screen();

        }

        // Callback for update button onclick
        private void Button_Click(object sender, RoutedEventArgs e) {

            // Get texts
            TextBox line1 = (TextBox)this.FindName("Line1");
            TextBox line2 = (TextBox)this.FindName("Line2");

            // Set them to Screen
            screen.setLine(0, line1.Text);
            screen.setLine(1, line2.Text);

            // Update Screen
            screen.update();

        }

    }

}

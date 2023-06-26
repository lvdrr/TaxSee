using System.Windows;
using TaxSee.Admin;

namespace TaxSee
{
    /// <summary>
    /// Логика взаимодействия для SentOrder.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void OrdersBut_Click(object sender, RoutedEventArgs e)
        {
            AdminOrder adminOrder = new AdminOrder();
            adminOrder.Show();
            Close();
        }

        private void DriversBut_Click(object sender, RoutedEventArgs e)
        {
            AdminDriver adminDriver = new AdminDriver();
            adminDriver.Show();
            Close();
        }
    }
}

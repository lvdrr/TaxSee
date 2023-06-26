using System.Windows;

namespace TaxSee
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginBut_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text == string.Empty && PasswordBox.Text == string.Empty) 
            {
                MessageBox.Show("Введите логин и пароль!","Ошибка!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            if (LoginBox.Text == "Art" && PasswordBox.Text == "12345")
            {
                AdminPage adminPage = new AdminPage();
                adminPage.Show();
                Close();
            }
            else 
            {
                TakeOrder takeOrder = new TakeOrder();
                takeOrder.Show();
                Close();
            }
        }
    }
}

using Npgsql;
using System;
using System.Windows;
using TaxSeeDB;

namespace TaxSee.Admin
{
    public partial class AddDriverPage : Window
    {
        DataBase DB = new DataBase();
        public string query;
        public AddDriverPage()
        {
            InitializeComponent();
        }
        private void AddDrivers()
        {
            try
            {
                DB.OpenConnection();
                query = $@"insert into public.""Driver"" values ('{Convert.ToInt32(DriverIDText.Text)}', '{DriverFNameText.Text}', '{DriverLNameText.Text}', '{DriverPNum.Text}', '{DriverCar.Text}', '{Convert.ToInt32(DriverOrderIDText.Text)}')";
                NpgsqlCommand cmd = new NpgsqlCommand(query, DB.GetConnection());
                cmd.ExecuteNonQuery();
                DB.CloseConnection();
                MessageBox.Show("Успешно!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void AddDriverBut_Click(object sender, RoutedEventArgs e)
        {
            var answer = MessageBox.Show("Нужно добавить что-то еще?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            AddDrivers();
            if (answer == MessageBoxResult.Yes)
            {
                return;
            }
            Close();
        }
    }
}

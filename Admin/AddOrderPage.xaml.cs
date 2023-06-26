using Npgsql;
using System;
using System.Windows;
using TaxSeeDB;

namespace TaxSee.Admin
{
    public partial class AddOrderPage : Window
    {
        DataBase DB = new DataBase();
        public string query;
        public AddOrderPage()
        {
            InitializeComponent();
        }
        private void AddOrders()
        {
            try
            {
                DB.OpenConnection();
                query = $@"insert into public.""Order"" values ('{Convert.ToInt32(OrderIDText.Text)}', '{NameText.Text}', '{CityDepartureText.Text}', '{StreetDepartureText.Text}', '{Convert.ToInt32(HouseDepartureText.Text)}', '{CityDestinationText.Text}', '{StreetDestinationText.Text}', '{Convert.ToInt32(HouseDestinationText.Text)}', '{AddNotesText.Text}', '{Convert.ToInt32(DriverIDText.Text)}')";
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

        private void AddOrderBut_Click(object sender, RoutedEventArgs e)
        {
            var answer = MessageBox.Show("Нужно добавить что-то еще?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            AddOrders();
            if (answer == MessageBoxResult.Yes)
            {
                return;
            }
            Close();
        }
    } 
}

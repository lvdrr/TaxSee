using Npgsql;
using System;
using System.Data;
using System.Windows;
using TaxSeeDB;

namespace TaxSee.Admin
{
    public partial class AdminOrder : Window
    {
        DataBase DB = new DataBase();
        public string query;
        public AdminOrder()
        {
            InitializeComponent();
            LoadOrders();
        }
        private void LoadOrders()
        {
            try
            {
                DB.OpenConnection();

                query = @"select ""OrderID"" as ""ID Заказа"", ""Name"" as ""Имя клиента"", ""CityDeparture"" as ""Город отбытия"", ""StreetDeparture"" as ""Улица отбытия"", ""HouseDeparture"" as ""Дом отбытия"",
                ""CityDestination"" as ""Город назначения"", ""StreetDestination"" as ""Улица назначения"", ""HouseDestination"" as ""Дом назначения"", ""AdditionalNotes"" as ""Доп информация"", ""DriverID"" as ""ID Водителя"" from public.""Order""";

                NpgsqlCommand cmd = new NpgsqlCommand(query, DB.GetConnection());

                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable DT = new DataTable();
                    DT.Load(reader);
                    AdminOrders.ItemsSource = DT.DefaultView;
                }
                DB.CloseConnection();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void DeleteOrder()
        {
            try
            {
                DB.OpenConnection();
                query = $@"delete from public.""Order"" where ""OrderID"" = '{Convert.ToInt32(DeleteOrderText.Text)}'";
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
        private void BackBut_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            Close();
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderPage addOrderPage = new AddOrderPage();
            addOrderPage.Show();
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            DeleteOrder();
            LoadOrders();
        }
    }
}
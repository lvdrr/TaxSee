using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
using TaxSee.Admin;
using TaxSeeDB;

namespace TaxSee
{
    public partial class TakeOrder : Window
    {
        DataBase DB = new DataBase();
        public string query;
        public TakeOrder()
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
                    IncomingOrders.ItemsSource = DT.DefaultView;
                }
                DB.CloseConnection();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void TakeOrderBut_Click(object sender, RoutedEventArgs e)
        {
            /*try
            {
                DB.OpenConnection();

                query = "CREATE OR REPLACE TABLE TakenOrders (OrderID PK BIGINT NOT NULL, Name VARCHAR(50) NOT NULL, CityDeparture VARCHAR(100) NOT NULL, StreetDeparture VARCHAR(100) NOT NULL, HouseDeparture INT NOT NULL, CityDestination VACHAR(100) NOT NULL, StreetDestination VARCHAR(100) NOT NULL, HouseDestination VARCHAR(100) NOT NULL, AdditionalNotes VARCHAR(100), DriverID BIGINT)";
                //$@"delete from public.""Order"" where ""OrderID"" = '{Convert.ToInt32(TakeOrderText.Text)}'";
                NpgsqlCommand cmd = new NpgsqlCommand(query, DB.GetConnection());
                cmd.ExecuteNonQuery();
                while()

                DB.CloseConnection();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Заказ не принят!", exc.Message);
            }*/
            if (TakeOrderText.Text == string.Empty)
            {
                MessageBox.Show("Введите номер заказа!");
                return;
            }

            MessageBox.Show($"Заказ #{TakeOrderText.Text} принят!");
        }
    }

}

using Npgsql;
using System;
using System.Collections;
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
using TaxSeeDB;

namespace TaxSee.Admin
{
    public partial class AdminDriver : Window
    {
        DataBase DB = new DataBase();
        public string query;
        public AdminDriver()
        {
            InitializeComponent();
            LoadDrivers();
        }
        private void LoadDrivers()
        {
            try
            {
                DB.OpenConnection();

                query = @"select ""DriverID"" as ""ID Водителя"", ""FirstName"" as ""Имя"", ""LastName"" as ""Фамилия"",
                ""PhoneNum"" as ""Номер телефона"", ""Car"" as ""Машина"", ""OrderID"" as ""ID Заказа"" from public.""Driver""";

                NpgsqlCommand cmd = new NpgsqlCommand(query, DB.GetConnection());

                NpgsqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable DT = new DataTable();
                    DT.Load(reader);
                    AdminDrivers.ItemsSource = DT.DefaultView;
                }
                DB.CloseConnection();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void DeleteDriver()
        {
            try
            {
                DB.OpenConnection();
                query = $@"delete from public.""Driver"" where ""DriverID"" = '{Convert.ToInt32(DeleteDriverText.Text)}'";
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

        private void AddDriver_Click(object sender, RoutedEventArgs e)
        {
            AddDriverPage addDriverPage = new AddDriverPage();
            addDriverPage.Show();
        }

        private void DeleteDriverBut_Click(object sender, RoutedEventArgs e)
        {
            DeleteDriver();
            LoadDrivers();
        }
    }
}

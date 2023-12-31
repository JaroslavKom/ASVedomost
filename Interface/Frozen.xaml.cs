﻿using Microsoft.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Interface
{
    /// <summary>
    /// Логика взаимодействия для Frozen.xaml
    /// </summary>
    public partial class Frozen : Window
    {
        ConnectBD connect = new ConnectBD();
        DispatcherTimer timer = new DispatcherTimer();
        private string uuid = "";
        private int id = 0, ids = 0;
        public Frozen()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }
        private void UpdateDataGrid()
        {
            Vedomosty.ItemsSource = null;
            string search = String.Format("select type_typevedomost, data_time_vedomost, prod_vedomost, FIO_sotrud from Vedomost, TypeVedomost, Sotrudnic where zone_proiz_vedomost = 3 and type_vedomost = 3 and type_vedomost = id_typevedomost and sotrud_vedomost = id_sotrud");
            SqlCommand comm = new SqlCommand(search, connect.getConnection());
            connect.openConnection();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            adapter.Fill(table);
            Vedomosty.ItemsSource = table.DefaultView;
            connect.closeConnection();

            Vedomosty_storage.ItemsSource = null;
            string search_storage = String.Format("select type_typevedomost, data_time_vedomost, prod_vedomost, FIO_sotrud from Vedomost, TypeVedomost, Sotrudnic where zone_proiz_vedomost = 4 and type_vedomost = 2 and type_vedomost = id_typevedomost and sotrud_vedomost = id_sotrud");
            SqlCommand comm_storage = new SqlCommand(search_storage, connect.getConnection());
            connect.openConnection();
            DataTable table_storage = new DataTable();
            SqlDataAdapter adapter_storage = new SqlDataAdapter(comm_storage);
            adapter_storage.Fill(table_storage);
            Vedomosty_storage.ItemsSource = table_storage.DefaultView;
            connect.closeConnection();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int otdel = Otdels.SelectedIndex;
            switch (otdel)
            {
                case 0:
                    Reseption resept = new Reseption();
                    resept.Show();
                    this.Close();
                    break;
                case 1:
                    MainWindow Window = new MainWindow();
                    Window.Show();
                    this.Close();
                    break;
                case 2:
                    Procatniy_Ceh procat = new Procatniy_Ceh();
                    procat.Show();
                    this.Close();
                    break;
                //case 3:
                //    Frozen holod = new Frozen();
                //    holod.Show();
                //    this.Close();
                //    break;
                case 4:
                    Control control = new Control();
                    control.Show();
                    this.Close();
                    break;
                case 5:
                    Unloading unload = new Unloading();
                    unload.Show();
                    this.Close();
                    break;
                case 6:
                    Log log = new Log();
                    log.Show();
                    this.Close();
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();

            string sotrudnicsearch = $"select FIO_sotrud from Sotrudnic where doljnost_sotrud = 'Работник холодильного отдела'";
            SqlCommand sotrudnic = new SqlCommand(sotrudnicsearch, connect.getConnection());
            connect.openConnection();
            SqlDataReader sotrudnicreader = sotrudnic.ExecuteReader();
            while (sotrudnicreader.Read())
            {
                Sotrud.Items.Add(sotrudnicreader.GetValue(0).ToString());
            }
            connect.closeConnection();
        }

        private void Vedomosty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Vedomosty.SelectedItem != null)
            {
                var row = (DataGridRow)Vedomosty.ItemContainerGenerator.ContainerFromItem(Vedomosty.SelectedItem);
                uuid = ((TextBlock)Vedomosty.Columns[2].GetCellContent(row)).Text;
                if (uuid.Trim() != "")
                {
                    string search = String.Format("select id_vedomost from Vedomost where type_vedomost = 3 and prod_vedomost = '{0}' and zone_proiz_vedomost = 3", uuid);
                    SqlCommand comm = new SqlCommand(search, connect.getConnection());
                    connect.openConnection();
                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["id_vedomost"]);
                    }
                    connect.closeConnection();
                }
                else
                    id = 0;
            }
        }

        private void Vedomosty_storage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Vedomosty_storage.SelectedItem != null)
            {
                var row = (DataGridRow)Vedomosty_storage.ItemContainerGenerator.ContainerFromItem(Vedomosty_storage.SelectedItem);
                uuid = ((TextBlock)Vedomosty_storage.Columns[2].GetCellContent(row)).Text;
                if (uuid.Trim() != "")
                {
                    string search = String.Format("select id_vedomost from Vedomost where type_vedomost = 2 and prod_vedomost = '{0}' and zone_proiz_vedomost = 4", uuid);
                    SqlCommand comm = new SqlCommand(search, connect.getConnection());
                    connect.openConnection();
                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        ids = Convert.ToInt32(reader["id_vedomost"]);
                    }
                    connect.closeConnection();
                }
                else
                    ids = 0;
            }
        }

        private void Stor_Click(object sender, RoutedEventArgs e)
        {
            int sotrud = 0;
            //Сотрудник
            string sotrud_search = String.Format("select id_sotrud from Sotrudnic where FIO_sotrud = '{0}' and doljnost_sotrud = 'Работник холодильного отдела'", Sotrud.SelectedItem);
            SqlCommand sotrud_comm = new SqlCommand(sotrud_search, connect.getConnection());
            connect.openConnection();
            SqlDataReader sotrud_reader = sotrud_comm.ExecuteReader();
            while (sotrud_reader.Read())
            {
                sotrud = Convert.ToInt32(sotrud_reader["id_sotrud"]);
            }
            connect.closeConnection();

            if (id != 0)
            {
                if (sotrud != 0)
                {
                    //Обновление записи "Ведомости"
                    string update = String.Format("update Vedomost set type_vedomost = 2, sotrud_vedomost = {0}, zone_proiz_vedomost = 4 where id_vedomost = {1}", sotrud, id);
                    SqlCommand update_comm = new SqlCommand(update, connect.getConnection());
                    connect.openConnection();
                    update_comm.ExecuteNonQuery();
                    connect.closeConnection();
                    MessageBox.Show("Продукция перенесена на склад");
                    UpdateDataGrid();
                }
                else
                    MessageBox.Show("Выберите работника");
            }
            else
                MessageBox.Show("Была выбрана пустая запись, выберите другую");
        }

        private void Froz_Click(object sender, RoutedEventArgs e)
        {
            int sotrud = 0;
            //Сотрудник
            string sotrud_search = String.Format("select id_sotrud from Sotrudnic where FIO_sotrud = '{0}' and doljnost_sotrud = 'Работник холодильного отдела'", Sotrud.SelectedItem);
            SqlCommand sotrud_comm = new SqlCommand(sotrud_search, connect.getConnection());
            connect.openConnection();
            SqlDataReader sotrud_reader = sotrud_comm.ExecuteReader();
            while (sotrud_reader.Read())
            {
                sotrud = Convert.ToInt32(sotrud_reader["id_sotrud"]);
            }
            connect.closeConnection();

            if (id != 0)
            {
                if (sotrud != 0)
                {
                    //Обновление записи "Ведомости"
                    string update = String.Format("update Vedomost set type_vedomost = 5 where id_vedomost = {0}", id);
                    SqlCommand update_comm = new SqlCommand(update, connect.getConnection());
                    connect.openConnection();
                    update_comm.ExecuteNonQuery();
                    connect.closeConnection();

                    //Создание записи "Ведомости"
                    string vedomosty = String.Format("insert into Vedomost (type_vedomost, data_time_vedomost, prod_vedomost, sotrud_vedomost, zone_proiz_vedomost) values (3,'{0}','{1}',{2},4)", DateTime.Now, uuid, sotrud);
                    SqlCommand vedomosty_comm = new SqlCommand(vedomosty, connect.getConnection());
                    connect.openConnection();
                    vedomosty_comm.ExecuteNonQuery();
                    connect.closeConnection();
                    MessageBox.Show("Запись успешно добавлена");
                    UpdateDataGrid();
                }
                else
                    MessageBox.Show("Выберите работника");
            }
            else
                MessageBox.Show("Была выбрана пустая запись, выберите другую");
        }

        private void Froz_Stor_Click(object sender, RoutedEventArgs e)
        {
            int sotrud = 0;
            //Сотрудник
            string sotrud_search = String.Format("select id_sotrud from Sotrudnic where FIO_sotrud = '{0}' and doljnost_sotrud = 'Работник холодильного отдела'", Sotrud.SelectedItem);
            SqlCommand sotrud_comm = new SqlCommand(sotrud_search, connect.getConnection());
            connect.openConnection();
            SqlDataReader sotrud_reader = sotrud_comm.ExecuteReader();
            while (sotrud_reader.Read())
            {
                sotrud = Convert.ToInt32(sotrud_reader["id_sotrud"]);
            }
            connect.closeConnection();

            if (ids != 0)
            {
                if (sotrud != 0)
                {
                    //Обновление записи "Ведомости"
                    string update = String.Format("update Vedomost set type_vedomost = 5 where id_vedomost = {0}", ids);
                    SqlCommand update_comm = new SqlCommand(update, connect.getConnection());
                    connect.openConnection();
                    update_comm.ExecuteNonQuery();
                    connect.closeConnection();

                    //Создание записи "Ведомости"
                    string vedomosty = String.Format("insert into Vedomost (type_vedomost, data_time_vedomost, prod_vedomost, sotrud_vedomost, zone_proiz_vedomost) values (3,'{0}','{1}',{2},4)", DateTime.Now, uuid, sotrud);
                    SqlCommand vedomosty_comm = new SqlCommand(vedomosty, connect.getConnection());
                    connect.openConnection();
                    vedomosty_comm.ExecuteNonQuery();
                    connect.closeConnection();
                    MessageBox.Show("Запись успешно добавлена");
                    UpdateDataGrid();
                }
                else
                    MessageBox.Show("Выберите работника");
            }
            else
                MessageBox.Show("Была выбрана пустая запись, выберите другую");
        }
    }
}

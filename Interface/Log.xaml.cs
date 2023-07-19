using Microsoft.Data.SqlClient;
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
using System.Windows.Threading;

namespace Interface
{
    /// <summary>
    /// Логика взаимодействия для Log.xaml
    /// </summary>
    public partial class Log : Window
    {
        ConnectBD connect = new ConnectBD();
        DispatcherTimer timer = new DispatcherTimer();
        private string uuid = "";
        public Log()
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
            string search = String.Format("select type_typevedomost, data_time_vedomost, prod_vedomost, FIO_sotrud, location_zone from Vedomost, TypeVedomost, Sotrudnic, ZoneProiz where zone_proiz_vedomost = id_zone and type_vedomost = id_typevedomost and sotrud_vedomost = id_sotrud");
            SqlCommand comm = new SqlCommand(search, connect.getConnection());
            connect.openConnection();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            adapter.Fill(table);
            Vedomosty.ItemsSource = table.DefaultView;
            connect.closeConnection();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
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
                case 3:
                    Frozen holod = new Frozen();
                    holod.Show();
                    this.Close();
                    break;
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
                    //case 6:
                    //    Log log = new Log();
                    //    log.Show();
                    //    this.Close();
                    //    break;
            }
        }
    }
}

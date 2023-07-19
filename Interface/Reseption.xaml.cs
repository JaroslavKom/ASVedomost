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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interface
{
    /// <summary>
    /// Логика взаимодействия для Reseption.xaml
    /// </summary>
    public partial class Reseption : Window
    {
        ConnectBD connect = new ConnectBD();
        public Reseption()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int otdel = Otdels.SelectedIndex;
            switch(otdel)
            {
                //case 0:
                //    Reseption resept = new Reseption();
                //    resept.Show();
                //    this.Close();
                //    break;
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
                case 6:
                    Log log = new Log();
                    log.Show();
                    this.Close();
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string marksearch = $"select name_mark from Mark";
            SqlCommand mark = new SqlCommand(marksearch, connect.getConnection());
            connect.openConnection();
            SqlDataReader markreader = mark.ExecuteReader();
            while (markreader.Read())
            {
                Mark.Items.Add(markreader.GetValue(0).ToString());
            }
            connect.closeConnection();
            string profilesearch = $"select type_profile from Profile";
            SqlCommand profile = new SqlCommand(profilesearch, connect.getConnection());
            connect.openConnection();
            SqlDataReader profilereader = profile.ExecuteReader();
            while (profilereader.Read())
            {
                Profile.Items.Add(profilereader.GetValue(0).ToString());
            }
            connect.closeConnection();
            string sotrudnicsearch = $"select FIO_sotrud from Sotrudnic where doljnost_sotrud = 'Поставщик'";
            SqlCommand sotrudnic = new SqlCommand(sotrudnicsearch, connect.getConnection());
            connect.openConnection();
            SqlDataReader sotrudnicreader = sotrudnic.ExecuteReader();
            while (sotrudnicreader.Read())
            {
                Sotrudnic.Items.Add(sotrudnicreader.GetValue(0).ToString());
            }
            connect.closeConnection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Данные для продукции
            string kleimo = "", mark = "", prof = "", uuid = "";
            //Данные для характеристики продукции
            int year = 0, id = 0;
            string producer = "";
            //Данные для ведомости
            int type = 0, sotrud = 0, zone = 0;
            //Клеймо
            kleimo = Kleimo.Text.Trim();
            //Марка стали
            string mark_search = String.Format("select id_mark from Mark where name_mark = '{0}'", Mark.SelectedItem);
            SqlCommand mark_comm = new SqlCommand(mark_search, connect.getConnection());
            connect.openConnection();
            SqlDataReader mark_reader = mark_comm.ExecuteReader();
            while (mark_reader.Read())
            {
                mark = mark_reader["id_mark"].ToString();
            }
            connect.closeConnection();
            //Профиль
            string prof_search = String.Format("select id_profile from Profile where type_profile = '{0}'", Profile.SelectedItem);
            SqlCommand prof_comm = new SqlCommand(prof_search, connect.getConnection());
            connect.openConnection();
            SqlDataReader prof_reader = prof_comm.ExecuteReader();
            while (prof_reader.Read())
            {
                prof = prof_reader["id_profile"].ToString();
            }
            connect.closeConnection();
            //Сотрудник
            string sotrud_search = String.Format("select id_sotrud from Sotrudnic where FIO_sotrud = '{0}' and doljnost_sotrud = 'Поставщик'", Sotrudnic.SelectedItem);
            SqlCommand sotrud_comm = new SqlCommand(sotrud_search, connect.getConnection());
            connect.openConnection();
            SqlDataReader sotrud_reader = sotrud_comm.ExecuteReader();
            while (sotrud_reader.Read())
            {
                sotrud = Convert.ToInt32(sotrud_reader["id_sotrud"]);
            }
            connect.closeConnection();
            //Тип ведомости
            string type_search = String.Format("select id_typevedomost from TypeVedomost where type_typevedomost = 'Приемка'");
            SqlCommand type_comm = new SqlCommand(type_search, connect.getConnection());
            connect.openConnection();
            SqlDataReader type_reader = type_comm.ExecuteReader();
            while (type_reader.Read())
            {
                type = Convert.ToInt32(type_reader["id_typevedomost"]);
            }
            connect.closeConnection();
            //Зона производства
            string zone_search = String.Format("select id_zone from ZoneProiz where location_zone = 'Разгрузка заготовок'");
            SqlCommand zone_comm = new SqlCommand(zone_search, connect.getConnection());
            connect.openConnection();
            SqlDataReader zone_reader = zone_comm.ExecuteReader();
            while (zone_reader.Read())
            {
                zone = Convert.ToInt32(zone_reader["id_zone"]);
            }
            connect.closeConnection();
            //Год и производитель
            year = Convert.ToInt32(Year.Text);
            producer = Producer.Text;

            if (Kleimo.Text.Trim() != "" && Length.Text.Trim() != "" && Width.Text.Trim() != "" && Heigth.Text.Trim() != "" && Year.Text.Trim() != "" && Producer.Text.Trim() != "")
            {
                //Создание записи "Характиристики"
                string parametres = String.Format("insert into Params (length_params, width_params, height_params, year_params, producer_params, mark_params) values ({0},{1},{2},{3},'{4}',{5})", Length.Text, Width.Text, Heigth.Text, year, producer, mark);
                SqlCommand parametres_comm = new SqlCommand(parametres, connect.getConnection());
                connect.openConnection();
                parametres_comm.ExecuteNonQuery();
                connect.closeConnection();
                //Нахождение id созданной записи характеристик
                string id_search = String.Format("select id_params from Params where length_params = {0} and width_params = {1} and height_params = {2} and year_params = {3} and producer_params = '{4}' and mark_params = {5}", Length.Text, Width.Text, Heigth.Text, year, producer, mark);
                SqlCommand id_comm = new SqlCommand(id_search, connect.getConnection());
                connect.openConnection();
                SqlDataReader id_reader = id_comm.ExecuteReader();
                while (id_reader.Read())
                {
                    id = Convert.ToInt32(id_reader["id_params"]);
                }
                connect.closeConnection();
                //Создание записи "Продукция"
                string products = String.Format("insert into Products (kleimo_prod, params_prod, profile_prod, marka_prod) values ('{0}',{1},{2},{3})", kleimo, id, prof, mark);
                SqlCommand products_comm = new SqlCommand(products, connect.getConnection());
                connect.openConnection();
                products_comm.ExecuteNonQuery();
                connect.closeConnection();
                //Нахождение uuid созданной записи продукции
                string uuid_search = String.Format("select id_prod from Products where kleimo_prod = '{0}' and params_prod = {1} and profile_prod = {2} and marka_prod = {3}", kleimo, id, prof, mark);
                SqlCommand uuid_comm = new SqlCommand(uuid_search, connect.getConnection());
                connect.openConnection();
                SqlDataReader uuid_reader = uuid_comm.ExecuteReader();
                while (uuid_reader.Read())
                {
                    uuid = uuid_reader["id_prod"].ToString();
                }
                connect.closeConnection();
                //Создание записи "Ведомости"
                string vedomosty = String.Format("insert into Vedomost (type_vedomost, data_time_vedomost, prod_vedomost, sotrud_vedomost, zone_proiz_vedomost) values ({0},'{1}','{2}',{3},{4})", type, DateTime.Now, uuid, sotrud,zone);
                SqlCommand vedomosty_comm = new SqlCommand(vedomosty, connect.getConnection());
                connect.openConnection();
                vedomosty_comm.ExecuteNonQuery();
                connect.closeConnection();
                MessageBox.Show("Запись успешно добавлена");
            }
            else
            {
                MessageBox.Show("Введены не все данные, заполните их");
            }

        }
    }
}

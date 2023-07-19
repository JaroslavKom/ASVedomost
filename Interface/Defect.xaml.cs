using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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

namespace Interface
{
    /// <summary>
    /// Логика взаимодействия для Defect.xaml
    /// </summary>
    public partial class Defect : Window
    {
        ConnectBD connect = new ConnectBD();
        private string uuid;
        public int a;
        public Defect(string _uuid)
        {
            InitializeComponent();
            uuid = _uuid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Idprod.Content = uuid;
            string search = $"select type_typedefect from TypeDefect";
            SqlCommand type = new SqlCommand(search, connect.getConnection());
            connect.openConnection();
            SqlDataReader reader = type.ExecuteReader();
            while (reader.Read())
            {
                Def.Items.Add(reader.GetValue(0).ToString());
            }
            connect.closeConnection();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int type = 0;
            string type_search = String.Format("select id_typedefect from TypeDefect where type_typedefect = '{0}'", Def.SelectedItem);
            SqlCommand type_comm = new SqlCommand(type_search, connect.getConnection());
            connect.openConnection();
            SqlDataReader type_reader = type_comm.ExecuteReader();
            while (type_reader.Read())
            {
                type = Convert.ToInt32(type_reader["id_typedefect"]);
            }
            connect.closeConnection();

            int select = Otdels.SelectedIndex;
            if (type != 0 && Damage.Text.Trim() != "")
            {
                switch (select)
                {
                    case 0:
                        a = 1;
                        break;
                    case 1:
                        a = 2;
                        string defect = String.Format("insert into DefectList (prod_defect, type_defect, damage_defect) values ('{0}', {1}, {2})", uuid, type, Damage.Text);
                        SqlCommand comm = new SqlCommand(defect, connect.getConnection());
                        connect.openConnection();
                        comm.ExecuteNonQuery();
                        connect.closeConnection();
                        MessageBox.Show("Запись успешно добавлена");
                        break;
                    case 2:
                        a = 3;
                        string defect2 = String.Format("insert into DefectList (prod_defect, type_defect, damage_defect) values ('{0}', {1}, {2})", uuid, type, Damage.Text);
                        SqlCommand comm2 = new SqlCommand(defect2, connect.getConnection());
                        connect.openConnection();
                        comm2.ExecuteNonQuery();
                        connect.closeConnection();
                        MessageBox.Show("Запись успешно добавлена");
                        break;
                }
            }
            else
                MessageBox.Show("Выберите степень тяжести и укажите % тяжести");
            this.Close();
        }
    }
}

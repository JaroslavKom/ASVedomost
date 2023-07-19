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
    /// Логика взаимодействия для DefectList.xaml
    /// </summary>
    public partial class DefectList : Window
    {
        ConnectBD connect = new ConnectBD();
        public DefectList()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string search = String.Format("select prod_defect, type_typedefect, damage_defect from DefectList, TypeDefect where type_defect = id_typedefect");
            SqlCommand comm = new SqlCommand(search, connect.getConnection());
            connect.openConnection();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            adapter.Fill(table);
            Vedomosty.ItemsSource = table.DefaultView;
            connect.closeConnection();
        }
    }
}

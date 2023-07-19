using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Interface
{
    class ConnectBD
    {
        SqlConnection _connect = new SqlConnection(@"Data Source=\SQLEXPRESS;Initial Catalog=Relsy;Integrated Security=True; TrustServerCertificate=True");

        public void openConnection()
        { 
            if( _connect.State == System.Data.ConnectionState.Closed)
                _connect.Open(); 
        }
        public void closeConnection()
        {
            if (_connect.State == System.Data.ConnectionState.Open)
                _connect.Close();
        }
        public SqlConnection getConnection()
        {
            return _connect;
        }
    }
}

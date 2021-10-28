using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos.Servidor
{
    internal class AdminDB
    {
        internal static SqlConnection ConectarBase()
        {
            string cadena = Datos.Properties.Settings.Default.KeyDBTransporte;
            SqlConnection connection = new SqlConnection(cadena);
            connection.Open();
            return connection; 
        }
    }
}

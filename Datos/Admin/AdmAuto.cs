using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Models;
using System.Data.SqlClient;
using Datos.Servidor;

namespace Datos.Admin
{
    public static class AdmAuto
    {
        public static List<Auto> Listar()
        {
            string consulta = "SELECT Id, Marca, Modelo, Matricula, Precio from dbo.Auto";
            SqlCommand comando = new SqlCommand(consulta, AdminDB.ConectarBase());
            SqlDataReader reader;
            reader = comando.ExecuteReader();
            List<Auto> autos = new List<Auto>(); 
            while(reader.Read())
            {
                autos.Add(
                    new Auto()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Marca = reader["Marca"].ToString(),
                        Modelo = reader["Modelo"].ToString(),
                        Matricula = reader["Matricula"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"])
                    }) ;
            }
            AdminDB.ConectarBase().Close();
            reader.Close();
            return autos;
        }
        public static DataTable Listar(string marca)
        {
            string consulta = "SELECT Id, Marca, Modelo, Matricula, Precio from dbo.Auto WHERE Marca=@Marca";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, AdminDB.ConectarBase());
            adapter.SelectCommand.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = marca;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Marca"); // ???
            return ds.Tables["Marca"];
        }
        public static int Insertar(Auto auto)
        {
            string insert = "INSERT dbo.Auto (Marca, Modelo, Matricula, Precio) VALUES (@Marca, @Modelo, @Matricula, @Precio)";
            SqlCommand comando = new SqlCommand(insert, AdminDB.ConectarBase());
            comando.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = auto.Marca;
            comando.Parameters.Add("@Matricula", SqlDbType.Char, 6).Value = auto.Matricula;
            comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 50).Value = auto.Modelo;
            comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = auto.Precio;
            int filasAfectadas = comando.ExecuteNonQuery();
            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }
        public static int Modificar(Auto auto)
        {
            string update = "UPDATE dbo.Auto SET Marca=@Marca, Modelo=@Modelo, Matricula=@Matricula, Precio=@Precio WHERE Id=@Id";
            SqlCommand comando = new SqlCommand(update, AdminDB.ConectarBase());
            comando.Parameters.Add("@Marca", SqlDbType.VarChar, 50).Value = auto.Marca;
            comando.Parameters.Add("@Matricula", SqlDbType.Char, 6).Value = auto.Matricula;
            comando.Parameters.Add("@Modelo", SqlDbType.VarChar, 50).Value = auto.Modelo;
            comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = auto.Precio;
            comando.Parameters.Add("@Id", SqlDbType.Int).Value = auto.Id;
            int filasAfectadas = comando.ExecuteNonQuery();
            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }
        public static int Eliminar(int id)
        {
            string delete = "DELETE FROM dbo.Auto WHERE Id=@Id";
            SqlCommand comando = new SqlCommand(delete, AdminDB.ConectarBase());
            comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            int filasAfectadas = comando.ExecuteNonQuery();
            AdminDB.ConectarBase().Close();
            return filasAfectadas;
        }
        public static DataTable listarMarcas()
        {
            string consulta = "SELECT DISTINCT Marca from dbo.Auto";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, AdminDB.ConectarBase());
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Marca");
            return ds.Tables["Marca"];
        }

    }
}

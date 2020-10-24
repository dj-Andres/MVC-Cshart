using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Acceso_Datos
{
    public class Usuario:ConnecionSql
    {
        public bool Login(string user, string pass)
        {
            using (var connection = getConnection())
            {
                connection.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = connection;
                    comando.Parameters.AddWithValue("@user", user);
                    comando.Parameters.AddWithValue("@pass", pass);
                    comando.CommandText = "SELECT * FROM Usuarios WHERE Usuario=@user AND password=@pass";
                    comando.CommandType = CommandType.Text;
                    SqlDataReader reader = comando.ExecuteReader();

                    if(reader.HasRows){
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}

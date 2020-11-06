using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ComunController.Cache;

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
                    //comando.Parameters.AddWithValue("@id", cache_login.Id_usuario);
                    comando.CommandText = "SELECT * FROM Usuarios WHERE Usuario=@user AND password=@pass";
                    comando.CommandType = CommandType.Text;
                    SqlDataReader reader = comando.ExecuteReader();

                    if(reader.HasRows){
                        while(reader.Read()){
                            cache_login.Id_usuario = reader.GetInt32(0);
                            cache_login.Nombre = reader.GetString(3);
                            cache_login.Apellido = reader.GetString(4);
                            cache_login.correo = reader.GetString(5);
                        }
                        
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

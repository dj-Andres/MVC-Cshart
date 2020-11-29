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
                            cache_login.Cargo = reader.GetString(6);
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

        public  string recuperar_clave(string usuario_recuperar){
            using (var connection = getConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand()){
                    cmd.Connection = connection;
                    cmd.CommandText = "select * from Usuarios WHERE Usuario=@user OR correo=@email";
                    cmd.Parameters.AddWithValue("@user", usuario_recuperar);
                    cmd.Parameters.AddWithValue("@email", usuario_recuperar);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.Read()==true){
                        string usuario_nombre = reader.GetString(3) + ", " + reader.GetString(4);
                        string correo = reader.GetString(5);
                        string clave = reader.GetString(2);
                        //List<string>listas=new List<string>();
                        //listas.Add(correo);
                        var mailService = new ServicesEmails.SystemEmail();
                        mailService.sendEmail(
                            asunto:"Recuperacion de contraseña",
                            body:"Hola,"+usuario_nombre+"\n Usted solicito la recuperacion de la contraseña. \n"+
                            "su nueva contraseña es:"+clave+
                            "\n ¡Por favor cambiar la contraseña actual",
                            listaCorreos: new List<string> { correo }
                            );
                        return "Hola," + usuario_nombre + "\n Usted solicito la recuperacion de la contraseña. \n" +
                            "su nueva contraseña se envio a su correo:" + correo +
                            "\n ¡Por favor cambiar la contraseña actual";
                    }
                    else
                    {
                        return "El correo o clave son incorrectos";
                    }
                }
            }
        }

        public void PrivilegiosUsuarios()
        {
            if (cache_login.Cargo==Cargos.admin)
            {
                //code
            }
            if (cache_login.Cargo == Cargos.secretaria || cache_login.Cargo == Cargos.cagero)
            {
                //code
            }
        }
    }
}

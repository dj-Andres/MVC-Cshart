using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public abstract class ConnecionSql
    {
        private readonly string cadenaConexion;

        public ConnecionSql()
        {
            cadenaConexion = "Server=DESKTOP-BT2R86H\\SQLEXPRESS;DataBase=practicas;integrated security=true";
        }
        protected SqlConnection getConnection(){
            return new SqlConnection(cadenaConexion);
        }
    }
}
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acceso_Datos;

namespace Dominio
{
    public class UsuarioModelo
    {
        Usuario Usuario = new Usuario();

        public bool LoginUsuario(string user,string pass)
        {
            return Usuario.Login(user,pass);  
        }

    }
}

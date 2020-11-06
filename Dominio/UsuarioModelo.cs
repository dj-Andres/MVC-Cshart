using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acceso_Datos;
using ComunController.Cache;
namespace Dominio
{
    public class UsuarioModelo
    {
        Usuario Usuario = new Usuario();

        public bool LoginUsuario(string user,string pass)
        {
            return Usuario.Login(user,pass);  
        }
        //public bool editarClave(int user,string pass){
          //  if (user == cache_login.Id_usuario)
           // {

            //}
            //return true;
        //}
        public void PrivilegiosUsuarios()
        {
            if (cache_login.Cargo == Cargos.admin)
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

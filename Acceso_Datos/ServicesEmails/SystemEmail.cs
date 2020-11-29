using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos.ServicesEmails
{
    class SystemEmail:ServerEmails
    {
        public SystemEmail()
        {
            senderEmail = "correoEmpresarial";
            password = "clave";
            host = "smt.gmail.com";
            port = 587;
            ssl = true;
            inicialSmtclient();

        }
    }
}

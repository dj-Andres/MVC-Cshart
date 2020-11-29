using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;


namespace Presentacion
{
    public partial class recuperar_clave : Form
    {
        public recuperar_clave()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var usuario = new UsuarioModelo();
            var resultado = usuario.recuperar_contrasena(txtCorreo.Text);
            lblResultado.Text = resultado;
        }
    }
}

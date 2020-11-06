using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComunController.Cache;

namespace Presentacion
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de salir","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            DatosUsuarios();
            //privilegios de Usuarios//
            if(cache_login.Cargo==Cargos.secretaria){
                btnReportes.Enabled = false;
                btnBalances.Enabled = false;
            }
            if(cache_login.Cargo==Cargos.cagero){
                btnAsistencia.Enabled = false;
            }
            if (cache_login.Cargo == Cargos.admin){
                btnReportes.Enabled = true;
                btnBalances.Enabled = true;
                btnAsistencia.Enabled = true;
                btnREmpleados.Enabled = true;
            }

        }
        private void DatosUsuarios()
        {
            lblNombre.Text = cache_login.Nombre;
            LblApellido.Text = cache_login.Apellido;
            lblCorreo.Text = cache_login.correo;
        }
    }
}

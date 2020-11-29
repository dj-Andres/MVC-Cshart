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
using ComunController.Cache;

namespace Presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void cerrar_session(object server,FormClosedEventArgs e)
        {
            txtPass.Clear();
            txtUsuario.Clear();
            this.Show(); 
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Llenar todos los campos requeridos");
            }
            else
            {
                UsuarioModelo usuario = new UsuarioModelo();
                var loginValido = usuario.LoginUsuario(txtUsuario.Text, txtPass.Text);

                if(loginValido==true){
                    Menu principal = new Menu();
                    MessageBox.Show("Bienvenido" + cache_login.Nombre + "," + cache_login.Apellido);
                    principal.FormClosed += cerrar_session;
                    principal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("El usuario no se encuentra registrado");
                    txtUsuario.Focus();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var recuperar = new recuperar_clave();
            recuperar.ShowDialog();
        }
    }
}

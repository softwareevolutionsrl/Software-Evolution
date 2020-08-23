using Software_Evolution.managers.general;
using Software_Evolution.utils.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Evolution.views.general
{
    public partial class Login : BaseForm
    {
        private readonly UsuariosManager manager = new UsuariosManager();

        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtusuario.IsEmpty())
            {
                Mensaje("El usuario no debe estar en blanco");
                txtusuario.Focus();
                return;
            }

            if (txtpass.IsEmpty())
            {
                Mensaje("La contraseña no debe estar en blanco");
                txtpass.Focus();
                return;
            }
            try
            {
                var usuario = manager.AuthUser(txtusuario.Text, txtpass.Text);
                AppData.Instance.Currentuser = usuario;

                Principal principal = new Principal();
                principal.Show();
                this.Hide();
                
            }catch (Exception ex)
            {
                Mensaje(ex.Message);
                return;
            }
            
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

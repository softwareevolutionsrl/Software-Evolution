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
            if (textBox1.Text == "")
            {
                Mensaje("El usuario no debe estar en blanco");
                textBox1.Focus();
                return;
            }

            if (textBox2.Text == "")
            {
                Mensaje("La contraseña no debe estar en blanco");
                textBox2.Focus();
                return;
            }
            try
            {
                var usuario = manager.AuthUser(textBox1.Text, textBox2.Text);
                AppData.Instance.Currentuser = usuario;

                Principal principal = new Principal();
                principal.Show();
                this.Close();
                
            }catch (Exception ex)
            {
                Mensaje(ex.Message);
                return;
            }
            
        }
    }
}

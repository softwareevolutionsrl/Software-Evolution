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
    public partial class Principal : BaseForm
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void ventasFacturacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            ShowOrFocusForm(new OutUsuarios());
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowOrFocusForm(BaseForm form)
        {
            if (form.MultipleScreen)
            {
                form.MdiParent = this;
                form.StartPosition = FormStartPosition.CenterParent;
                form.Show();
            }
            else
            {
                var isOpen = false;
                foreach (Form openform in Application.OpenForms)
                {
                    if (openform.Name == form.Name)
                    {
                        isOpen = true;
                        openform.Focus();
                        break;
                    }
                }
                if (!isOpen)
                {
                    form.MdiParent = this;
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.Show();
                }
            }
        }
    }
}

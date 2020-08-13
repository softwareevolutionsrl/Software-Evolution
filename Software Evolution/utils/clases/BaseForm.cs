using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Evolution.utils.clases
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        protected void Mensaje(String msg)
        {
            MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}

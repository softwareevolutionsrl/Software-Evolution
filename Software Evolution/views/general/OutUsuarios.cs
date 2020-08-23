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
    public partial class OutUsuarios : BaseForm
    {
        private readonly UsuariosManager _manager = new UsuariosManager();
        public OutUsuarios()
        {
            InitializeComponent();
        }

        private void OutUsuarios_Activated(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            var data = _manager.getAllUsuarios();
            grid1.DataSource = data;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidarGrid(gridView1)) return;
            var username = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]).Field<String>("f_id_usuario");
            try
            {
                _manager.AsignarPermisosTablasSelect(username, 1);
                Mensaje("Permisos Asignados!");
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            if (!ValidarGrid(gridView1)) return;
            var username = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]).Field<String>("f_id_usuario");
            try
            {
                _manager.AsignarPermisosTablas(username, 1);
                Mensaje("Permisos Asignados!");
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!ValidarGrid(gridView1)) return;
            var username = gridView1.GetDataRow(gridView1.GetSelectedRows()[0]).Field<String>("f_id_usuario");
            try
            {
                _manager.AsignarPermisosTablas(username, 2);
                Mensaje("Permisos Asignados!");
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView1))
            {                
                var usuarioid = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "f_codigo_usuario"));
                var inusuario = new InUsuarios(usuarioid);
                (this.ParentForm as Principal).ShowOrFocusForm(inusuario);
            }
        }
    }
}

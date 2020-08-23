using Software_Evolution.managers.general;
using Software_Evolution.modalviews;
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
    public partial class InUsuarios : BaseForm
    {
        private DataTable tarticulos = new DataTable();
        private UsuariosManager manager = new UsuariosManager();
        public InUsuarios()
        {
            InitializeComponent();
            this.Creando = true;
            tarticulos.Columns.Add(new DataColumn("f_id",typeof(int)));
            tarticulos.Columns.Add(new DataColumn("f_descripcion", typeof(string)));
            gridarticulos.DataSource = tarticulos;
        }

        public InUsuarios(int usuarioid):this()
        {
            this.Creando = false;
            var userdata = manager.getUsuarioById(usuarioid);
            Modificar(userdata);
            cmbsubdep.EditValue = userdata.Field<int?>("f_sub_departamento");
            var tipart = manager.getUsuarioTipoArticulos(usuarioid);
            tarticulos.Clear();
            foreach(DataRow r in tipart.Rows)
            {
                tarticulos.Rows.Add(r);
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InUsuarios_Activated(object sender, EventArgs e)
        {
            cmbidiomas.LoadData();
            cmbcentrocosto.LoadData();
            cmbdep.LoadData();
            cmbdepponches.LoadData();
            cmbgrupo.LoadData();
            cmbmesa.LoadData();
        }

        private void cmbdepponches_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbdepponches.EditValue != null)
            {
                cmbsubdep.EditValue = null;
                cmbsubdep.Param = Convert.ToString(cmbdepponches.EditValue);
                cmbsubdep.LoadData();
            }
            else
            {
                cmbsubdep.Properties.DataSource = null;
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            txtpass.IsValidar = txtidusuario.Valor == 0;
            txtconfirmpass.IsValidar = txtidusuario.Valor == 0;
            cmbgrupo.IsValidar = cmbgrupo.Visible;
            if (!ValidarForm())
            {
                return;
            }
            if (txtpass.Text != "")
            {
                if (txtpass.Text != txtconfirmpass.Text)
                {
                    Mensaje("Las contraseñas no coinciden");
                    txtconfirmpass.Focus();
                    return;
                }

            }
            if (txtidusuario.Valor==0 && manager.UsuarioExiste(txtusuario.Text))
            {
                Mensaje("El Nombre de Usuario Existe...");
                txtusuario.Focus();
                return;
            }

            if(!ConfirmarMensaje("Desea salvar este registro?"))
            {
                return;
            }
            string clave = "";
            if (!txtpass.IsEmpty())
            {
                clave = manager.ToMD5(txtpass.Text);
            }
            Dictionary<String, object> datos = new Dictionary<string, object>();
            Grabar(datos);
            datos["f_permisos_libre"] = cmbgrupo.IsEmpty();
            datos["f_id_grupo"] = (cmbgrupo.IsEmpty()) ? "0" : cmbgrupo.EditValue;
            if (clave != "")
            {
                datos["f_password"] = clave;
            }
            try
            {
                manager.CreateUsuario(txtidusuario.Valor == 0, datos, tarticulos, ckcreausuario.Checked, clave);
            }catch(Exception ex)
            {
                Mensaje(ex.Message);
                return;
            }
            Limpiar();
        }

        private void evCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbgrupo.Visible = ckgrupo.Checked;
            lblgrupo.Visible = ckgrupo.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cmbtipoarticulo.EditValue != null)
            {
                var row = tarticulos.NewRow();
                row["f_id"] = Convert.ToInt32(cmbtipoarticulo.EditValue);
                row["f_descripcion"] = cmbtipoarticulo.Text;
                tarticulos.Rows.Add(row);
            }
            else
            {
                Mensaje("Debe seleccionar un tipo de articulo antes de continuar");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                gridView1.DeleteRow(gridView1.GetSelectedRows()[0]);
            }
        }

        protected override void Limpiar()
        {
            this.tarticulos.Clear();
            tabControl1.SelectedIndex = 0;
            base.Limpiar();
        }
    }
}

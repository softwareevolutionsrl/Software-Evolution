using Software_Evolution.managers.general;
using Software_Evolution.utils.clases;
using System;

namespace Software_Evolution.modalviews
{
    public partial class VendedorPickerForm : BaseForm
    {
        private readonly VendedoresManager vendedoresManager;
        public int Vendedorid { get; set; }

        public VendedorPickerForm(VendedoresManager vendedoresManager):this()
        {
            this.vendedoresManager = vendedoresManager;
            
        }

        public VendedorPickerForm()
        {
            InitializeComponent();
        }

        private void buscar()
        {
            try
            {
                var data = vendedoresManager.getVendedoresActivos();
                gridControl1.DataSource = data;
                gridControl1.Focus();
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            buscar();
        }

        private void VendedorPickerForm_Activated(object sender, System.EventArgs e)
        {
            buscar();
        }

        private void gridControl1_DoubleClick(object sender, System.EventArgs e)
        {
            if (ValidarGrid(gridView1))
            {
                Vendedorid = System.Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "f_idvendedor"));
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();                
            }
        }

        private void btn_cerrar_Click(object sender, System.EventArgs e)
        {
            Vendedorid = 0;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
    }
}

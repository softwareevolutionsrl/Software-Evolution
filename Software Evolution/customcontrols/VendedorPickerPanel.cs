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

namespace Software_Evolution.customcontrols
{
    public class VendedorPickerPanel : FlowLayoutPanel, IEvBaseComponent<int>
    {
        private EvIntegerTextBox txtId;
        private EvTextBox txtNombre;
        private LinkLabel lblvendedor;
        public Padding LblVendedorMargin { get=>this.lblvendedor.Margin; set => this.lblvendedor.Margin=value; }
        public Padding TxtIdMargin { get => this.txtId.Margin; set => this.txtId.Margin = value; }
        public Padding TxtNombreMargin { get => this.txtNombre.Margin; set => this.txtNombre.Margin = value; }
        public Size TxtIdSize { get=>this.txtId.Size; set=>this.txtId.Size=value; }
        public Size TxtNombreSize { get => this.txtNombre.Size; set => this.txtNombre.Size = value; }

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Hace que la tecla enter funcione como 'TAB'")]
        public bool EnterTab { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si hay que validar que el texto no este vacio")]
        public bool IsValidar { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si hay que limpiar el texto")]
        public bool IsLimpiar { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si el text se va a salvar")]
        public bool IsSalvar { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("El nombre del campo de la tabla al que debe guardar este texto")]
        public string FieldName { get; set; } = "";
        public int Valor { get =>this.txtId.Valor; set {
                this.txtId.Valor = value;
                buscar();
            } }
        public BaseForm parent { get; set; }

        private readonly VendedoresManager manager = new VendedoresManager();
        public VendedorPickerPanel()
        {
            InitializeComponent();
            this.Controls.Add(lblvendedor);
            this.Controls.Add(txtId);
            this.Controls.Add(txtNombre);
        }

        public bool IsEmpty()
        {
            return this.txtId.IsEmpty();
        }

        public void Limpiar()
        {
            this.txtId.Limpiar();
            this.txtNombre.Limpiar();
        }

        private void lblvendedor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var vendedoir = manager.SelectVendedorFromDialog(parent);
            if (vendedoir > 0)
            {
                this.Valor = vendedoir;
            }
        }

        private void txtid_Validated(object sender, EventArgs e)
        {
            buscar();
        }

        private void buscar()
        {
            if (Valor > 0)
            {
                DataRow res = manager.GetVendedorById(Valor);
                if (res != null)
                {
                    this.txtId.Valor = res.Field<int>("f_idvendedor");
                    this.txtNombre.Text = res.Field<String>("f_nombre") + " " + res.Field<String>("f_apellido");
                }
            }
        }

        private void InitializeComponent()
        {
            this.lblvendedor = new System.Windows.Forms.LinkLabel();
            this.txtId = new Software_Evolution.customcontrols.EvIntegerTextBox();
            this.txtNombre = new Software_Evolution.customcontrols.EvTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblvendedor
            // 
            this.lblvendedor.AutoSize = true;
            this.lblvendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblvendedor.Location = new System.Drawing.Point(0, 0);
            this.lblvendedor.Name = "lblvendedor";
            this.lblvendedor.Size = new System.Drawing.Size(100, 23);
            this.lblvendedor.TabIndex = 0;
            this.lblvendedor.TabStop = true;
            this.lblvendedor.Text = "Vendedor";
            this.lblvendedor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblvendedor_LinkClicked);
            // 
            // txtId
            // 
            this.txtId.EditValue = 0;
            this.txtId.EnterTab = true;
            this.txtId.FieldName = null;
            this.txtId.IsLimpiar = false;
            this.txtId.IsSalvar = false;
            this.txtId.IsValidar = false;
            this.txtId.Location = new System.Drawing.Point(0, 0);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Options.UseTextOptions = true;
            this.txtId.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtId.Properties.Mask.EditMask = "f0";
            this.txtId.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtId.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtId.Size = new System.Drawing.Size(125, 22);
            this.txtId.TabIndex = 0;
            this.txtId.Validated += new System.EventHandler(this.txtid_Validated);
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.EnterTab = false;
            this.txtNombre.FieldName = null;
            this.txtNombre.IsLimpiar = false;
            this.txtNombre.IsSalvar = false;
            this.txtNombre.IsValidar = false;
            this.txtNombre.Location = new System.Drawing.Point(0, 0);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 22);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.Valor = "";
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        public bool IsValid()
        {
            return !IsEmpty();
        }
    }
}

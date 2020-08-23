using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace Software_Evolution.customcontrols
{
    public class EvIntegerTextBox : TextEdit,IEvBaseComponent<int>
    {
        public EvIntegerTextBox()
        {
            this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Properties.Mask.EditMask = "f0";
            this.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            this.EditValue = 0;
        }

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

        [DefaultValue(0)]
        public int Valor { get => System.Convert.ToInt32(this.EditValue) ; set => this.EditValue=value; }

        public bool IsEmpty()
        {
            if(this.EditValue is null)
            {
                return true;
            }
            else
            {
                return this.EditValue.Equals(0);
            }
        }

        public bool IsValid()
        {
            return !this.EditValue.Equals(0);
        }

        public void Limpiar()
        {
            this.EditValue = 0;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter) && EnterTab)
            {
                SendKeys.Send("{TAB}");
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

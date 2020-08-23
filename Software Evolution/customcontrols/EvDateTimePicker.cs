using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace Software_Evolution.customcontrols
{
    class EvDateTimePicker : DateTimePicker, IEvBaseComponent<DateTime>
    {
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Hace que la tecla enter funcione como 'TAB'")]
        public bool EnterTab { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si hay que validar que el texto no este vacio")]
        public bool IsValidar { get; set; }

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
        public DateTime Valor { get =>this.Value.Date; set =>this.Value=value; }

        public EvDateTimePicker()
        {
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "dd-MM-yyyy";
        }

        public bool IsEmpty()
        {
            return false;
        }

        public void Limpiar()
        {
            this.Value = DateTime.Now;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter) && EnterTab)
            {
                SendKeys.Send("{TAB}");
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public bool IsValid()
        {
            return true;
        }
    }
}

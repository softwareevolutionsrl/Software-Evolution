using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Evolution.customcontrols
{
    public class EvMaskTextBox : MaskedTextBox, IEvBaseComponent<String>
    {
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
        public string Valor { get {
                this.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                var val = this.Text;
                this.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                return val;
            } set =>this.Text=value; }

        public EvMaskTextBox()
        {
            
        }

        public bool IsEmpty()
        {
            this.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            var empty = this.Text == String.Empty;
            this.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            return empty;
        }

        public void Limpiar()
        {
            this.Clear();
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
            return !IsEmpty();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Evolution.customcontrols
{
    public class EvCheckBox : CheckBox, IEvBaseComponent<bool>
    {
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Hace que la tecla enter funcione como 'TAB'")]
        public bool EnterTab { get; set; } = false;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si hay que validar que el texto no este vacio")]
        public bool IsValidar { get ; set ; }
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si hay que limpiar el texto")]        
        public bool IsLimpiar { get ; set ; }

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si el text se va a salvar")]
        public bool IsSalvar { get; set; } = true;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("El nombre del campo de la tabla al que debe guardar este texto")]
        public string FieldName { get; set; } = "";

        [Browsable(true)]
        [Category("Extended Properties")]        
        public bool Valor { get =>this.Checked; set =>this.Checked=value; }

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Valor por defecto que se le asigna en case de limpiar la pantalla")]        
        public bool DefaultValue { get; set; }

        [Description("No aplica")]
        public bool IsEmpty()
        {
            return false;
        }

        [Description("No Aplica")]
        public bool IsValid()
        {
            return true;
        }

        public void Limpiar()
        {
            this.Checked = DefaultValue;
        }


    }
}

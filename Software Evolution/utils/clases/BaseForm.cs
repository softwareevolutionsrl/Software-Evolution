using DevExpress.XtraGrid.Views.Grid;
using Software_Evolution.customcontrols;
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
    /// <summary>
    /// Esta es la clase base para todos los formularios a usar en el proyecto.   
    /// </summary>
    /// <remarks>
    /// Para el mejor funcionamiento del proyecto no debe haber formularios que no hereden de esta clase.
    /// </remarks>
    public partial class BaseForm : Form
    {
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Controla si una pantalla se puede cerrar sin confirmacion o no")]
        public bool RequireCloseConfirm { get; set; } = false;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Menseje que se mostrar al confirmar el cierre de pantalla")]
        public String CloseConfirmMsg { get; set; } = "Desea cerrar esta ventana?";

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica se la pantalla se puede abrir varias veces")]
        public bool MultipleScreen { get; set; } = false;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Indica si la pantalla esta creando o modificando")]
        protected bool Creando { get; set; } = false;

        protected ErrorProvider errorProvider = new ErrorProvider();

        public BaseForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            errorProvider.ContainerControl = this;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;            
        }

        //muestra un cuadro de dialogo con un mensaje informativo.
        protected void Mensaje(String msg)
        {
            MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        //muestra un cuadro de dialogo con un mensaje de confirmacion.
        protected bool ConfirmarMensaje(String mensaje)
        {
            var result= MessageBox.Show(mensaje,"Confirmar",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
        // valida si un datagrid esta vacio o no tiene ningun elemento seleccionado.
        protected bool ValidarGrid(GridView gridView)
        {
            return gridView.GetSelectedRows() != null;
        }
        // muestra un mensaje de confirmacion antes de cerrar la pantalla
        /// <remarks>
        /// Solo se muestra el mensaje si la propiedad <c>RequireCloseConfirm</c> esta verdadera.
        /// </remarks>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (RequireCloseConfirm)
            {
                if (!ConfirmarMensaje(CloseConfirmMsg))
                {
                    e.Cancel = true;
                }
            }
            base.OnFormClosing(e);
        }
        //limpia todos los objetos de la pantalla.
        /// <remarks>
        /// Solo limpia los objetos donde la propiedad <c>IsLimpiar</c> esta verdadera.
        /// </remarks>
        protected virtual void Limpiar()
        {
            errorProvider.Clear();
            foreach(Control control in this.Controls)
            {
                if (control is IEvBaseComponent<String>)
                {
                    if ((control as IEvBaseComponent<String>).IsLimpiar)
                        (control as IEvBaseComponent<String>).Limpiar();
                }
                if (control is IEvBaseComponent<int>)
                {
                    if ((control as IEvBaseComponent<int>).IsLimpiar)
                        (control as IEvBaseComponent<int>).Limpiar();
                }
                if (control is IEvBaseComponent<bool>)
                {
                    if ((control as IEvBaseComponent<bool>).IsLimpiar)
                        (control as IEvBaseComponent<bool>).Limpiar();
                }
                if (control is IEvBaseComponent<double>)
                {
                    if ((control as IEvBaseComponent<double>).IsLimpiar)
                        (control as IEvBaseComponent<double>).Limpiar();
                }
                if (control is IEvBaseComponent<object>)
                {
                    if ((control as IEvBaseComponent<object>).IsLimpiar)
                        (control as IEvBaseComponent<object>).Limpiar();
                }
                if(control is Panel)
                {
                    LimpiarPanel(control as Panel);
                }
                if (control is TabControl)
                {
                    LimpiarTab(control as TabControl);
                }
                if(control is GroupBox)
                {
                    LimpiarGroup(control as GroupBox);
                }
            }
        }

        protected void LimpiarPanel(Panel panel)
        {
            foreach(Control control in panel.Controls)
            {
                if(control is IEvBaseComponent<String> )
                {
                    if((control as IEvBaseComponent<String>).IsLimpiar)
                    (control as IEvBaseComponent<String>).Limpiar();
                }
                if (control is IEvBaseComponent<int>)
                {
                    if ((control as IEvBaseComponent<int>).IsLimpiar)
                        (control as IEvBaseComponent<int>).Limpiar();
                }
                if (control is IEvBaseComponent<bool>)
                {
                    if ((control as IEvBaseComponent<bool>).IsLimpiar)
                        (control as IEvBaseComponent<bool>).Limpiar();
                }
                if (control is IEvBaseComponent<double>)
                {
                    if ((control as IEvBaseComponent<double>).IsLimpiar)
                        (control as IEvBaseComponent<double>).Limpiar();
                }
                if (control is IEvBaseComponent<object>)
                {
                    if ((control as IEvBaseComponent<object>).IsLimpiar)
                        (control as IEvBaseComponent<object>).Limpiar();
                }
                if(control is TabControl)
                {
                    LimpiarTab((control as TabControl));
                }
                if(control is Panel)
                {
                    LimpiarPanel((control as Panel));
                }
                if (control is GroupBox)
                {
                    LimpiarGroup(control as GroupBox);
                }
            }
        }

        protected void LimpiarTab(TabControl tabControl)
        {
            foreach(TabPage page in tabControl.TabPages)
            {
                foreach (Control control in page.Controls)
                {
                    if (control is IEvBaseComponent<String>)
                    {
                        if ((control as IEvBaseComponent<String>).IsLimpiar)
                            (control as IEvBaseComponent<String>).Limpiar();
                    }
                    if (control is IEvBaseComponent<int>)
                    {
                        if ((control as IEvBaseComponent<int>).IsLimpiar)
                            (control as IEvBaseComponent<int>).Limpiar();
                    }
                    if (control is IEvBaseComponent<bool>)
                    {
                        if ((control as IEvBaseComponent<bool>).IsLimpiar)
                            (control as IEvBaseComponent<bool>).Limpiar();
                    }
                    if (control is IEvBaseComponent<double>)
                    {
                        if ((control as IEvBaseComponent<double>).IsLimpiar)
                            (control as IEvBaseComponent<double>).Limpiar();
                    }
                    if (control is IEvBaseComponent<object>)
                    {
                        if ((control as IEvBaseComponent<object>).IsLimpiar)
                            (control as IEvBaseComponent<object>).Limpiar();
                    }
                    if (control is Panel)
                    {
                        LimpiarPanel(control as Panel);
                    }
                    if (control is GroupBox)
                    {
                        LimpiarGroup(control as GroupBox);
                    }
                }
            }
        }

        protected void LimpiarGroup(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is IEvBaseComponent<String>)
                {
                    if ((control as IEvBaseComponent<String>).IsLimpiar)
                        (control as IEvBaseComponent<String>).Limpiar();
                }
                if (control is IEvBaseComponent<int>)
                {
                    if ((control as IEvBaseComponent<int>).IsLimpiar)
                        (control as IEvBaseComponent<int>).Limpiar();
                }
                if (control is IEvBaseComponent<bool>)
                {
                    if ((control as IEvBaseComponent<bool>).IsLimpiar)
                        (control as IEvBaseComponent<bool>).Limpiar();
                }
                if (control is IEvBaseComponent<double>)
                {
                    if ((control as IEvBaseComponent<double>).IsLimpiar)
                        (control as IEvBaseComponent<double>).Limpiar();
                }
                if (control is IEvBaseComponent<object>)
                {
                    if ((control as IEvBaseComponent<object>).IsLimpiar)
                        (control as IEvBaseComponent<object>).Limpiar();
                }
                if (control is TabControl)
                {
                    LimpiarTab((control as TabControl));
                }
                if (control is Panel)
                {
                    LimpiarPanel((control as Panel));
                }
            }
        }

        protected bool ValidarForm()
        {
            errorProvider.Clear();
            bool isValid = true;
            Control controltofocus = null; ;
            foreach (Control control in this.Controls)
            {
                if (control is IEvBaseComponent<String>)
                {
                    if(control.Enabled && (control as IEvBaseComponent<String>).IsValidar && !(control as IEvBaseComponent<String>).IsValid())
                    {
                        if (controltofocus == null)
                        {
                            controltofocus = control;
                        }
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is IEvBaseComponent<int>)
                {
                    if (control.Enabled && (control as IEvBaseComponent<int>).IsValidar && !(control as IEvBaseComponent<int>).IsValid())
                    {
                        if (controltofocus == null)
                        {
                            controltofocus = control;
                        }
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is IEvBaseComponent<bool>)
                {
                    if (control.Enabled && (control as IEvBaseComponent<bool>).IsValidar && !(control as IEvBaseComponent<bool>).IsValid())
                    {
                        if (controltofocus == null)
                        {
                            controltofocus = control;
                        }
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is IEvBaseComponent<double>)
                {
                    if (control.Enabled && (control as IEvBaseComponent<double>).IsValidar && !(control as IEvBaseComponent<double>).IsValid())
                    {
                        if (controltofocus == null)
                        {
                            controltofocus = control;
                        }
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is IEvBaseComponent<object>)
                {
                    if (control.Enabled && (control as IEvBaseComponent<object>).IsValidar && !(control as IEvBaseComponent<object>).IsValid())
                    {
                        if (controltofocus == null)
                        {
                            controltofocus = control;
                        }
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is Panel)
                {
                    if(!ValidarPanel(control as Panel))
                    {
                        if (controltofocus == null)
                        {
                            controltofocus = control;
                        }
                        isValid = false;
                    }
                }
                if (control is TabControl)
                {
                    if (!ValidarTab(control as TabControl))
                    {
                        if (controltofocus == null)
                        {
                            controltofocus = control;
                        }
                        isValid = false;
                    }
                }
                if (control is GroupBox)
                {
                    if (!ValidarGroup(control as GroupBox))
                    {
                        if (controltofocus == null)
                        {
                            controltofocus = control;
                        }
                        isValid = false;
                    }
                }
            }
            if (controltofocus != null)
            {
                controltofocus.Focus();
            }
            return isValid;
        }

        private bool ValidarPanel(Panel panel)
        {
            bool isValid = true;
            foreach (Control control in panel.Controls)
            {
                if (control is IEvBaseComponent<String>)
                {
                    if (control.Enabled && (control as IEvBaseComponent<String>).IsValidar && !(control as IEvBaseComponent<String>).IsValid())
                    {                        
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is IEvBaseComponent<int>)
                {
                    if (control.Enabled && (control as IEvBaseComponent<int>).IsValidar && !(control as IEvBaseComponent<int>).IsValid())
                    {
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is IEvBaseComponent<bool>)
                {
                    if (control.Enabled && (control as IEvBaseComponent<bool>).IsValidar && !(control as IEvBaseComponent<bool>).IsValid())
                    {
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is IEvBaseComponent<double>)
                {
                    if (control.Enabled && (control as IEvBaseComponent<double>).IsValidar && !(control as IEvBaseComponent<double>).IsValid())
                    {                        
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is IEvBaseComponent<object>)
                {
                    if (control.Enabled && (control as IEvBaseComponent<object>).IsValidar && !(control as IEvBaseComponent<object>).IsValid())
                    {
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is Panel)
                {
                    if (!ValidarPanel(control as Panel))
                    {                       
                        isValid = false;
                    }
                }
                if (control is TabControl)
                {
                    if (!ValidarTab(control as TabControl))
                    {
                        isValid = false;
                    }
                }
                if (control is GroupBox)
                {
                    if (!ValidarGroup(control as GroupBox))
                    {
                        isValid = false;
                    }
                }
            }
            return isValid;
        }

        private bool ValidarTab(TabControl tabControl)
        {
            bool isValid = true;
            foreach (TabPage page in tabControl.TabPages)
            {
                foreach (Control control in page.Controls)
                {
                    if (control is IEvBaseComponent<String>)
                    {
                        if (control.Enabled && (control as IEvBaseComponent<String>).IsValidar && !(control as IEvBaseComponent<String>).IsValid())
                        {
                            this.errorProvider.SetError(control, "Este campo es obligatorio!");
                            isValid = false;
                        }
                    }
                    if (control is IEvBaseComponent<int>)
                    {
                        if (control.Enabled && (control as IEvBaseComponent<int>).IsValidar && !(control as IEvBaseComponent<int>).IsValid())
                        {
                            this.errorProvider.SetError(control, "Este campo es obligatorio!");
                            isValid = false;
                        }
                    }
                    if (control is IEvBaseComponent<bool>)
                    {
                        if (control.Enabled && (control as IEvBaseComponent<bool>).IsValidar && !(control as IEvBaseComponent<bool>).IsValid())
                        {
                            this.errorProvider.SetError(control, "Este campo es obligatorio!");
                            isValid = false;
                        }
                    }
                    if (control is IEvBaseComponent<double>)
                    {
                        if (control.Enabled && (control as IEvBaseComponent<double>).IsValidar && !(control as IEvBaseComponent<double>).IsValid())
                        {
                            this.errorProvider.SetError(control, "Este campo es obligatorio!");
                            isValid = false;
                        }
                    }
                    if (control is IEvBaseComponent<object>)
                    {
                        if (control.Enabled && (control as IEvBaseComponent<object>).IsValidar && !(control as IEvBaseComponent<object>).IsValid())
                        {
                            this.errorProvider.SetError(control, "Este campo es obligatorio!");
                            isValid = false;
                        }
                    }
                    if (control is Panel)
                    {
                        if (!ValidarPanel(control as Panel))
                        {
                            isValid = false;
                        }
                    }                   
                    if (control is GroupBox)
                    {
                        if (!ValidarGroup(control as GroupBox))
                        {
                            isValid = false;
                        }
                    }
                }
            }
            return isValid;
        }

        private bool ValidarGroup(GroupBox groupBox)
        {
            bool isValid = true;
            foreach (Control control in groupBox.Controls)
            {
                if (control is IEvBaseComponent<String>)
                {
                    if (control.Enabled && (control as IEvBaseComponent<String>).IsValidar && !(control as IEvBaseComponent<String>).IsValid())
                    {
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is IEvBaseComponent<int>)
                {
                    if (control.Enabled && (control as IEvBaseComponent<int>).IsValidar && !(control as IEvBaseComponent<int>).IsValid())
                    {
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is IEvBaseComponent<bool>)
                {
                    if (control.Enabled && (control as IEvBaseComponent<bool>).IsValidar && !(control as IEvBaseComponent<bool>).IsValid())
                    {
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is IEvBaseComponent<double>)
                {
                    if (control.Enabled && (control as IEvBaseComponent<double>).IsValidar && !(control as IEvBaseComponent<double>).IsValid())
                    {
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is IEvBaseComponent<object>)
                {
                    if (control.Enabled && (control as IEvBaseComponent<object>).IsValidar && !(control as IEvBaseComponent<object>).IsValid())
                    {
                        this.errorProvider.SetError(control, "Este campo es obligatorio!");
                        isValid = false;
                    }
                }
                if (control is Panel)
                {
                    if (!ValidarPanel(control as Panel))
                    {
                        isValid = false;
                    }
                }                
            }
        
            return isValid;
        }
        
        protected Dictionary<string, object> Grabar(Dictionary<string, object> values)
        {   
            foreach (Control control in this.Controls)
            {
                if (control is IEvBaseComponent<String>)
                {
                    if((control as IEvBaseComponent<String>).IsSalvar && !((control as IEvBaseComponent<String>).FieldName is null))
                    {
                        if(!(control as IEvBaseComponent<String>).FieldName.Equals("") && !(control as IEvBaseComponent<String>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<String>).FieldName] = (control as IEvBaseComponent<String>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<int>)
                {
                    if ((control as IEvBaseComponent<int>).IsSalvar && !((control as IEvBaseComponent<int>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<int>).FieldName.Equals("") && !(control as IEvBaseComponent<int>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<int>).FieldName] = (control as IEvBaseComponent<int>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<bool>)
                {
                    if ((control as IEvBaseComponent<bool>).IsSalvar && !((control as IEvBaseComponent<bool>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<bool>).FieldName.Equals("") && !(control as IEvBaseComponent<bool>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<bool>).FieldName] = (control as IEvBaseComponent<bool>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<double>)
                {
                    if ((control as IEvBaseComponent<double>).IsSalvar && !((control as IEvBaseComponent<double>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<double>).FieldName.Equals("") && !(control as IEvBaseComponent<double>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<double>).FieldName] = (control as IEvBaseComponent<double>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<object>)
                {
                    if ((control as IEvBaseComponent<object>).IsSalvar && !((control as IEvBaseComponent<object>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<object>).FieldName.Equals("") && !(control as IEvBaseComponent<object>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<object>).FieldName] = (control as IEvBaseComponent<object>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<DateTime>)
                {
                    if ((control as IEvBaseComponent<DateTime>).IsSalvar && !((control as IEvBaseComponent<DateTime>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<DateTime>).FieldName.Equals("") && !(control as IEvBaseComponent<DateTime>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<DateTime>).FieldName] = (control as IEvBaseComponent<DateTime>).Valor;
                        }
                    }
                }
                if (control is Panel)
                {
                    Grabar(control as Panel, values);
                }
                if (control is TabControl)
                {
                    Grabar(control as TabControl, values);
                }
                if (control is GroupBox)
                {
                    Grabar(control as GroupBox, values);
                }
            }
            return values;
        }

        private void Grabar(Panel panel,Dictionary<String,object> values)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is IEvBaseComponent<String>)
                {
                    if ((control as IEvBaseComponent<String>).IsSalvar && !((control as IEvBaseComponent<String>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<String>).FieldName.Equals("") && !(control as IEvBaseComponent<String>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<String>).FieldName] = (control as IEvBaseComponent<String>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<int>)
                {
                    if ((control as IEvBaseComponent<int>).IsSalvar && !((control as IEvBaseComponent<int>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<int>).FieldName.Equals("") && !(control as IEvBaseComponent<int>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<int>).FieldName] = (control as IEvBaseComponent<int>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<bool>)
                {
                    if ((control as IEvBaseComponent<bool>).IsSalvar && !((control as IEvBaseComponent<bool>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<bool>).FieldName.Equals("") && !(control as IEvBaseComponent<bool>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<bool>).FieldName] = (control as IEvBaseComponent<bool>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<double>)
                {
                    if ((control as IEvBaseComponent<double>).IsSalvar && !((control as IEvBaseComponent<double>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<double>).FieldName.Equals("") && !(control as IEvBaseComponent<double>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<double>).FieldName] = (control as IEvBaseComponent<double>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<object>)
                {
                    if ((control as IEvBaseComponent<object>).IsSalvar && !((control as IEvBaseComponent<object>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<object>).FieldName.Equals("") && !(control as IEvBaseComponent<object>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<object>).FieldName] = (control as IEvBaseComponent<object>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<DateTime>)
                {
                    if ((control as IEvBaseComponent<DateTime>).IsSalvar && !((control as IEvBaseComponent<DateTime>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<DateTime>).FieldName.Equals("") && !(control as IEvBaseComponent<DateTime>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<DateTime>).FieldName] = (control as IEvBaseComponent<DateTime>).Valor;
                        }
                    }
                }
                if (control is Panel)
                {
                    Grabar(control as Panel, values);
                }
                if (control is TabControl)
                {
                    Grabar(control as TabControl, values);
                }
                if (control is GroupBox)
                {
                    Grabar(control as GroupBox, values);
                }
            }
        }

        private void Grabar(TabControl tab, Dictionary<String, object> values)
        {
            foreach(TabPage page in tab.TabPages)
            {
                foreach (Control control in page.Controls)
                {
                    if (control is IEvBaseComponent<String>)
                    {
                        if ((control as IEvBaseComponent<String>).IsSalvar && !((control as IEvBaseComponent<String>).FieldName is null))
                        {
                            if (!(control as IEvBaseComponent<String>).FieldName.Equals("") && !(control as IEvBaseComponent<String>).IsEmpty())
                            {
                                values[(control as IEvBaseComponent<String>).FieldName] = (control as IEvBaseComponent<String>).Valor;
                            }
                        }
                    }
                    if (control is IEvBaseComponent<int>)
                    {
                        if ((control as IEvBaseComponent<int>).IsSalvar && !((control as IEvBaseComponent<int>).FieldName is null))
                        {
                            if (!(control as IEvBaseComponent<int>).FieldName.Equals("") && !(control as IEvBaseComponent<int>).IsEmpty())
                            {
                                values[(control as IEvBaseComponent<int>).FieldName] = (control as IEvBaseComponent<int>).Valor;
                            }
                        }
                    }
                    if (control is IEvBaseComponent<bool>)
                    {
                        if ((control as IEvBaseComponent<bool>).IsSalvar && !((control as IEvBaseComponent<bool>).FieldName is null))
                        {
                            if (!(control as IEvBaseComponent<bool>).FieldName.Equals("") && !(control as IEvBaseComponent<bool>).IsEmpty())
                            {
                                values[(control as IEvBaseComponent<bool>).FieldName] = (control as IEvBaseComponent<bool>).Valor;
                            }
                        }
                    }
                    if (control is IEvBaseComponent<double>)
                    {
                        if ((control as IEvBaseComponent<double>).IsSalvar && !((control as IEvBaseComponent<double>).FieldName is null))
                        {
                            if (!(control as IEvBaseComponent<double>).FieldName.Equals("") && !(control as IEvBaseComponent<double>).IsEmpty())
                            {
                                values[(control as IEvBaseComponent<double>).FieldName] = (control as IEvBaseComponent<double>).Valor;
                            }
                        }
                    }
                    if (control is IEvBaseComponent<object>)
                    {
                        if ((control as IEvBaseComponent<object>).IsSalvar && !((control as IEvBaseComponent<object>).FieldName is null))
                        {
                            if (!(control as IEvBaseComponent<object>).FieldName.Equals("") && !(control as IEvBaseComponent<object>).IsEmpty())
                            {
                                values[(control as IEvBaseComponent<object>).FieldName] = (control as IEvBaseComponent<object>).Valor;
                            }
                        }
                    }
                    if (control is IEvBaseComponent<DateTime>)
                    {
                        if ((control as IEvBaseComponent<DateTime>).IsSalvar && !((control as IEvBaseComponent<DateTime>).FieldName is null))
                        {
                            if (!(control as IEvBaseComponent<DateTime>).FieldName.Equals("") && !(control as IEvBaseComponent<DateTime>).IsEmpty())
                            {
                                values[(control as IEvBaseComponent<DateTime>).FieldName] = (control as IEvBaseComponent<DateTime>).Valor;
                            }
                        }
                    }
                    if (control is Panel)
                    {
                        Grabar(control as Panel, values);
                    }                    
                    if (control is GroupBox)
                    {
                        Grabar(control as GroupBox, values);
                    }
                }
            }
        }

        private void Grabar(GroupBox group, Dictionary<String, object> values)
        {
            foreach (Control control in group.Controls)
            {
                if (control is IEvBaseComponent<String>)
                {
                    if ((control as IEvBaseComponent<String>).IsSalvar && !((control as IEvBaseComponent<String>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<String>).FieldName.Equals("") && !(control as IEvBaseComponent<String>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<String>).FieldName] = (control as IEvBaseComponent<String>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<int>)
                {
                    if ((control as IEvBaseComponent<int>).IsSalvar && !((control as IEvBaseComponent<int>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<int>).FieldName.Equals("") && !(control as IEvBaseComponent<int>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<int>).FieldName] = (control as IEvBaseComponent<int>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<bool>)
                {
                    if ((control as IEvBaseComponent<bool>).IsSalvar && !((control as IEvBaseComponent<bool>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<bool>).FieldName.Equals("") && !(control as IEvBaseComponent<bool>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<bool>).FieldName] = (control as IEvBaseComponent<bool>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<double>)
                {
                    if ((control as IEvBaseComponent<double>).IsSalvar && !((control as IEvBaseComponent<double>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<double>).FieldName.Equals("") && !(control as IEvBaseComponent<double>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<double>).FieldName] = (control as IEvBaseComponent<double>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<object>)
                {
                    if ((control as IEvBaseComponent<object>).IsSalvar && !((control as IEvBaseComponent<object>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<object>).FieldName.Equals("") && !(control as IEvBaseComponent<object>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<object>).FieldName] = (control as IEvBaseComponent<object>).Valor;
                        }
                    }
                }
                if (control is IEvBaseComponent<DateTime>)
                {
                    if ((control as IEvBaseComponent<DateTime>).IsSalvar && !((control as IEvBaseComponent<DateTime>).FieldName is null))
                    {
                        if (!(control as IEvBaseComponent<DateTime>).FieldName.Equals("") && !(control as IEvBaseComponent<DateTime>).IsEmpty())
                        {
                            values[(control as IEvBaseComponent<DateTime>).FieldName] = (control as IEvBaseComponent<DateTime>).Valor;
                        }
                    }
                }
                if (control is Panel)
                {
                    Grabar(control as Panel, values);
                }                               
            }
        }

        protected virtual void Modificar(DataRow data)
        {
            foreach (Control control in this.Controls)
            {
                if (control is IEvBaseComponent<String> obj)
                {
                    if(!(obj.FieldName is null))
                    {
                        if (!obj.FieldName.Equals(""))
                        {
                            obj.Valor = data.Field<string>(obj.FieldName)??"";
                        }
                    }
                }else if (control is IEvBaseComponent<int> obji)
                {
                    if (!(obji.FieldName is null))
                    {
                        if (!obji.FieldName.Equals(""))
                        {
                            obji.Valor = data.Field<int?>(obji.FieldName)??0;
                        }
                    }
                }else
                if (control is IEvBaseComponent<bool> objb)
                {
                    if (!(objb.FieldName is null))
                    {
                        if (!objb.FieldName.Equals(""))
                        {
                            objb.Valor = data.Field<bool?>(objb.FieldName)??false;
                        }
                    }
                }
                else if (control is IEvBaseComponent<double> objd)
                {
                    if (!(objd.FieldName is null))
                    {
                        if (!objd.FieldName.Equals(""))
                        {
                            objd.Valor = Convert.ToDouble(data.Field<Decimal?>(objd.FieldName) ?? 0);
                        }
                    }
                }else
                if (control is IEvBaseComponent<object> objo)
                {
                    if (!(objo.FieldName is null))
                    {
                        if (!objo.FieldName.Equals(""))
                        {
                            objo.Valor = data.Field<object>(objo.FieldName);
                        }
                    }
                } else
                if (control is IEvBaseComponent<DateTime> objt)
                {
                    if (!(objt.FieldName is null))
                    {
                        if (!objt.FieldName.Equals(""))
                        {
                            objt.Valor = data.Field<DateTime?>(objt.FieldName)?? DateTime.Now;
                        }
                    }
                }else
                if (control is Panel panel)
                {
                    Modificar(panel, data);
                }else
                if (control is TabControl tab)
                {
                    Modificar(tab, data);
                }
                if (control is GroupBox group)
                {
                    Modificar(group,data);
                }
            }
        }

        private void Modificar(GroupBox group, DataRow data)
        {
            foreach (Control control in group.Controls)
            {
                if (control is IEvBaseComponent<String> obj)
                {
                    if (!(obj.FieldName is null))
                    {
                        if (!obj.FieldName.Equals(""))
                        {
                            obj.Valor = data.Field<string>(obj.FieldName) ?? "";
                        }
                    }
                }
                else if (control is IEvBaseComponent<int> obji)
                {
                    if (!(obji.FieldName is null))
                    {
                        if (!obji.FieldName.Equals(""))
                        {
                            obji.Valor = data.Field<int?>(obji.FieldName) ?? 0;
                        }
                    }
                }
                else
               if (control is IEvBaseComponent<bool> objb)
                {
                    if (!(objb.FieldName is null))
                    {
                        if (!objb.FieldName.Equals(""))
                        {
                            objb.Valor = data.Field<bool?>(objb.FieldName) ?? false;
                        }
                    }
                }
                else if (control is IEvBaseComponent<double> objd)
                {
                    if (!(objd.FieldName is null))
                    {
                        if (!objd.FieldName.Equals(""))
                        {
                            objd.Valor = Convert.ToDouble(data.Field<Decimal?>(objd.FieldName) ?? 0);
                        }
                    }
                }
                else
                if (control is IEvBaseComponent<object> objo)
                {
                    if (!(objo.FieldName is null))
                    {
                        if (!objo.FieldName.Equals(""))
                        {
                            objo.Valor = data.Field<object>(objo.FieldName);
                        }
                    }
                }
                else
                if (control is IEvBaseComponent<DateTime> objt)
                {
                    if (!(objt.FieldName is null))
                    {
                        if (!objt.FieldName.Equals(""))
                        {
                            objt.Valor = data.Field<DateTime?>(objt.FieldName) ?? DateTime.Now;
                        }
                    }
                }
                else
                if (control is Panel pane)
                {
                    Modificar(pane, data);
                }
               
              
               
            }
        }

        private void Modificar(TabControl tab, DataRow data)
        {
            foreach(TabPage page in tab.TabPages)
            {
                foreach (Control control in page.Controls)
                {
                    if (control is IEvBaseComponent<String> obj)
                    {
                        if (!(obj.FieldName is null))
                        {
                            if (!obj.FieldName.Equals(""))
                            {
                                obj.Valor = data.Field<string>(obj.FieldName) ?? "";
                            }
                        }
                    }
                    else if (control is IEvBaseComponent<int> obji)
                    {
                        if (!(obji.FieldName is null))
                        {
                            if (!obji.FieldName.Equals(""))
                            {
                                obji.Valor = data.Field<int?>(obji.FieldName) ?? 0;
                            }
                        }
                    }
                    else
                   if (control is IEvBaseComponent<bool> objb)
                    {
                        if (!(objb.FieldName is null))
                        {
                            if (!objb.FieldName.Equals(""))
                            {
                                objb.Valor = data.Field<bool?>(objb.FieldName) ?? false;
                            }
                        }
                    }
                    else if (control is IEvBaseComponent<double> objd)
                    {
                        if (!(objd.FieldName is null))
                        {
                            if (!objd.FieldName.Equals(""))
                            {
                                objd.Valor = Convert.ToDouble(data.Field<Decimal?>(objd.FieldName) ?? 0);
                            }
                        }
                    }
                    else
                    if (control is IEvBaseComponent<object> objo)
                    {
                        if (!(objo.FieldName is null))
                        {
                            if (!objo.FieldName.Equals(""))
                            {
                                objo.Valor = data.Field<object>(objo.FieldName);
                            }
                        }
                    }
                    else
                    if (control is IEvBaseComponent<DateTime> objt)
                    {
                        if (!(objt.FieldName is null))
                        {
                            if (!objt.FieldName.Equals(""))
                            {
                                objt.Valor = data.Field<DateTime?>(objt.FieldName) ?? DateTime.Now;
                            }
                        }
                    }
                    else
                    if (control is Panel pane)
                    {
                        Modificar(pane, data);
                    }                    
                }
            }
        }

        private void Modificar(Panel panel, DataRow data)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is IEvBaseComponent<String> obj)
                {
                    if (!(obj.FieldName is null))
                    {
                        if (!obj.FieldName.Equals(""))
                        {
                            obj.Valor = data.Field<string>(obj.FieldName) ?? "";
                        }
                    }
                }
                else if (control is IEvBaseComponent<int> obji)
                {
                    if (!(obji.FieldName is null))
                    {
                        if (!obji.FieldName.Equals(""))
                        {
                            obji.Valor = data.Field<int?>(obji.FieldName) ?? 0;
                        }
                    }
                }
                else
               if (control is IEvBaseComponent<bool> objb)
                {
                    if (!(objb.FieldName is null))
                    {
                        if (!objb.FieldName.Equals(""))
                        {
                            objb.Valor = data.Field<bool?>(objb.FieldName) ?? false;
                        }
                    }
                }
                else if (control is IEvBaseComponent<double> objd)
                {
                    if (!(objd.FieldName is null))
                    {
                        if (!objd.FieldName.Equals(""))
                        {                            
                            objd.Valor = Convert.ToDouble(data.Field<Decimal?>(objd.FieldName) ?? 0);
                        }
                    }
                }
                else
                if (control is IEvBaseComponent<object> objo)
                {
                    if (!(objo.FieldName is null))
                    {
                        if (!objo.FieldName.Equals(""))
                        {
                            objo.Valor = data.Field<object>(objo.FieldName);
                        }
                    }
                }
                else
                if (control is IEvBaseComponent<DateTime> objt)
                {
                    if (!(objt.FieldName is null))
                    {
                        if (!objt.FieldName.Equals(""))
                        {
                            objt.Valor = data.Field<DateTime?>(objt.FieldName) ?? DateTime.Now;
                        }
                    }
                }
                else
                if (control is Panel pane)
                {
                    Modificar(pane, data);
                }
                else
                if (control is TabControl tab)
                {
                    Modificar(tab, data);
                }else
                if (control is GroupBox group)
                {
                    Modificar(group, data);
                }
            }
        }
    }

}

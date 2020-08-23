using Software_Evolution.data;
using Software_Evolution.modalviews;
using Software_Evolution.utils.clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.managers.general
{
    public class VendedoresManager
    {
        private readonly QueryManager queryManager = QueryManager.Instance;

        public VendedoresManager()
        {

        }

        public DataTable getVendedoresActivos()
        {
            try
            {
                queryManager.Open();
                var result = queryManager.Query("SELECT f_idvendedor,f_nombre,f_apellido,f_telefono1,f_telefono2,f_direccion,f_activo,f_email from t_vendedores where f_activo=true");
                queryManager.Close();
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataRow GetVendedorById(int vendedorid)
        {
            var sql = "SELECT f_idvendedor,f_nombre,f_apellido,f_telefono1,f_telefono2,f_direccion,f_activo,f_email,f_zona," +
                "  f_comisiones_departamentos,f_comisiones_venta,f_comisiones_cobranza,f_comisiones_volumen,f_comisiones_utilidad," +
                "  f_comision_cobranza,f_comision_desc_ck_devueltos,f_supervisor,f_comision_venta,f_comision_devolucion," +
                $"  f_nombre2,f_proyecto,f_fideicomiso FROM  public.t_vendedores where f_idvendedor={vendedorid}";
            try
            {
                queryManager.Open();
                var res = queryManager.Query(sql);
                queryManager.Close();
                if (res.Rows.Count > 0)
                {
                    return res.Rows[0] as DataRow;
                }
                return null;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public int SelectVendedorFromDialog(BaseForm parent)
        {
            int result = 0;
            VendedorPickerForm dialog = new VendedorPickerForm(this);
            var dialolresult = dialog.ShowDialog(parent);
            if (dialolresult == System.Windows.Forms.DialogResult.OK)
            {
                result = dialog.Vendedorid;
            }
            dialog.Dispose();
            return result;
        }
    }
}

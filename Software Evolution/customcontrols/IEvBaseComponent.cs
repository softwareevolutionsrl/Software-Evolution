using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.customcontrols
{
    public interface IEvBaseComponent<T>
    {
       bool EnterTab { get; set; }

        
        bool IsValidar { get; set; }

       
        bool IsLimpiar { get; set; }

      
        bool IsSalvar { get; set; }
        
        String FieldName { get; set; }

        T Valor
        {
            set;
            get;
        }
       
        bool IsEmpty();

        void Limpiar();

        bool IsValid();
    }
}

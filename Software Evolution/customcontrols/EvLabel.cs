using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Evolution.customcontrols
{
    public class EvLabel:Label
    {
        public EvLabel()
        {
            this.AutoSize = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));                                 
            this.Text = "EvLabel";
        }
    }
}

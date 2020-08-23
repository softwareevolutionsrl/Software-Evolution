using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.customcontrols
{
    class EvPassWordTextBox: EvTextBox
    {
        public EvPassWordTextBox()
        {
            this.PasswordChar = '*';
        }
    }
}

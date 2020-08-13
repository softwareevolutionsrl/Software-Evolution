using Software_Evolution.views.general;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Software_Evolution.data;

namespace Software_Evolution
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConexionManager.Instance.InitConexion();
            Application.Run(new Login());
        }
    }
}

using Software_Evolution.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution
{
    public sealed class AppData
    {
        private readonly static AppData _instance = new AppData();
        private Usuario _currentuser;
        private AppData()
        {

        }

        public static AppData Instance
        {
            get
            {
                return _instance;
            }
        }

        public Usuario Currentuser { get => _currentuser; set => _currentuser = value; }
    }
}

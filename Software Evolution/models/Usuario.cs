using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.models
{
    public class Usuario
    {
        private int codigousuario;
        private String username;
        private String password;
        private String apellido;
        private String nombre;
        private String direccion;
        private int idgrupo;
        private bool permisoslibre;
        private String telefono;
        private String email;

        public Usuario(int codigousuario, String username, string password, string apellido, string nombre, string direccion, int idgrupo, bool permisoslibre, string telefono, string email)
        {
            this.codigousuario = codigousuario;
            this.username = username;
            this.password = password;
            this.apellido = apellido;
            this.nombre = nombre;
            this.direccion = direccion;
            this.idgrupo = idgrupo;
            this.permisoslibre = permisoslibre;
            this.telefono = telefono;
            this.email = email;
        }

        public int Codigousuario { get => codigousuario; set => codigousuario = value; }
        public String Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Idgrupo { get => idgrupo; set => idgrupo = value; }
        public bool Permisoslibre { get => permisoslibre; set => permisoslibre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
    }
}

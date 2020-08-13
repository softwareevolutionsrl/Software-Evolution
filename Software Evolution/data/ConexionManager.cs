using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Npgsql;

namespace Software_Evolution.data
{
    public sealed class ConexionManager
    {
        private readonly static ConexionManager _instance = new ConexionManager();
        private String _host, _database, _adminuser,_adminpass;
        private ConexionManager()
        {

        }

        public static ConexionManager Instance
        {
            get
            {
                return _instance;
            }
        }

        public bool Isinit { get; set; }

        public void InitConexion()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(@"evolutionconfig.xml");
                XmlNode rootnode = document.SelectSingleNode("root");
                _host = rootnode.SelectSingleNode("host").InnerText;
                _database = rootnode.SelectSingleNode("database").InnerText;
                _adminuser = rootnode.SelectSingleNode("defaultuser").InnerText;
                _adminpass = rootnode.SelectSingleNode("key").InnerText;
                Isinit = true;
            }
            catch(XmlException ex)
            {
                Isinit = false;
                throw new Exception(ex.Message);
            }
        }

        public bool validateConexion()
        {
            var isvalide = false;
            try
            {
                if (!Isinit)
                {
                    throw new Exception("El manejador de conexiones no se ha iniciado!");
                }
                var url = $"Server={_host};Port=5432; User Id={_adminuser};Password={_adminpass};Database = {_database}";
                var con = new NpgsqlConnection(url);
                con.Open();
                con.Close();
                isvalide = true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                isvalide = false;
            }
            return isvalide;
            
        }

        public NpgsqlConnection GetConnection(String user,String pass)
        {
            if (!Isinit)
            {
                throw new Exception("El manejador de conexiones no se ha iniciado!");
            }
            var url = $"Server={_host};Port=5432; User Id={user};Password={pass};Database = {_database}";
            var con = new NpgsqlConnection(url);
            return con;
        }
    }
}

using Software_Evolution.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Software_Evolution.models;
using Npgsql;
using System.Data;

namespace Software_Evolution.managers.general
{
    public class UsuariosManager
    {
        private readonly QueryManager queryManager = QueryManager.Instance;

        public Usuario AuthUser(String username,String password)
        {            
            try
            {
                var conexion = ConexionManager.Instance.GetConnection(username, password);
                conexion.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter($"select * from t_usuario where  f_id_usuario='{username}' and f_activo=true", conexion);
                NpgsqlCommandBuilder comando = new NpgsqlCommandBuilder(da);
                var tabla = new DataTable();
                da.Fill(tabla);
                da.Dispose();
                comando.Dispose();
                conexion.Close();
                if (tabla.Rows.Count == 0)
                {
                    throw new Exception("La cuenta de su usuario esta desactivado");
                }
                var res = tabla.Rows[0];
                var usuario =new Usuario(res.Field<int>("f_codigo_usuario"), res.Field<String>("f_id_usuario"), res.Field<String>("f_password"),
                    res.Field<String>("f_apellido"), res.Field<String>("f_nombre"), res.Field<String>("f_direccion"), res.Field<int>("f_id_grupo"), res.Field<Boolean>("f_permisos_libre"),
                    res.Field<String>("f_telefono"), res.Field<String>("f_email"));
                return usuario;
            }
            catch(Exception ex)
            {
                if(ex is NpgsqlException)
                {
                    throw new Exception("Usuario o contraseña incorrectos");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public String ToMD5(String text)
        {
            var md5 = MD5.Create();
            var bytes = System.Text.Encoding.ASCII.GetBytes(text);
            var hasbytes = md5.ComputeHash(bytes);
            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hasbytes.Length; i++)
            {
                sb.Append(hasbytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}

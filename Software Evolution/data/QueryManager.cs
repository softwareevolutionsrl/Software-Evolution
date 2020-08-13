using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.data
{
    public sealed class QueryManager
    {
        private readonly static QueryManager _instance = new QueryManager();
        NpgsqlConnection connection ;
        private bool work;
        private bool isOpen;

        private QueryManager()
        {

        }

        public static QueryManager Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Open()
        {
            try
            {
                if(!work && !isOpen)
                {
                    connection = ConexionManager.Instance.GetConnection(AppData.Instance.Currentuser.Username, AppData.Instance.Currentuser.Password);
                    connection.Open();
                    isOpen = true;
                }
            }catch(NpgsqlException ex)
            {
                throw ex;
            }
        }

        public void Close()
        {
            try
            {
                if(!work && connection!=null && isOpen)
                {
                    connection.Close();
                    isOpen = false;
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public void BeginWork()
        {
            if(work)
            {
            throw new Exception("Ya hay una transaccion iniciada");
            }
            try
            {
                Open();
                work = true;
                var cmd = new NpgsqlCommand("BEGIN WORK", connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public void RollBack()
        {
            if (!work)
            {
                throw new Exception("No hay una transaccion iniciada");
            }
            try
            {
                work = false;
                var cmd = new NpgsqlCommand("ROLLBACK", connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public void CommitWork()
        {
            if (!work)
            {
                throw new Exception("No hay una transaccion iniciada");
            }
            try
            {
                work = false;
                var cmd = new NpgsqlCommand("COMMIT WORK", connection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public DataTable Query(String sql)
        {
            try
            {
                Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connection);
                NpgsqlCommandBuilder comando = new NpgsqlCommandBuilder(da);
                var tabla = new DataTable();
                da.Fill(tabla);
                Close();                
                return tabla;
            }catch(NpgsqlException ex)
            {
                throw ex;
            }
        }
    }
}

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
        NpgsqlTransaction tran;
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
                throw new Exception("Ya existe transaccion iniciada");
            }
            try
            {
                Open();
                work = true;
                tran = connection.BeginTransaction();
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
                tran.Rollback();
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
                tran.Commit();
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

        public int Execute(String sql)
        {
            try
            {
                Open();
                var cmd = new NpgsqlCommand(sql,connection);
                var result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable QueryProcedure(String procedurename,String param)
        {
            var cursorname = procedurename.Substring(1);
            var p = param ?? "";
            var parameters = $"'{cursorname}'" + ((!p.Equals("")) ? $",{param}" : "");
            try
            {
                BeginWork();
                NpgsqlCommand cmd = new NpgsqlCommand($"select {procedurename}({parameters})",connection);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cmd.CommandText= $"fetch all in \"{cursorname}\"";
                cmd.CommandType = CommandType.Text;
                var dr = cmd.ExecuteReader();
                DataTable result = new DataTable();
                result.Load(dr);
                CommitWork();
                return result;
            }
            catch (NpgsqlException ex)
            {
                RollBack();
                throw ex;
            }
        }

        public int GetSecuencia(string tipodoc)
        {
            try
            {
                var sql = $"select get_secuencia('{tipodoc}')";
                var res = Query(sql);
                var secuencia = res.Rows[0].Field<int>("get_secuencia");
                return secuencia;
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public string GetTipoDoc(int tipo)
        {
            try
            {
                var sql = $"select f_tipodoc from t_tiposdocumentos where f_indiceordenador ={tipo}";
                var res = Query(sql);
                var tipodoc = res.Rows[0].Field<string>("f_tipodoc");
                return tipodoc;
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
        }

        public int CreateRecord(String tabla,Dictionary<String,object> record)
        {
            String columns = "";
            String values = "";
            foreach (KeyValuePair<string, object> entry in record)
            {
                columns += $",{entry.Key}";
                if(entry.Value is string)
                {
                    values += $",'{entry.Value}'";
                }
                else if (entry.Value is int)
                {
                    values += $",{Convert.ToInt32(entry.Value)}";
                }
                else if (entry.Value is double)
                {
                    values += $",{Convert.ToDouble(entry.Value)}";
                }
                else if (entry.Value is bool)
                {
                    values += $",{entry.Value}";
                }
                else if (entry.Value is DateTime val)
                {
                    values += $",'{val.ToString("yyyyMMdd")}'";
                }
                else
                {
                    values += $",'{entry.Value}'";
                }
            }

            try
            {
                var sql = $"insert into {tabla} ({columns.Substring(1)}) values ({values.Substring(1)})";
                Console.WriteLine(sql);
                Open();
                var cmd = new NpgsqlCommand(sql, connection);
                var result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateRecord(String tabla, Dictionary<String, object> record,string whereclause)
        {          
            String values = "";
            foreach (KeyValuePair<string, object> entry in record)
            {
                values += $",{entry.Key}=";
                if (entry.Value is string)
                {
                    values += $"'{entry.Value}'";
                }
                else if (entry.Value is int)
                {
                    values += $"{Convert.ToInt32(entry.Value)}";
                }
                else if (entry.Value is double)
                {
                    values += $"{Convert.ToDouble(entry.Value)}";
                }
                else if (entry.Value is bool)
                {
                    values += $"{entry.Value}";
                }
                else if (entry.Value is DateTime val)
                {
                    values += $"'{val.ToString("yyyyMMdd")}'";
                }
                else
                {
                    values += $"'{entry.Value}'";
                }
            }

            try
            {
                var sql = $"update {tabla} set {values.Substring(1)} {whereclause}";
                Console.WriteLine(sql);
                Open();
                var cmd = new NpgsqlCommand(sql, connection);
                var result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

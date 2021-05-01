using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hotel.com.Database
{
    public class Conexion
    {
        public string connectionString = @"Data Source=LAPTOP-KK5T2UNQ\SQLEXPRESS;Initial Catalog=Comprar;Integrated Security=True";

        public DataTable ExecuteAndFillDT(string comando)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = comando;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
        public void ExecuteProcedure(string procedure, List<SqlParameter> param)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = procedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                if(param != null)
                {
                    foreach(SqlParameter item in param)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                int i = cmd.ExecuteNonQuery();

            }
        }
        public DataTable ExecuteProcedureAndFill(string procedure, List<SqlParameter> param)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = procedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnn;

                if (param != null)
                {
                    foreach (SqlParameter item in param)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                int i = cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
        public void Execute(string comando)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = comando;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;

                int i = cmd.ExecuteNonQuery();

            }
        }
    }
}

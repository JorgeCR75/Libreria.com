using Hotel.com.Database;
using Hotel.com.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hotel.com.Servicios
{
    public class ServCompras
    {
        public DataTable ObtenerCompras(Usuario usuario)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@CorreoUsuario", usuario.Email));
            return conexion.ExecuteProcedureAndFill("spObtenerCompras", param);
        }
        public void GuardarCompra(Compra compra)
        {
                Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@IdLibro", compra.IdLibro));
            param.Add(new SqlParameter("@CantiLibros", compra.Libros));
            param.Add(new SqlParameter("@CorreoUsuario", compra.CorreoUsuario));
            param.Add(new SqlParameter("@PrecioLibro", compra.Preciolibro));
            param.Add(new SqlParameter("@Costo", compra.Costo));
            param.Add(new SqlParameter("@DiasEx", compra.DiasEx));
            param.Add(new SqlParameter("@Estado", compra.Estado));
            param.Add(new SqlParameter("@FechaRegistro", compra.FechaRegistro));
            param.Add(new SqlParameter("@FechaExpiracion", compra.FechaExpiracion));
            param.Add(new SqlParameter("@Numerotarjeta", compra.Numerotarjeta));
            param.Add(new SqlParameter("@Codigoseguridad", compra.Codigoseguridad));
            param.Add(new SqlParameter("@Pais", compra.Pais));
            param.Add(new SqlParameter("@Codigopostal", compra.Codigopostal));
            param.Add(new SqlParameter("@Provincia", compra.Provincia));
            param.Add(new SqlParameter("@Direccionentrega", compra.Direccionentrega));


            conexion.ExecuteProcedure("spGuardarCompra", param);
        }

        public void CancelarCompra(int id)
        {

            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Id", id));

            conexion.ExecuteProcedure("spCancelarCompra", param);
        }
        public  Compra ObtenerCompra(int idCompra)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Id", idCompra));

            DataTable dt= conexion.ExecuteProcedureAndFill("spObtenerCompra", param);

            foreach (DataRow row in dt.Rows)
            {
                Compra compra = new Compra
                {
                    IdLibro = Convert.ToInt32(row["Idlibro"]),
                    Id = Convert.ToInt32(row["Id"]),
                    Libros = Convert.ToInt32(row["cantiLibros"]),
                    DiasEx = Convert.ToDecimal(row["DiasEx"]),
                    FechaRegistro = Convert.ToDateTime(row["FechaRegistro"]),
                    FechaExpiracion = Convert.ToDateTime(row["FechaExpiracion"]),
                    Costo = Convert.ToDecimal(row["Costo"]),
                    Numerotarjeta = row["Numerotarjeta"].ToString(),
                    Codigoseguridad = row["Codigoseguridad"].ToString(),
                    Pais = row["Pais"].ToString(),
                    Codigopostal = row["Codigopostal"].ToString(),
                    Provincia = row["Provincia"].ToString(),
                    Direccionentrega = row["Direccionentrega"].ToString(),

                };
                return compra;
            }
            return null;
        }
        public void EditarCompra(Compra compra)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Id", compra.Id));
            param.Add(new SqlParameter("@CantiLibros", compra.Libros));
            param.Add(new SqlParameter("@DiasEx", compra.DiasEx));
            param.Add(new SqlParameter("@FechaRegistro", compra.FechaRegistro));
            param.Add(new SqlParameter("@FechaExpiracion", compra.FechaExpiracion));
            param.Add(new SqlParameter("@Costo", compra.Costo));
            param.Add(new SqlParameter("@Numerotarjeta", compra.Numerotarjeta));
            param.Add(new SqlParameter("@Codigoseguridad", compra.Codigoseguridad));
            param.Add(new SqlParameter("@Pais", compra.Pais));
            param.Add(new SqlParameter("@Codigopostal", compra.Codigopostal));
            param.Add(new SqlParameter("@Provincia", compra.Provincia));
            param.Add(new SqlParameter("@Direccionentrega", compra.Direccionentrega));


            conexion.ExecuteProcedure("spEditarCompra", param);
        }
    }
    }

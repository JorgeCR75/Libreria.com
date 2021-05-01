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
    public class servLibros
    {
        public List<Libro> ObtenerLibros()
        {
            Conexion conexion = new Conexion();

            DataTable dt = conexion.ExecuteProcedureAndFill("spObtenerLibros", null);

            List<Libro> libros = new List<Libro>();

            foreach(DataRow row in dt.Rows)
            {
                Libro libro = new Libro
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre = row["Nombre"].ToString(),
                    Autor = row["Autor"].ToString(),
                    ISBN=row["ISBN"].ToString(),
                    Descripcion=row["Descripcion"].ToString(),
                    Fechapublicado=row["FechaPublicacion"].ToString(),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    RutaFoto=row["RutaFoto"].ToString(),
                };

                libros.Add(libro);
            }
            return libros;
        }
        public List<Libro> ObtenerLibro(int idLibro)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Id", idLibro));
            DataTable dt = conexion.ExecuteProcedureAndFill("spObtenerLibro", param);

            List<Libro> libros = new List<Libro>();

            foreach (DataRow row in dt.Rows)
            {
                Libro libro = new Libro
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre = row["Nombre"].ToString(),
                    Autor = row["Autor"].ToString(),
                    ISBN = row["ISBN"].ToString(),
                    Descripcion = row["Descripcion"].ToString(),
                    Fechapublicado = row["FechaPublicacion"].ToString(),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    RutaFoto = row["RutaFoto"].ToString(),
                };

                libros.Add(libro);
            }
            return libros;
        }
        public List<Libro> BuscarLibro(string Nombre)
        {
            Conexion conexion = new Conexion();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Nombre", Nombre));
            DataTable dt = conexion.ExecuteProcedureAndFill("spBuscarLibro", param);

            List<Libro> libros = new List<Libro>();

            foreach (DataRow row in dt.Rows)
            {
                Libro libro = new Libro
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Nombre = row["Nombre"].ToString(),
                    Autor = row["Autor"].ToString(),
                    ISBN = row["ISBN"].ToString(),
                    Descripcion = row["Descripcion"].ToString(),
                    Fechapublicado = row["FechaPublicacion"].ToString(),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    RutaFoto = row["RutaFoto"].ToString(),
                };

                libros.Add(libro);
            }
            return libros;
        }
    }
    }


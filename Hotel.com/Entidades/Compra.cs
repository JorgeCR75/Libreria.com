using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.com.Entidades
{
    public class Compra
    {
        public int Id { get; set; }
        public int IdLibro { get; set; }
        public int Libros { get; set; }
        public decimal DiasEx { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public decimal Costo  { get; set; }
        public decimal Preciolibro { get; set; }
        public  string Estado { get; set; }
        public string CorreoUsuario { get; set; }
        public string Numerotarjeta { get; set; }
        public string Codigoseguridad { get; set; }
        public string Pais { get; set; }
        public string Codigopostal { get; set; }
        public string Provincia { get; set; }
        public string Direccionentrega { get; set; }
    }
}
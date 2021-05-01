using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.com.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
        public string Autor { get; set; }

        public string ISBN { get; set; }
        public string Fechapublicado { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string RutaFoto { get; set; }
    }
}
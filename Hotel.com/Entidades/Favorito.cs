using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.com.Entidades
{
    public class Favorito
    {
        public int Id { get; set; }
        public string CorreoUsuario { get; set; }
        public int IdLibro { get; set; }
    }
}
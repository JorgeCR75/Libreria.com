using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.com.Entidades
{
    public class ObFavorito
    {
        public int IdFav { get; set; }
        public int Id { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public DateTime Fechapublicacion { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string RutaFoto { get; set; }
    }
}
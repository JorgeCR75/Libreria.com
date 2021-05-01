using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.com.Entidades
{
    public class Usuario
    {
        public string Kind { get; set; }
        public string LocalId { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string IdToken { get; set; }
        public string Registered { get; set; }
        public string RefreshToken { get; set; }
    }
}
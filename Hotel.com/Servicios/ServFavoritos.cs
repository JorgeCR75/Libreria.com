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
    public class ServFavoritos
    {
        public void GuardarFavoritos(Favorito favorito)
        {
            Conexion conexion = new Conexion();

            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("IdLibro", favorito.IdLibro));
            param.Add(new SqlParameter("CorreoUsuario", favorito.CorreoUsuario));

            conexion.ExecuteProcedure("spGuardarFavoritos", param);
        }


        public DataTable ObtenerFavoritos(Usuario usuario)
        {
            Conexion conexion = new Conexion();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("CorreoUsuario", usuario.Email));

            return conexion.ExecuteProcedureAndFill("spObtenerFavoritos", param);
        }
        public void EliminarFavoritos(int id)
        {

            Conexion conexion = new Conexion();

            conexion.Execute("DELETE FROM [dbo].[Favoritos] WHERE Id = " +id);
        }
        public bool ConsultarFavoritos(Usuario usuario, int IdLibro)
        {
            Conexion conexion = new Conexion();
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("IdLibro", IdLibro));
            param.Add(new SqlParameter("CorreoUsuario", usuario.Email));

            DataTable consulta = conexion.ExecuteProcedureAndFill("spFavoritosEx", param);

            List<IdFavoritosEx> idFavoritosex = new List<IdFavoritosEx>();

            foreach (DataRow row in consulta.Rows)
            {
                IdFavoritosEx idFavoritosex2 = new IdFavoritosEx
                {
                    Id = Convert.ToInt32(row["Id"]),
                    IdLibro = Convert.ToInt32(row["IdLibro"])
                };
                idFavoritosex.Add(idFavoritosex2);

            }
            if (idFavoritosex.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

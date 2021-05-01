using Hotel.com.Entidades;
using Hotel.com.Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel.com
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];

            if (usuario == null)
            {
                Response.Redirect("login.aspx");
            }
             cargarFavoritos(usuario);
        }

        protected void btnEliminarFav_Click(object sender, EventArgs e)
        {
            try
            {
                ServFavoritos serviciosfavoritos = new ServFavoritos();
                Usuario usuario = (Usuario)Session["usuario"];
                

                int id = Convert.ToInt16(Page.Request.Form[txtcodigo.UniqueID]);
                serviciosfavoritos.EliminarFavoritos(id);
                cargarFavoritos(usuario);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Ocurrió un error al intentar eliminar de favoritos');", true);
            }

        }

        public void cargarFavoritos(Usuario usuario)
        {
            ServFavoritos  serviciosfav = new ServFavoritos();

            DataTable ds = serviciosfav.ObtenerFavoritos(usuario);

            if (ds.Rows.Count > 0)
            {
                repFavoritos.DataSource = serviciosfav.ObtenerFavoritos(usuario);
                repFavoritos.DataBind();
            }
            else
            {
                repFavoritos.Visible = false;
            }
        }
    }
    }
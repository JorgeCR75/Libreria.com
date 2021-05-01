using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using Hotel.com.Entidades;
using Hotel.com.Servicios;

namespace Hotel.com
{
    public partial class destinos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];

            if (usuario == null)
            {
                Response.Redirect("login.aspx");
            }

            servLibros serviciosLibros = new servLibros();
            repLibros.DataSource = serviciosLibros.ObtenerLibros();
            repLibros.DataBind();
        }

        protected void btnbuscador_Click(object sender, EventArgs e)
        {
            servLibros servicioLibros = new servLibros();
            List<Libro> libroEncontrado = servicioLibros.BuscarLibro(txtbuscador.Value);
            repLibros.DataSource = libroEncontrado;
            repLibros.DataBind();
        }

        protected void btnAgregarFav_Click(object sender, EventArgs e)
        {
            try
            {
                ServFavoritos servicioFavoritos = new ServFavoritos();
                Usuario usuario = (Usuario)Session["usuario"];
                int id = Convert.ToInt16(Page.Request.Form[txtcodigo.UniqueID]);
                Favorito favorito = new Favorito()
                {
                    Id = 1,
                    IdLibro = id,
                    CorreoUsuario = usuario.Email
                };

                if (servicioFavoritos.ConsultarFavoritos(usuario,favorito.IdLibro)==false) {
                    servicioFavoritos.GuardarFavoritos(favorito);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Se agrego correctamente a Favoritos');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('El libro ya esta en favoritos');", true);
                }
                    
            }
            catch(Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Ocurrio un error al agregar a Favoritos');", true);
            }
        }

    }
}


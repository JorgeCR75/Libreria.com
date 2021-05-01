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
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];

            if (usuario == null)
            {
                Response.Redirect("login.aspx");
            }

            CargarCompras(usuario);
        }
        public void CargarCompras(Usuario usuario)
        {
            ServCompras serviciosCompras = new ServCompras();

            DataTable ds = serviciosCompras.ObtenerCompras(usuario);

            if (ds.Rows.Count > 0)
            {
                repCompras.DataSource = serviciosCompras.ObtenerCompras(usuario);
                repCompras.DataBind();
            }
            else
            {
                repCompras.Visible = false;
                imgNoInfo.Visible = true;
            }
           
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {

            Usuario usuario = (Usuario)Session["usuario"];

            int idn = Convert.ToInt16(Page.Request.Form[txtCodigoCompra.UniqueID]);

            ServCompras serviciosCompras = new ServCompras();

            serviciosCompras.CancelarCompra(idn);

            CargarCompras(usuario);
        }
    }
}
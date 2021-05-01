using Hotel.com.Entidades;
using Hotel.com.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel.com
{
    public partial class reservarLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario usuario = (Usuario)Session["usuario"];

                if (usuario == null)
                {
                    Response.Redirect("login.aspx");
                }
                servLibros serviciosLibros = new servLibros();
                int idLibro = Convert.ToInt32(Request.QueryString["idLibro"]);
                int idCompra = Convert.ToInt32(Request.QueryString["idCompra"]);
                List<Libro> LibroEncontrado = serviciosLibros.ObtenerLibro(idLibro);

                if (LibroEncontrado != null)
                {
                    repLibros.DataSource = LibroEncontrado;
                    repLibros.DataBind();
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No se encontro el libro con el ID " + idLibro;
                }
                if (idCompra != 0)
                {
                    ServCompras servcompra = new ServCompras();
                    Compra compra = servcompra.ObtenerCompra(idCompra);

                    GenerarCalculosCompras(compra.IdLibro,
                                            LibroEncontrado[0].Precio,
                                            Convert.ToDateTime(compra.FechaRegistro),
                                            Convert.ToDateTime(compra.FechaExpiracion),
                                            Convert.ToInt16(compra.Libros),
                                            Convert.ToString(compra.Numerotarjeta),
                                            Convert.ToString(compra.Codigoseguridad),
                                            Convert.ToString(compra.Pais),
                                            Convert.ToString(compra.Codigopostal),
                                            Convert.ToString(compra.Provincia),
                                            Convert.ToString(compra.Direccionentrega));

                    btnComprar.Text = "Actualizar";
                }
                else
                {
                    dateIn.Value = DateTime.Now.ToString("yyyy-MM-dd");
                    dateOut.Value = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd");



                    GenerarCalculosCompras(idLibro,
                                            LibroEncontrado[0].Precio,
                                            Convert.ToDateTime(dateIn.Value),
                                            Convert.ToDateTime(dateOut.Value),
                                            Convert.ToInt16(ddLibros.SelectedValue),
                                            Convert.ToString(txtNumerodetarjeta.Value),
                                            Convert.ToString(txtCodigoseguridad.Value),
                                            Convert.ToString(txtPais.Value),
                                            Convert.ToString(txtCodigopostal.Value),
                                            Convert.ToString(txtProvincia.Value),
                                            Convert.ToString(txtDireccionentrega.Value));
                    btnComprar.Text = "Comprar";
                }

            }
        }



        protected void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {

                GenerarCalculosDD();
                int idCompra = Convert.ToInt32(Request.QueryString["idCompra"]);

                Compra compra = (Compra)Session["compra"];

                ServCompras serv = new ServCompras();
                
                if (idCompra != 0)
                {

                    serv.EditarCompra(compra);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Compra Actualizada correctamente');", true);
                }
                else
                {
                    serv.GuardarCompra(compra);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Compra generada correctamente');", true);
                }
            }
            catch(Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Error al generar la compra');", true);
            }
            txtNumerodetarjeta.Value = " ";
            txtCodigoseguridad.Value = " ";
            txtPais.Value = " ";
            txtCodigopostal.Value = " ";
            txtProvincia.Value = " ";
            txtDireccionentrega.Value = " ";

        }

        public void GenerarCalculosCompras(int idLibro, decimal precio, DateTime fechaActual, DateTime fechaEx, int CantidadLibros, string numerotarjeta, string codigoseguridad, string pais, string codigopostal, string provincia, string direccionentrega)
        {

            decimal DiasEx = Convert.ToDecimal((fechaEx - fechaActual).TotalDays);
            decimal CantiLibros = CantidadLibros;
            decimal costo = CantidadLibros * precio;
            int idCompra = Convert.ToInt32(Request.QueryString["idCompra"]);

            Usuario usuario = (Usuario)Session["usuario"];

            Compra compra = new Compra()
            {
                Id = idCompra,
                IdLibro = idLibro,
                Libros = CantidadLibros,
                CorreoUsuario = usuario.Email,
                Preciolibro = precio,
                Costo = costo,
                DiasEx = DiasEx,
                Estado = "Activa",
                FechaRegistro = fechaActual,
                FechaExpiracion = fechaEx,
                Numerotarjeta = numerotarjeta,
                Codigoseguridad = codigoseguridad,
                Pais = pais,
                Codigopostal = codigopostal,
                Provincia = provincia,
                Direccionentrega = direccionentrega,
            };

            Session["compra"] = compra;

            dateIn.Value = compra.FechaRegistro.ToString("yyyy-MM-dd");
            dateOut.Value = compra.FechaExpiracion.ToString("yyyy-MM-dd");
            ddLibros.SelectedValue = CantidadLibros.ToString();
            txtDireccionentrega.Value = compra.Numerotarjeta;
            txtCodigoseguridad.Value = compra.Codigoseguridad;
            txtPais.Value = compra.Pais;
            txtCodigopostal.Value = compra.Codigopostal;
            txtProvincia.Value = compra.Provincia;
            txtDireccionentrega.Value = compra.Direccionentrega;
            lblDiasEx.Text = string.Format("{0}", compra.DiasEx);
            lblCantilibros.Text = string.Format("{0} libros", compra.Libros);
            lblPrecio.Text = string.Format("${0}", CantidadLibros * precio);


        }
        protected void IDcantiLibros_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerarCalculosDD();
        }
        public void GenerarCalculosDD()
        {
            Compra compra = (Compra)Session["compra"];
            GenerarCalculosCompras(compra.IdLibro, compra.Preciolibro,
                                   Convert.ToDateTime(dateIn.Value),
                                   Convert.ToDateTime(dateOut.Value),
                                   Convert.ToInt16(ddLibros.SelectedValue),
                                   Convert.ToString(txtNumerodetarjeta.Value),
                                   Convert.ToString(txtCodigoseguridad.Value),
                                   Convert.ToString(txtPais.Value),
                                   Convert.ToString(txtCodigopostal.Value),
                                   Convert.ToString(txtProvincia.Value),
                                   Convert.ToString(txtDireccionentrega.Value));

        }
    }
}

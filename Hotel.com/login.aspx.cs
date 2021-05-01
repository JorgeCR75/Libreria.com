using Hotel.com.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel.com
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = invocacionFirebase("https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=");

            if (usuario != null)
            {
                Session["usuario"] = usuario;
                Response.Redirect("Libros.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Usuario no registrado en el sistema.');", true);
            }
        }



        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = invocacionFirebase("https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=");

                if (!string.IsNullOrEmpty(usuario.Email))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('Usuario registrado correctamente.');", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "mostrarMensaje('No se registro el usuario, intentalo de nuevo');", true);
            }
        }

            public Usuario invocacionFirebase(string Url)
            {
                var email = txtEmail.Value;
                var password = txtPassword.Value;

                var firebaseUrl = Url;
                var apiKey = "AIzaSyA_v6rLNUv8CusYL1XiqgfsQRPgaGtuLqY";

                var request = (HttpWebRequest)WebRequest.Create(firebaseUrl + apiKey);
                var postData = "email=" + email + "&password=" + password;
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                try
                {
                    var response = (HttpWebResponse)request.GetResponse();
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    return Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(responseString);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }

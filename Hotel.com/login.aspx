<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Hotel.com.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/mdb.min.css" rel="stylesheet" />
    <link href="estilosletras.css" rel="stylesheet" />
    <link href="Content/navbar-fixed-left.min.css" rel="stylesheet" />
    <link rel="stylesheet" id="theme_link" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/navbar-fixed-left.min.css" />
    <link rel="stylesheet" href="Content/docs.css" />
    <script src="Scripts/jquery-3.6.0.slim.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>

    <title>Login</title>
</head>
<body style="background-image:url('images/imagen%20fondo.jpg'); width:100%; height:100%">
    <form id="form1" runat="server">
            
            <div>
                <nav class="navbar navbar-expand-md navbar-dark fixed-left" style="background-color:darkorange ">
                    <a class="navbar-brand" href="#">Libreria.com</a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault"
                        aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarsExampleDefault">
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <a class="nav-link" href="login.aspx">Iniciar sesión</a>
                            </li>
                        </ul>
                    </div>
                </nav>
            </div>
                <div>
                      <div class="container" style="margin-left:300px; margin-top:200px">
                <div class="card" style="width: 25rem; border-color:darkorange; background-color:white">
                    <div class="card-header text-black btn text-left" style="font-family:Arial, Helvetica, sans-serif;border-radius:15px 5px;background-color:darkorange; color:white;">Login</div>
                    <div class="card-body">
                        <div class="form-group">
                            <label>Correo:</label>
                            <input runat="server" type="email" class="form-control" id="txtEmail" placeholder="Email" required />
                        </div>
                        <div class="form-group">
                            <label>Contraseña:</label>
                            <input runat="server" type="password" class="form-control" id="txtPassword" placeholder="Password" required />
                        </div>
                    </div>
                    <div class="card-footer">

                        <asp:Button ID="btnRegistrarse" Style="font-family:Arial, Helvetica, sans-serif;border-radius:20px 20px;width:100px;height:30px; float:left; color: white; background-color:darkorange; border:none" runat="server" Text="Registrarse" OnClick="btnRegistrarse_Click" />
                        <asp:Button ID="btnLogin" Style="font-family:Arial, Helvetica, sans-serif;border-radius:20px 20px;width:100px; height:30px; float:right; color:white; background-color:darkorange; border:none" runat="server" Text="Login" OnClick="btnLogin_Click" />

                    </div>

                </div>
            </div>
          
       </div>
        <div id="divModal"></div>
        <script src="Scripts/mensaje.js"></script>
    </form>

</body>
</html>

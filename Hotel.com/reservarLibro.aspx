<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reservarLibro.aspx.cs" Inherits="Hotel.com.reservarLibro" %>

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

    <title>Reservar</title>
    <script type="text/javascript">
        function OnFocusLost(dateIn, dateOut) {
            var DiasEx = document.querySelector("#lblDiasEx");
            var millennium = new Date(dateIn);
            today = new Date(dateOut);
            var one_day = 1000 * 60 * 60 * 24;
            var range = Math.ceil((today.getTime() - millennium.getTime()) / (one_day));

            DiasEx.innerHTML = range;
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: lightgray; width: 100%; height: 800px;">
            <div>
                <div>
                    <nav class="navbar navbar-expand-md navbar-dark fixed-left" style="background-color: darkorange">
                        <a class="navbar-brand" href="#">Libreria.com</a>
                        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault"
                            aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="collapse navbar-collapse" id="navbarsExampleDefault">
                            <ul class="navbar-nav">
                                <li class="nav-item">
                                    <a class="nav-link" href="libros.aspx">Libros</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="Compras.aspx">Mis compras</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="Favoritos.aspx">Favoritos</a>
                                </li>
                                <li class="nav-item dropdown">
                                    <a class="nav-link dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Configuracion</a>
                                    <div class="dropdown-menu">
                                        <a class="dropdown-item" href="login.aspx">Cerrar sesión</a>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </nav>


                    <div class="container">
                        <asp:Label ID="lblMensaje" Visible="False" runat="server" ForeColor="#CC0000"></asp:Label>
                    </div>

                    <div class="container-fluid ml-3" style="margin-top: 0px">
                        <div class="row">

                            <asp:Repeater ID="repLibros" runat="server">

                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="card" style="border-radius:15px 15px;width: 18rem; height: 750px; margin-left: 10px; margin-top: 5px; border-color: darkorange">
                                        <a href="Libros.aspx" class="btn" style="border-radius:20px 20px; float: right; background-color: darkorange; color: white">Regresar</a>
                                        <img style="margin-left: 8px; width: 270px; height: 375px" src="<%# Eval("Rutafoto")%>" class="card-img-top" alt="..." />
                                        <div class="card-body">
                                            <h5 class="card-title"><%# Eval(" Nombre")%></h5>
                                            <p class="card-text"><%# Eval("Descripcion")%></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>
                            <div class="row">
                                <div class="card" style="border-radius:15px 15px;width: 17rem; height: 505px; margin-right: 10px; margin-left: 25px; margin-top: 5px; border-color: darkorange">
                                    <div class="card-header text-black btn text-left" style="border-radius:15px 5px;background-color: darkorange; color: white">
                                        Información para Envío
                                    </div>

                                    <div class="card-body">

                                        <label>Número de tajeta:</label>
                                        <input id="txtNumerodetarjeta" type="password" runat="server" style="width: 100%; height: 35px"></input>
                                        <label>Código de seguridad:</label>
                                        <input id="txtCodigoseguridad" type="password" runat="server" style="width: 100%; height: 35px"></input>
                                        <label>País:</label>
                                        <input id="txtPais" type="text" runat="server" style="width: 100%; height: 35px"></input>
                                        <label>Código Postal:</label>
                                        <input id="txtCodigopostal" type="text" runat="server" style="width: 100%; height: 35px"></input>
                                        <label>Provincia:</label>
                                        <input id="txtProvincia" type="text" runat="server" style="width: 100%; height: 35px"></input>
                                        <label>Dirección de entrega:</label>
                                        <input id="txtDireccionentrega" type="text" runat="server" style="width: 100%; height: 35px" text=" "></input>
                                    </div>

                                </div>


                                <div class="card" style="border-radius:15px 15px;width: 17rem; height: 360px; margin-top: 5px; border-color: darkorange">
                                    <div class="card-header text-black btn text-left" style="border-radius:15px 5px;background-color: darkorange; color: white">
                                        Compre sus libros acá
                                    </div>

                                    <div class="card-body">
                                        <div class="form-group"></div>
                                        <label>Fecha inicial de la Factura:</label>
                                        <input runat="server" style="width: 100%; height: 25px" type="date" class="form-group" id="dateIn" placeholder="fecha actual " required />
                                        <div class="form-group"></div>
                                        <label>Fecha Límite de la Factura:</label>
                                        <input runat="server" style="width: 100%; height: 25px" type="date" class="form-group" id="dateOut" placeholder="fecha vencimiento" onfocusout="OnFocusLost(dateIn.value, dateOut.value)" required />
                                        <label>Cantidad de Libros </label>
                                        <asp:DropDownList ID="ddLibros" AutoPostBack="true" runat="server" Style="width: 100%; height: 35px" OnSelectedIndexChanged="IDcantiLibros_SelectedIndexChanged">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="card" style="border-radius:15px 15px;width: 17rem; height: 300px; margin-left: 10px; margin-top: 5px; border-color: darkorange">
                                    <div class="card-header text-black btn text-left" style="border-radius:15px 5px;background-color: darkorange; color: white">
                                        Detalles de la Compra
                                    </div>
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-6">Días para la expiración:</div>
                                            <div class="col-6">
                                                <asp:Label ID="lblDiasEx" runat="server"> </asp:Label>
                                            </div>
                                            <div class="col-6">Cantidad de Libros:</div>
                                            <div class="col-6">
                                                <asp:Label ID="lblCantilibros" runat="server"> 0 </asp:Label>
                                            </div>
                                            <div class="col-6">Precio:</div>
                                            <div class="col-6">
                                                <asp:Label ID="lblPrecio" runat="server"> $0 </asp:Label>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="p-2">
                                        <asp:Button ID="btnComprar" Style="border-radius:20px 20px;color: white; float: right; background-color: darkorange;" runat="server" Text="Comprar" class="btn" OnClick="btnComprar_Click" />
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div id="divModal"></div>
                        <script src="Scripts/mensaje.js"></script>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>

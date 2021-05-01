﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Hotel.com.Favoritos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/mdb.min.css" rel="stylesheet" />
    <link href="Content/navbar-fixed-left.min.css" rel="stylesheet" />
    <link rel="stylesheet" id="theme_link" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/navbar-fixed-left.min.css" />
    <link rel="stylesheet" href="Content/docs.css" />
    <link href="estilosletras.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.6.0.slim.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <title>Favoritos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-md navbar-dark fixed-left" style="background-color: darkorange;">
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
        </div>
        <div id="divFav" class="row" style="background-color: darkorange; height: 50px;">
            <label id="lblcompras" style="color: white; margin-top: 8px; margin-left: 1200px">
                <h4>Favoritos</h4>
            </label>

        </div>
        <div class="container-fluid ml-3">
            <div class="row">

                <asp:Repeater ID="repFavoritos" runat="server">

                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>

                        <div class="card mb-3" style="border-radius:10px 22px;width: 460px; height: 300px; margin-top: 10px; margin-left: 8px; background-color: white; border-color: darkorange">
                            <div class="row g-0">
                                <div class="col-md-4">
                                    <img style="width: 200px; height: 280px; margin-left: 8px; margin-top: 8px" src="<%# Eval("Rutafoto")%>" alt="..." />
                                </div>
                                <div class="col-md-8">
                                    <div class="card-body" style="margin: 0px 0px 50px 40px">
                                        <h4 class="card-title"><%# Eval(" Nombre")%></h4>
                                        <h6>
                                            <p class="card-text" style="margin-top: 40px">
                                                Autor:
                                                     <%#Eval(" Autor") %>
                                            </p>

                                            <p class="card-text" style="margin-top: 20px">
                                                Código: 
                                                <%#Eval(" ISBN")%>
                                            </p>

                                            <p class="card-text" style="margin-top: 20px">
                                                Fecha de publicación: <%#Eval(" Fechapublicacion") %>
                                            </p>
                                        </h6>
                                        <div class="row">
                                            <a class="btn btn-danger text-white" style="  border-radius:20px 20px; margin-top: 55px; margin-left: 15px" data-toggle="modal" data-target="#EliminarFavoritos" onclick="cargarLibro('<%# Eval("Id")%>')">Eliminar Fav</a>
                                            <a href="reservarLibro.aspx?idLibro=<%#Eval("Id")%>" class="btn" style="background-color: darkorange; margin-top: 55px; margin-left: 160px; position: absolute; color: white;  border-radius:20px 20px">$<%# Eval("Precio")%></a>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="modal fade" id="EliminarFavoritos" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header" style="background-color: darkorange">
                        <h5 class="modal-title" id="exampleModalLabel">Eliminar de Favoritos:<asp:TextBox ID="txtcodigo" runat="server" ReadOnly="true"></asp:TextBox></h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        Esta seguro que desea eliminar de favoritos?
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnEliminarFav" runat="server" Style="border-radius:20px 20px; float: right; background-color: darkorange" class="btn" Text="Aceptar" OnClick="btnEliminarFav_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="Scripts/app.js"></script>
</body>
</html>

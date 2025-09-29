<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ElegiPremio.aspx.cs" Inherits="TPWeb_equipo_6A.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row row-cols-1 row-cols-md-3">

<% foreach (var art in ListaArticulo) {
       var img = ListaImagenes.Find(i => i.IdArticulo == art.Id);
%>

<div class="col">
    <div class="card h-100" style="width: 18rem;">
        <img src="<%: img != null ? img.ImagenUrl : "imagenes/no-disponible.png" %>" 
             class="card-img-top" alt="imagen articulo">
        <div class="card-body">
            <h5 class="card-title"><%: art.Nombre %></h5>
            <p class="card-text"><%: art.Descripcion %></p>
            <a href="#" class="btn btn-primary">Quiero Este!</a>
        </div>
    </div>
</div>

<% } %>
    </div>


</asp:Content>

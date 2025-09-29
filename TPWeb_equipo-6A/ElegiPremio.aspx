<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ElegiPremio.aspx.cs" Inherits="TPWeb_equipo_6A.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row row-cols-1 row-cols-md-3">

        <% foreach (var art in ListaArticulo)
            {
                var img = ListaImagenes.FindAll(i => i.IdArticulo == art.Id);
        %>

        <div class="col">
            <div class="card h-100" style="width: 18rem;">

                <div id="carousel-<%: art.Id %>" class="carousel slide">
                    <div class="carousel-inner">
                        <% for (int i = 0; i < img.Count; i++)
                            { %>
                        <div class="carousel-item <%: i == 0 ? "active" : "" %>">
                            <img src="<%: img[i].ImagenUrl %>"
                                class="d-block w-100"
                                style="height: 250px;"
                                alt="Imagen de <%: art.Nombre %>">
                        </div>
                        <% } %>
                    </div>

                    <button class="carousel-control-prev" type="button" data-bs-target="#carousel-<%: art.Id %>" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Anterior</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carousel-<%: art.Id %>" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Siguiente</span>
                    </button>
                </div>

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

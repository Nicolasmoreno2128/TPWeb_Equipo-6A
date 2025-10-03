<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="RegistroExitoso.aspx.cs" Inherits="TPWeb_equipo_6A.Registro_Exitoso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container d-flex flex-column justify-content-start align-items-center min-vh-100 pt-5">
        <div class="text-center">
            <asp:Label ID="lblExitoso" CssClass="form-label d-block mb-3" runat="server" Text="">Se ha Registrado Exitosamente</asp:Label>
            <a href="Default.aspx" class="btn btn-dark">Volver</a>
        </div>
    </div>
</asp:Content>

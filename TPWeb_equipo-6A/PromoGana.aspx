<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PromoGana.aspx.cs" Inherits="TPWeb_equipo_6A.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex flex-column justify-content-start align-items-center min-vh-100 pt-5">
    <div class="text-center">
        <label for="txtCodigoVoucher" class="form-label">Ingresa el codigo de tu voucher:</label>        
        <asp:TextBox ID="txtCodigoVoucher" CssClass="form-control mb-3" runat="server" required/>       
        <asp:Button Text="Siguiente" ID="btnSiguiente" OnClick="btnSiguiente_Click" CssClass="btn btn-dark" runat="server" />
    </div>
</div>


    
</asp:Content>

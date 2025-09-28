<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PromoGana.aspx.cs" Inherits="TPWeb_equipo_6A.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center mt-5">
        <div class="row align-items-start">
            <div class="col-3">
            </div>
            <div class="col">

                <div class="mb-3">
                    <label for="txtCodigoVoucher" class="form-label">Ingresa el codigo de tu voucher:</label>                    
                    <asp:TextBox ID="txtCodigoVoucher" CssClass="form-control" runat="server" />
                </div>
                <asp:Button Text="Siguiente" ID="btnSiguiente" OnClick="btnSiguiente_Click"  CssClass="btn btn-primary" runat="server" />
            </div>
            <div class="col-3">
            </div>
        </div>
    </div>
</asp:Content>

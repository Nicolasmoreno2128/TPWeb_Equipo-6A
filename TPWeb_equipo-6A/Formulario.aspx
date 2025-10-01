<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="TPWeb_equipo_6A.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-center mt-2">Ingresa tus datos</h1>
    <div class="container mt-3" style="max-width: 1000px;">
        <div class="row g-3">
            <div class="col-sm-3">
                <label for="txbDNI" class="form-label">DNI</label>
                <asp:TextBox runat="server" ID="txbDNI" CssClass="form-control" placeholder="DNI" OnTextChanged="txbDNI_TextChanged" AutoPostBack="true" />
            </div>
            <div class="row g-3">
                <div class="col">
                    <label for="txbNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txbNombre" CssClass="form-control" placeholder="Nombre" />
                </div>
                <div class="col">
                    <label for="txbApellido" class="form-label">Apellido</label>
                    <asp:TextBox runat="server" ID="txbApellido" CssClass="form-control" placeholder="Apellido" />
                </div>
                <div class="col">
                    <label for="txbEmail" class="form-label">Email</label>
                    <asp:TextBox type="email" runat="server" ID="TxbEmail" CssClass="form-control" placeholder="Email" />
                </div>
            </div>
            <div class="row g-3">
                <div class="col md-6">
                    <label for="txbDireccion" class="form-label">Direccion</label>
                    <asp:TextBox runat="server" ID="txbDireccion" CssClass="form-control" placeholder="Direccion" />
                </div>
                <div class="col md-3">
                    <label for="txbCiudad" class="form-label">Ciudad</label>
                    <asp:TextBox runat="server" ID="txbCiudad" CssClass="form-control" placeholder="Ciudad" />
                </div>
                <div class="col md-3">
                    <label for="txbCodPostal" class="form-label">Codigo Postal</label>
                    <asp:TextBox runat="server" ID="txbCodPostal" CssClass="form-control" placeholder="CP" />
                </div>
            </div>
            <div class="form-check mt-3">
                <asp:CheckBox ID="chbAcepto" CssClass="form-check-input" runat="server" Text="" AutoPostBack="true" OnCheckedChanged="chbAcepto_CheckedChanged" />
                <label class="form-check-label" for="chbAcepto">
                    Acepto los terminos y condiciones.
                </label>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-auto">
                <asp:Button Text="Participar!" ID="btnParticipar" CssClass="btn btn-dark mt-3" runat="server" OnClick="btnParticipar_Click" />
            </div>
            <div class="col align-self-center">
                <asp:Label ID="lblError" runat="server" CssClass="text-danger mt-2 d-block"></asp:Label>
            </div>
        </div>

    </div>



</asp:Content>

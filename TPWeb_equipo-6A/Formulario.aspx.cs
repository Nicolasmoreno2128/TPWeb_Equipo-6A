using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_equipo_6A
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string codigoV { get; set; }

        //protected void btnParticipar_Click(object sender, EventArgs e)
        //{
        //    lblError.Text = "";   // limpia el label

        //    try
        //    {
        //        if (!Page.IsValid) { lblError.Text = "Revisá los datos marcados."; return; }
        //        if (!chbAcepto.Checked) { lblError.Text = "Debés aceptar las bases."; return; }

        //        // --- 1) Variables de sesión / query ---
        //        var codigoVoucher = (Session["VoucherCodigo"] as string) ?? (Session["codigo"] as string);
        //        if (string.IsNullOrWhiteSpace(codigoVoucher)) { lblError.Text = "Sesión de voucher expirada."; return; }

        //        int articuloId;
        //        if (Session["ArticuloId"] is int sesId) articuloId = sesId;
        //        else if (!int.TryParse(Request.QueryString["id"], out articuloId))
        //        { lblError.Text = "No se pudo determinar el premio."; return; }

        //        if (!int.TryParse(txbDNI.Text.Trim(), out var documento))
        //        { lblError.Text = "DNI inválido."; return; }

        //        // --- 2) Alta/obtención de cliente ---
        //        int idCliente = 0;
        //        var cliNeg = new ClienteNegocio();

        //        try
        //        {
        //            var existente = cliNeg.buscarPorDni(documento); // si no lo tenés, usá ObtenerIdPorDocumento()
        //            if (existente != null)
        //            {
        //                idCliente = existente.Id;
        //            }
        //            else
        //            {
        //                var cliente = new Cliente
        //                {
        //                    Documento = documento,
        //                    Nombre = (txbNombre.Text ?? "").Trim(),
        //                    Apellido = (txbApellido.Text ?? "").Trim(),
        //                    Email = (TxbEmail.Text ?? "").Trim(),
        //                    Direccion = (txbDireccion.Text ?? "").Trim(),
        //                    Ciudad = (txbCiudad.Text ?? "").Trim(),
        //                    CP = int.TryParse(txbCodPostal.Text.Trim(), out var cp) ? cp : 0
        //                };

        //                cliNeg.agregar(cliente); // <-- si falla acá, abajo lo vas a ver
        //                                         // recuperar Id (si tu agregar no lo devuelve)
        //                var buscado = cliNeg.buscarPorDni(documento);
        //                idCliente = buscado?.Id ?? 0;
        //                if (idCliente == 0) { lblError.Text = "No se pudo obtener el Id del cliente luego del alta."; return; }
        //            }
        //        }
        //        catch (SqlException ex)
        //        {
        //            lblError.Text = $"Error SQL al guardar/leer Cliente: {ex.Message}";
        //            return;
        //        }
        //        catch (Exception ex)
        //        {
        //            lblError.Text = $"Error al guardar/leer Cliente: {ex.Message}";
        //            return;
        //        }

        //        // --- 3) Update del voucher por código ---
        //        try
        //        {
        //            var vNeg = new VoucherNegocio();
        //            vNeg.MarcarCanjePorCodigo(codigoVoucher, idCliente, articuloId);
        //        }
        //        catch (SqlException ex)
        //        {
        //            lblError.Text = $"Error SQL al actualizar Voucher (código={codigoVoucher}, artId={articuloId}, idCliente={idCliente}): {ex.Message}";
        //            return;
        //        }
        //        catch (Exception ex)
        //        {
        //            lblError.Text = $"Error al actualizar Voucher: {ex.Message}";
        //            return;
        //        }

        //        // --- 4) Éxito ---
        //        Session.Remove("ArticuloId");
        //        Response.Redirect("RegistroExitoso.aspx", false);
        //        Context.ApplicationInstance.CompleteRequest();
        //    }
        //    catch (Exception ex)
        //    {
        //        // catch de seguridad (no debería llegar acá)
        //        lblError.Text = $"Error inesperado: {ex.Message}";
        //    }
        //}


        protected void btnParticipar_Click(object sender, EventArgs e)
        {

            try
            {
                if (!Page.IsValid) { lblError.Text = "Revisá los datos marcados."; return; }
                if (!chbAcepto.Checked) { lblError.Text = "Debés aceptar las bases y condiciones."; return; }

                // Voucher desde Session
                var codigoVoucher = (Session["Codigo"] as string) ?? (Session["codigo"] as string);
                if (string.IsNullOrWhiteSpace(codigoVoucher)) { Response.Redirect("PromoGana.aspx"); return; }

                // Artículo desde Session o QueryString
                int articuloId;
                if (Session["ArticuloId"] is int sesId) articuloId = sesId;
                else if (!int.TryParse(Request.QueryString["id"], out articuloId))
                { lblError.Text = "No se pudo determinar el premio seleccionado."; return; }

                // DNI
                if (!int.TryParse(txbDNI.Text.Trim(), out var documento))
                { lblError.Text = "DNI inválido."; return; }

                // ¿Existe el cliente?
                var cliNeg = new ClienteNegocio();
                int idCliente;
                var existente = cliNeg.buscarPorDni(documento);   // si ya lo tenés
                if (existente != null)
                {
                    idCliente = existente.Id;
                }
                else
                {
                    // Crear cliente
                    var cliente = new Cliente
                    {
                        Documento = documento,
                        Nombre = (txbNombre.Text ?? "").Trim(),
                        Apellido = (txbApellido.Text ?? "").Trim(),
                        Email = (TxbEmail.Text ?? "").Trim(),
                        Direccion = (txbDireccion.Text ?? "").Trim(),
                        Ciudad = (txbCiudad.Text ?? "").Trim(),
                        CP = int.TryParse(txbCodPostal.Text.Trim(), out var cp) ? cp : 0
                    };

                    cliNeg.agregar(cliente);

                    // Recuperar Id (no lo devuelve el agregar)
                    // Opción A: si tenés buscarPorDni:
                    idCliente = cliNeg.buscarPorDni(documento)?.Id ?? 0;

                    // Opción B (si preferís el helper):
                    // idCliente = cliNeg.ObtenerIdPorDocumento(documento);

                    if (idCliente == 0) { lblError.Text = "No se pudo obtener el Id de cliente."; return; }
                }

                // Marcar el canje del voucher
                var vNeg = new VoucherNegocio();
                vNeg.MarcarCanjePorCodigo(codigoVoucher, idCliente, articuloId);

                // Limpieza + navegar
                Session.Remove("ArticuloId");
                Response.Redirect("RegistroExitoso.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                lblError.Text = "Ocurrió un error al registrar. Intentalo nuevamente.";
                // TODO: loggear si querés
            }

        }
        protected void txbDNI_TextChanged(object sender, EventArgs e)
        {
            int dni;
            if (int.TryParse(txbDNI.Text, out dni))
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente cliente = negocio.buscarPorDni(dni);

                if (cliente != null)
                {
                    txbNombre.Text = cliente.Nombre;
                    txbApellido.Text = cliente.Apellido;
                    TxbEmail.Text = cliente.Email;
                    txbDireccion.Text = cliente.Direccion;
                    txbCiudad.Text = cliente.Ciudad;
                    txbCodPostal.Text = cliente.CP.ToString();
                }
                else
                {
                    txbNombre.Text = "";
                    txbApellido.Text = "";
                    TxbEmail.Text = "";
                    txbDireccion.Text = "";
                    txbCiudad.Text = "";
                    txbCodPostal.Text = "";
                }
            }
        }
        protected void chbAcepto_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAcepto.Checked) //Borra el error del check cuando se tilda
                lblError.Text = string.Empty; 
        }
    }
}
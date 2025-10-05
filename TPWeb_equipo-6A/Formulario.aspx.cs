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
        protected void btnParticipar_Click(object sender, EventArgs e)
        {
                EmailService email = new EmailService();
            
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
                    email.armarCorreo(TxbEmail.Text);
                    email.enviarEmail();

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
            }
        }        
        protected void txbDNI_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txbDNI.Text, out int dni))
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Cliente cliente = negocio.buscarPorDni(dni);

                if (cliente != null)
                {
                    // Si existe, se completan los datos del cliente
                    txbNombre.Text = cliente.Nombre;
                    txbApellido.Text = cliente.Apellido;
                    TxbEmail.Text = cliente.Email;
                    txbDireccion.Text = cliente.Direccion;
                    txbCiudad.Text = cliente.Ciudad;
                    txbCodPostal.Text = cliente.CP.ToString();

                    // Los campos pasan a solo lectura
                    txbNombre.Enabled = false;
                    txbApellido.Enabled = false;
                    TxbEmail.Enabled = false;
                    txbDireccion.Enabled = false;
                    txbCiudad.Enabled = false;
                    txbCodPostal.Enabled = false;

                    lblError.Text = "Cliente encontrado. Los datos no pueden modificarse.";
                }
                else
                {
                    // Si el cliente no existe, se limpian los datos y se habilitan para editar
                    txbNombre.Text = "";
                    txbApellido.Text = "";
                    TxbEmail.Text = "";
                    txbDireccion.Text = "";
                    txbCiudad.Text = "";
                    txbCodPostal.Text = "";

                    txbNombre.Enabled = true;
                    txbApellido.Enabled = true;
                    TxbEmail.Enabled = true;
                    txbDireccion.Enabled = true;
                    txbCiudad.Enabled = true;
                    txbCodPostal.Enabled = true;

                    lblError.Text = string.Empty;
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
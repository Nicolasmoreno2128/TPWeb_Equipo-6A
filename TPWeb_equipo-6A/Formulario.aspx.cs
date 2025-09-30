using dominio;
using negocio;
using System;
using System.Collections.Generic;
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

        protected void btnParticipar_Click(object sender, EventArgs e)
        {

            Cliente Client = new Cliente();
            ClienteNegocio negocio = new ClienteNegocio();
            try
            {

                Client.Documento = int.Parse(txbDNI.Text);
                Client.Nombre = txbNombre.Text;
                Client.Apellido = txbApellido.Text;
                Client.Email = TxbEmail.Text;
                Client.Direccion = txbDireccion.Text;
                Client.Ciudad = txbCiudad.Text;
                Client.CP = int.Parse(txbCodPostal.Text);

                negocio.agregar(Client);

            }
            catch (Exception ex)
            {

                throw ex;
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

    }
}
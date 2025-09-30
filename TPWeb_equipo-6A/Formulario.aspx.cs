using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

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
                Client.Nombre=txbNombre.Text;
                Client.Apellido=txbApellido.Text;
                Client.Email=TxbEmail.Text;
                Client.Direccion=txbDireccion.Text;
                Client.Ciudad=txbCiudad.Text;
                Client.CP = int.Parse(txbCodPostal.Text);

                negocio.agregar(Client);

            }
            catch (Exception ex)
            {

                 throw ex;
            }

        }
    }
    
}
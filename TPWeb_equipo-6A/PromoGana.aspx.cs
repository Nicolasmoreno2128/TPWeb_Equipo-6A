using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_equipo_6A
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string CodigoVoucher = txtCodigoVoucher.Text;// guardo el dato del boton 
            Session.Add("Codigo", CodigoVoucher); // lo guardo en la session para usarlo luego desde otra página
            Response.Redirect("ElegiPremio.aspx"); // voy a la página de selección de premio
        }
    }
}
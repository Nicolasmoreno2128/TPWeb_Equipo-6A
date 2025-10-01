using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_equipo_6A
{
    public partial class VoucherUtilizado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorVaucher.Text = "El voucher ingresado no es válido o ya fue registrado.";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPWeb_equipo_6A
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }       
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string codigoVoucher = txtCodigoVoucher.Text.Trim();

            VoucherNegocio negocio = new VoucherNegocio();
            List<Voucher> lista = negocio.Listar();

            Voucher encontrado = lista.FirstOrDefault(v => v.CodigoVoucher == codigoVoucher);

            if (encontrado != null) // Si no se usó el vouvher, permite cargar
            {                
                if (!encontrado.IdCliente.HasValue)
                {
                    string codigo = txtCodigoVoucher.ToString();
                    Session["Codigo"] = encontrado.CodigoVoucher;
                    Response.Redirect("ElegiPremio.aspx");

                    Session.Add("CodigoVoucher", codigo);

                }
                else // El voucher ya fue usado
                {
                    Response.Redirect("VoucherUtilizado.aspx");
                }
            }
            else
            {
                Response.Redirect("VoucherUtilizado.aspx");
            }
        }

    }
}
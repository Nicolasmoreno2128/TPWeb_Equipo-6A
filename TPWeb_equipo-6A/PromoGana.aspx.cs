using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
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
        /*protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string CodigoVoucher = txtCodigoVoucher.Text;// guardo el dato del boton 
            List<Voucher>listaVoucher = new List<Voucher>();
            foreach (var item in listaVoucher)
            {
                if (CodigoVoucher == item.CodigoVoucher)
                {
                    Session.Add("Codigo", CodigoVoucher); // lo guardo en la session para usarlo luego desde otra página
                    Response.Redirect("ElegiPremio.aspx"); // voy a la página de selección de premio
                    return;
                }
                else
                {
                    lblErrorVaucher.Text = item.CodigoVoucher + " No es un número válido";
                }
            }
            
            
            
        }*/

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string codigoVoucher = txtCodigoVoucher.Text.Trim();

            VoucherNegocio negocio = new VoucherNegocio();
            List<Voucher> lista = negocio.Listar();

            // Busco si el voucher existe en la lista que traje de la BD
            Voucher encontrado = lista.FirstOrDefault(v => v.CodigoVoucher == codigoVoucher);

            if (encontrado != null)
            {
                // Lo guardo en la sesión (podés guardar solo el código o el objeto completo)
                Session["Codigo"] = encontrado.CodigoVoucher;
                // O incluso: Session["Voucher"] = encontrado;

                Response.Redirect("ElegiPremio.aspx");
            }
            else
            {
                lblErrorVaucher.Text = "El código ingresado no es válido.";
            }
        }
    }
}
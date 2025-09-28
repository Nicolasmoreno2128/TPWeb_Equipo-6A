using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    internal class VoucherNegocio
    {
      public List<Voucher> Listar()
        {
          List<Voucher> lista = new List<Voucher>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT CodigoVoucher,IdCliente, FechaCanje, IdArticulo FROM Vouchers");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Voucher aux = new Voucher();
                    aux.CodigoVoucher = (string)datos.Lector["CodigoVoucher"];
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}

using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VoucherNegocio
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
                    aux.CodigoVoucher = datos.Lector["CodigoVoucher"].ToString();
                    aux.IdCliente = datos.Lector["IdCliente"] != DBNull.Value ? Convert.ToInt32(datos.Lector["IdCliente"]) : 0;
                    aux.FechaCanje = datos.Lector["FechaCanje"] != DBNull.Value ? Convert.ToDateTime(datos.Lector["FechaCanje"]) : DateTime.MinValue;
                    aux.IdArticulo = datos.Lector["IdArticulo"] != DBNull.Value ? Convert.ToInt32(datos.Lector["IdArticulo"]) : 0;
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

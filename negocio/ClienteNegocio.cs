using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ClienteNegocio
    {
        public void agregar(Cliente nuevo)
        {            
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO CLIENTES (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) VALUES (@Documento,@Nombre,@Apellido,@Email,@Direccion,@Ciudad,@CP)");
                datos.setearParametro("@Documento", nuevo.Documento);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Direccion", nuevo.Direccion);
                datos.setearParametro("@Ciudad", nuevo.Ciudad);
                datos.setearParametro("@CP", nuevo.CP);
                datos.ejecutarAccion();
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

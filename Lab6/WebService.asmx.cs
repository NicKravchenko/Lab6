using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using log4net;

namespace Lab6
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://intec.edu.do/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        [WebMethod]
        public string HelloWorld()
        {
            log.Debug("Hello world was called");
            return "Hello World";
        }

        [WebMethod]
        public Respuesta RegistrarCaso(Caso caso)
        {
            Respuesta respuesta = new Respuesta(); 
            try
            {
                MyInternalDBEntities entities = new MyInternalDBEntities();
                log.Debug("Reg de cliente fue llamado");

                //TODO: Guargar el cliente en la base de datos
                entities.InsertCaso(caso.TipoDeCrimen, caso.Detalles, caso.Documento,
                    caso.Nombres, caso.Apellidos, caso.Direccion, caso.Celular);

                respuesta = new Respuesta() { Codigo = 1, Mensaje = "Transaccion procesada", Tipo = 1 };

                log.Debug($"{caso.Apellidos} {caso.Nombres} {caso.TipoDeCrimen} era registrado");
                return respuesta;


            }
            catch (Exception ex)
            {
                respuesta = new Respuesta() { Codigo = 0, Mensaje = "Transaccion no procesada", Tipo = 0 };

                log.Error(ex);
            }
            respuesta = new Respuesta() { Codigo = 0, Mensaje = "Transaccion no procesada", Tipo = 0 };

            return respuesta;
        }
    }
}

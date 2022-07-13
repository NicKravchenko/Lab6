using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static WSRef.WebServiceSoapClient soapClient = new WSRef.WebServiceSoapClient();


        static void Main(string[] args)
        {
            WSRef.Respuesta respuesta = new WSRef.Respuesta();
            try
            {
                log.Debug("Start loging");
                WSRef.Caso caso = ReturnCaso();
                respuesta = soapClient.RegistrarCaso(caso);

                if (respuesta.Codigo == 1)
                    log.Debug("Caso registrado");
                else
                    log.Debug("Caso no registrado");
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }                   
        }

        private static WSRef.Caso ReturnCaso()
        {
            string TipoDeCrimen = "Robo de chocolate";
            string Detalles = "Hershey blanco";
            string Documento = "23553";
            string Nombres = "Nikita";
            string Apellidos = "Rravchenko";
            string Direccion = "La casa =)";
            string Celular = "4342222343";

            WSRef.Caso caso = new WSRef.Caso()
            {
                TipoDeCrimen =  TipoDeCrimen,
                Detalles =      Detalles,
                Documento =     Documento,
                Nombres =       Nombres ,
                Apellidos =     Apellidos ,
                Direccion =     Direccion ,
                Celular = Celular
            };
            return caso;
        }
    }
}

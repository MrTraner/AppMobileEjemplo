using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppMobileEjemplo.Clases;
using Newtonsoft.Json;

namespace AppMobileEjemplo.Servicio
{
    class ConexionServicio
    {
        //Método del servicio web para iniciar sesión (para validar correo y contraseña)
        public async Task<List<Credencial>> Login(string correo, string contraseña)
        {
            List<Credencial> Credenciales;

            //url del servicio en localhost
            //var URLWebAPI = "http://192.168.1.1/serviciowebphp/autenticacion.php";
            //url del servicio en producción (internet)
            var URLWebAPI = "https://juanmauricioochoa.000webhostapp.com/serviciomobile/autenticacion.php";

            using (var Client = new System.Net.Http.HttpClient())
            {
                //el tipo de contenido a enviar en la peticion http
                string ContentType = "application/x-www-form-urlencoded";
                //los parametros que ocupa el metodo del servicio
                string parametros = String.Format("correo={0}&contraseña={1}", correo, contraseña);
                //enviar la información por el metodo post de http
                System.Net.Http.HttpResponseMessage res = await Client.PostAsync(URLWebAPI, new System.Net.Http.StringContent(parametros, Encoding.UTF8, ContentType));
                //leer el resultado json
                var JSON = await res.Content.ReadAsStringAsync();
                //System.Diagnostics.Debug.WriteLine("Correo: " + correo);
                //System.Diagnostics.Debug.WriteLine("Contraseña: " + contraseña);
                //System.Diagnostics.Debug.WriteLine(JSON);
                //validar si el objecto json no esta vacio
                if(JSON != "[]")
                {
                    //convertir el resultado del servicio (json) a un objeto de c#
                    Credenciales = JsonConvert.DeserializeObject<List<Credencial>>(JSON);
                }
                else
                {
                    //al no encontrar resultado del servicio se crea un objeto vacio para hacer la validación
                    Credencial credencial = new Credencial { Id = "0", Correo = "null", Password = "null", Rol = "null" };
                    Credenciales = new List<Credencial> { credencial };
                }
            }

            return Credenciales;
        }
    }
}

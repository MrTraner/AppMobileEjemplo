using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Xamarin.Forms.Internals;

namespace AppMobileEjemplo.Clases
{
    //Estructura de la tabla en base de datos (la que usa el servicio web)
    [Preserve(AllMembers = true)]
    public class Credencial
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Correo")]
        public string Correo { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Rol")]
        public string Rol { get; set; }
    }
}

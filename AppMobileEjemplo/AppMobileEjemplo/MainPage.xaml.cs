using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppMobileEjemplo.Clases;
using AppMobileEjemplo.Servicio;

namespace AppMobileEjemplo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            //agregar un titulo a la pantalla
            Title = "AppMobileEjemplo";

            //agregar el evento click al boton
            btnIniciar.Clicked += BtnIniciar_Clicked;
		}

        private async void BtnIniciar_Clicked(object sender, EventArgs e)
        {
            //obtener los datos capturados en las cajas de texto
            string correo = txtCorreo.Text;
            string contraseña = txtContraseña.Text;

            //validar si el campo de correo esta vacio
            if(string.IsNullOrEmpty(correo))
            {
                await DisplayAlert("Error", "No se ha indicado un correo", "Cerrar");
            }
            else if(string.IsNullOrEmpty(contraseña))
            {
                //validar si el campo de contraseña esta vacio
                await DisplayAlert("Error", "No se ha indicado una contraseña", "Cerrar");
            }
            else
            {
                //enviar los datos al metodo del servicio y guardarlo en una variable
                var credenciales = await (new ConexionServicio()).Login(correo, contraseña);
                //validar que el id del resultado sea diferente a 0 (el objeto creado al no obtener respuesta del servicio)
                if(Convert.ToInt32(credenciales[0].Id) != 0)
                {
                    //entrar a la pagina de inicio enviando como parametro el objeto de respuesta
                    await Navigation.PushAsync(new InicioPage(credenciales[0]));
                    //eliminar esta pagina para no regresar hasta cerrar sesion
                    Navigation.RemovePage(this);
                }
                else
                {
                    //al obtener el objeto creado por no tener respuesta del servicio (revisar linea 36-46 de ConexionServicio.cs)
                    await DisplayAlert("Datos no válidos", "Revisar su usuario y contraseña", "Volver a intentar");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppMobileEjemplo.Clases;

namespace AppMobileEjemplo
{
	public partial class InicioPage : ContentPage
	{
        //para iniciar la pagina se ocupa enviar el objeto recibido como respuesta del metodo login del servicio
		public InicioPage(Credencial credencial)
		{
			InitializeComponent();
            //agregar un titulo a la pantalla
            Title = "Inicio";

            //agregar un texto personalizado dependiendo del rol que ha iniciado sesion
            lblBienvenida.Text = "Hola " + credencial.Rol + "!";
            //agregar el evento click al boton
            btnCerrarSesion.Clicked += BtnCerrarSesion_Clicked;
		}

        private async void BtnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            //al cerrar sesion entramos a la pagina principal (login)
            await Navigation.PushAsync(new MainPage());
            //eliminar esta pagina para no regresar hasta volver a iniciar sesion
            Navigation.RemovePage(this);
        }
    }
}
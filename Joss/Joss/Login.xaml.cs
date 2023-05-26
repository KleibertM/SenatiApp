using Joss.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Joss
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
           
        }
        private async void btnAcce_Clicked(object sender, EventArgs e)
        {
            string Usuario = usuario.Text;
            string Clave = clave.Text;


            if (Usuario != "admin" || Clave != "1234")
            {

                //await DisplayAlert("Error", "Nombre de usuario o contraseña incorrectos", "OK");

                await DisplayAlert("Error", "Nombre de usuario o contraseña incorrectos", "OK");

            }
            else
            {
                // Navegar a la página de destino si las credenciales son válida

                Navigation.PushAsync(new MainPage());

            }

        }
    }
}
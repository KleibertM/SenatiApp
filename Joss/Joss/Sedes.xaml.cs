using Joss.Data;
using Joss.Model;
using Plugin.ExternalMaps;
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
    public partial class Sedes : ContentPage
    {
        public Sedes()
        {
            InitializeComponent();
            IvClientes.ItemsSource = ClienteServicio.GetClientes();
        }
        private async void IvClientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var cliente = e.SelectedItem as Cliente;
                if (cliente.Nombre != null && cliente.Direccion != null && cliente.CodigoPostal != null)
                {
                    await MapaDireccion(cliente);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error : ", ex.Message, "OK");
            }
        }
        private async Task MapaDireccion(Cliente cli)
        {
            string pais = "BR";
            string CodigoPais = "55";

            if (string.IsNullOrEmpty(cli.Nombre) && string.IsNullOrEmpty(cli.CodigoPostal) 
                && string.IsNullOrEmpty(cli.Direccion) && string.IsNullOrEmpty(cli.Ciudad))
            {
                await DisplayAlert("Datos Invalidos", "Faltan Datos Obligatorios...", "OK");
            }
            else
            {
                try
                {
                    await CrossExternalMaps.Current.NavigateTo("Prueba", cli.Direccion, 
                        cli.Ciudad, cli.Estado, cli.CodigoPostal, pais, CodigoPais);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
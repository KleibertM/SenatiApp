using Joss.Model;
using Plugin.ExternalMaps;
using System;
using System.Threading.Tasks;
using Joss.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Joss
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Alumnos : ContentPage
    {
        public Alumnos()
        {
            InitializeComponent();
            llenarDatos();
        }
        

        private async void btnRegistar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Alumno alum = new Alumno
                {
                    Nom = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Edad = int.Parse(txtEdad.Text),
                    Email = txtEmail.Text,
                    Carrera = txtCarre.SelectedItem as string,
                    Sede = sedePicker.SelectedItem as string,
                };
                await App.SQLiteDB.SaveAlumnoASync(alum);
               
                await DisplayAlert("Registro", "Registro Exitoso", "Ok");
                LimpiarControles();
                llenarDatos();

            }
            else
            {
                await DisplayAlert("Registro", "Error de Registro", "Aceptar");
            }
        }

        public async void llenarDatos()
        {
            var alumnoList = await App.SQLiteDB.GetAlumnosAsync();
            if (alumnoList != null)
            {
                listALumnos.ItemsSource = alumnoList;
            }
        }

        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtNombre.Text)) { respuesta = false; }

            else if (string.IsNullOrEmpty(txtApellido.Text)) { respuesta = false; }

            else if (string.IsNullOrEmpty(txtEdad.Text)) { respuesta = false; }

            else if (string.IsNullOrEmpty(txtEmail.Text)) { respuesta = false; }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtidAlum.Text))
            {
                Alumno alum = new Alumno()
                {
                    IdAlum = Convert.ToInt32(txtidAlum.Text),
                    Nom = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Edad = Convert.ToInt32(txtEdad.Text),
                    Email = txtEmail.Text,
                    Carrera = txtCarre.SelectedItem as string,
                    Sede = sedePicker.SelectedItem as string,
                };
                await App.SQLiteDB.SaveAlumnoASync(alum);
                await DisplayAlert("Registro", "Actualizacion Exitosa", "Ok");
                LimpiarControles();
                txtidAlum.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnRegistar.IsVisible = true;
                llenarDatos();
            }
        }

        private async void listALumnos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Alumno)e.SelectedItem;
            btnRegistar.IsVisible = false;
            txtidAlum.IsVisible = true;
            btnActualizar.IsVisible = true;
            Eliminar.IsVisible = true;

            if (!string.IsNullOrEmpty(obj.IdAlum.ToString()))
            {
                var alum = await App.SQLiteDB.GetAlumnoById(obj.IdAlum);
                if (alum != null)
                {
                    txtidAlum.Text = alum.IdAlum.ToString();
                    txtNombre.Text = alum.Nom;
                    txtApellido.Text = alum.Apellido;
                    txtEdad.Text = alum.Edad.ToString();
                    txtEmail.Text = alum.Email;
                    txtCarre.SelectedItem = alum.Carrera;
                    sedePicker.SelectedItem = alum.Sede;
                }
            }
        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            var alum = await App.SQLiteDB.GetAlumnoById(Convert.ToInt32(txtidAlum.Text));
            if(alum != null)
            {
                await App.SQLiteDB.DeleteAlumnoAsync(alum);
                await DisplayAlert("Registro", "Eliminado Exitoso", "Ok");
                LimpiarControles();
                llenarDatos();

                txtidAlum.IsVisible = false;
                btnRegistar.IsVisible = true;
                btnActualizar.IsVisible = false;
                Eliminar.IsVisible = false;
            }
        }

        public void LimpiarControles()
        {
            txtidAlum.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtEmail.Text = "";
            txtCarre.SelectedItem = "";
            sedePicker.SelectedItem = "";
        }
    }
}
using MedicaAI.Clases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicaAI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void BtnAgregar_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new DatosPage());
        }
    }
}
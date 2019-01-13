using MedicaAI.Clases;
using MedicaAI.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XLabs.Forms.Controls;

namespace MedicaAI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Config : ContentPage
    {
        private DataService dataService;
        List<datos> res;
        string[] estado = {"Estandar(Lbs and Inches)", "Otro(Kgs and Mts)"};

        public Config ()
		{
            this.dataService = new DataService();
            InitializeComponent();
            inicializar();
		}
        
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            res = await this.dataService.GetAllProducts();
            radio.SelectedIndex = -1;
            radio.SelectedIndex = res[0].Estado;
        }
        
        private void inicializar()
        {
            radio.ItemsSource = estado;
            radio.CheckedChanged += radio_CheckedChanged;
        }

        private async void radio_CheckedChanged(object sender, int e)
        {
            var rad = sender as CustomRadioButton;
            if(rad == null || rad.Id == -1)
            {
                return;
            }
            datos a = new datos();
            a.ID = 0;
            a.Estado = rad.Id;
            await this.dataService.DeleteAllProducts();
            await this.dataService.Insert(a);
        }
    }
}
using GalaSoft.MvvmLight.Command;
using MedicaAI.Clases;
using MedicaAI.Services;
using MedicaAI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace MedicaAI.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        private DataService dataService;
        public List<datos> res { get; set; }

        public MainViewModel()
        {
            this.dataService = new DataService();
            LoadMenu();
            save();
        }

        private async Task save()
        {
            datos a = new datos();
            a.ID = 0;
            a.Estado = 0;
            res = await this.dataService.GetAllProducts();
            if (res == null || res.Count == 0)
            {
                this.dataService.Insert(a);
            }

            /*
            res = await this.dataService.GetAllProducts();
            if (res == null || res.Count == 0)
            {
                await App.Current.MainPage.DisplayAlert("Datos", "No Se Encontro Configuracion", "Accept");

            }
            foreach (var i in res)
            {
                await App.Current.MainPage.DisplayAlert("Datos", i.ID + " " + i.Estado, "Accept");
            }
            */
        }

        public DatosViewModel DatosModel
        {
            get;
            set;
        }

        public ICommand BtnAgregar_Command
        {
            get
            {
                return new RelayCommand(GoToDatos);
            }
        }

        private void GoToDatos()
        {
            this.DatosModel = new DatosViewModel();
        }

        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel
            {
                Icon = "about.png",
                PageName = "AboutPage",
                Title = "About",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "Settings.png",
                PageName = "SettingsPage",
                Title = "Settings",
            });
        }
    }
}

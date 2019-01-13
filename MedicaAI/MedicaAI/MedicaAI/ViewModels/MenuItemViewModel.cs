using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;
using MedicaAI.Views;


namespace MedicaAI.ViewModels
{
    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Goto);
            }
        }

        private async void Goto()
        {
            App.Master.IsPresented = false;
            switch (PageName)
            {
                case "AboutPage":
                    await App.Navigator.PushAsync(new About());
                    break;
                case "SettingsPage":
                    await App.Navigator.PushAsync(new Config());
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}

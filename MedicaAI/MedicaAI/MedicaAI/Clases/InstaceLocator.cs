using MedicaAI.ViewModels;

namespace MedicaAI.Clases
{
    public class InstaceLocator
    {
        public MainViewModel Main { get; set; }
        public InstaceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}

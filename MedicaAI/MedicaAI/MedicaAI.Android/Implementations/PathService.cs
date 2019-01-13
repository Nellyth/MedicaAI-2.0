[assembly: Xamarin.Forms.Dependency(typeof(MedicaAI.Droid.Implementations.PathService))]
namespace MedicaAI.Droid.Implementations
{
    using Interfaces;
    using System;
    using System.IO;

    public class PathService : IPathService
    {
        public string GetDatabasePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, "Config.db3");
        }
    }
}
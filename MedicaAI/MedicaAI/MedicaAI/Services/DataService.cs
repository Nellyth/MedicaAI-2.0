namespace MedicaAI.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using MedicaAI.Clases;
    using SQLite;
    using Xamarin.Forms;

    public class DataService
    {
        private SQLiteAsyncConnection connection;

        public DataService()
        {
            this.OpenOrCreateDB();
        }

        private async Task OpenOrCreateDB()
        {
            var databasePath = DependencyService.Get<IPathService>().GetDatabasePath();
            this.connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<datos>().ConfigureAwait(false);
        }

        public async Task Insert<T>(T model)
        {
            await this.connection.InsertAsync(model);
        }

        public async Task Insert<T>(List<T> models)
        {
            await this.connection.InsertAllAsync(models);
        }

        public async Task Update<T>(T model)
        {
            await this.connection.UpdateAsync(model);
        }

        public async Task Update<T>(List<T> models)
        {
            await this.connection.UpdateAllAsync(models);
        }

        public async Task Delete<T>(T model)
        {
            await this.connection.DeleteAsync(model);
        }

        public async Task<List<datos>> GetAllProducts()
        {
            var query = await this.connection.QueryAsync<datos>("select * from [datos]");
            var array = query.ToArray();
            var list = array.Select(p => new datos
            {
                ID = p.ID,
                Estado = p.Estado,
            }).ToList();
            return list;
        }

        public async Task DeleteAllProducts()
        {
            var query = await this.connection.QueryAsync<datos>("delete from [datos]");
        }
    }
}

using Security_Module_Demo.Services.Abstraction;

namespace Security_Module_Demo.Data
{
    public class IdentitySeeder
    {
        private readonly IEnumerable<IDataSedder> _dataSedders;

        public IdentitySeeder(IEnumerable<IDataSedder> dataSedders)
        {
            _dataSedders = dataSedders;
        }

        public async Task SeedAsync()
        {
            foreach (var seeder in _dataSedders)
            {
                await seeder.SeedAsync();
            }
        }
    }
}

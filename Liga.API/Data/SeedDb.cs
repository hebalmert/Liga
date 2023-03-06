using Liga.Shared.Entities;

namespace Liga.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb( DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CheckHerosAsync();
        }

        private async Task CheckHerosAsync()
        {
            if (!_context.Heroes.Any())
            {
                _context.Heroes.Add(new Hero
                {
                    Name = "Batman",
                    Power = "Brilliant tactician and acrobat",
                    Url = "https://pbs.twimg.com/media/FozqyGTWAAAq9XF.jpg"
                });
                _context.Heroes.Add(new Hero
                {
                    Name = "Flash",
                    Power = "Speed like lightning",
                    Url = "https://www.scienceabc.com/wp-content/uploads/2018/02/The-Flash-2014-TV-series.jpg"
                });
                _context.Heroes.Add(new Hero
                {
                    Name = "Superman",
                    Power = "Super powers, fly, speed, vision",
                    Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS4ytQJekUj90AtXdsabGnh7fkxFEyQpb0BInREq5aLWCN4roBwi_r2d8NfL08clEvkewk&usqp=CAU"
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}

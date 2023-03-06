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
                    Url = "https://pbs.twimg.com/media/FozqyGTWAAAq9XF.jpg",
                    Weaknesses = new List<Weakness> 
                    { 
                        new Weakness { Weak = "Whitout Belt"} 
                    }
                });
                _context.Heroes.Add(new Hero
                {
                    Name = "Flash",
                    Power = "Speed like lightning",
                    Url = "https://www.scienceabc.com/wp-content/uploads/2018/02/The-Flash-2014-TV-series.jpg",
                    Weaknesses = new List<Weakness>
                    {
                        new Weakness { Weak = "Born lot energy"}
                    }
                });
                _context.Heroes.Add(new Hero
                {
                    Name = "Superman",
                    Power = "Super powers, fly, speed, vision",
                    Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS4ytQJekUj90AtXdsabGnh7fkxFEyQpb0BInREq5aLWCN4roBwi_r2d8NfL08clEvkewk&usqp=CAU",
                    Weaknesses = new List<Weakness>
                    {
                        new Weakness { Weak = "Red Sun"},
                        new Weakness { Weak = "Kriptonite"},
                        new Weakness { Weak = "Lead Wall"}
                    }
                });
                _context.Heroes.Add(new Hero
                {
                    Name = "Test Hero",
                    Power = "No Power only for test",
                    Url = "https://liquipedia.net/commons/images/thumb/f/f0/Incognito_Logo_V3_Black_Border.png/600px-Incognito_Logo_V3_Black_Border.png"
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}

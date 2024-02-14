using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext _context;
        public PlatformRepository(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePlatform(PlatformModel platform)
        {
            ArgumentNullException.ThrowIfNull(platform);
            _context.Add(platform);
        }

        public IEnumerable<PlatformModel> GetAllPlatforms()
        {
            return [.. _context.Platforms];
        }

        public PlatformModel GetPlatformById(int id)
        {
            var platform = _context.Platforms.FirstOrDefault(p => p.Id == id);
            if (platform != null)
                return platform;
            else
                throw new Exception($"no record found with fiven id {id}");
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
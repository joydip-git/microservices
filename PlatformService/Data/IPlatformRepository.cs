using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepository
    {
        bool SaveChanges();
        IEnumerable<PlatformModel> GetAllPlatforms();
        PlatformModel GetPlatformById(int id);
        void CreatePlatform(PlatformModel platform);
    }
}
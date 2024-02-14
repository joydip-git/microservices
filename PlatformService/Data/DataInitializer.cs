using PlatformService.Models;

namespace PlatformService.Data
{
    public class DataInitializer
    {
        public static void Prepopulate(IApplicationBuilder applicationBuilder)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<AppDbContext>();
            if (context != null)
                SeedData(context);
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("-- seeding data");
                context.Platforms.AddRange(
                    new PlatformModel() { Name = "DotNet", Publisher = "Microsoft", Cost = "Free" },
                    new PlatformModel() { Name = "Sql Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new PlatformModel() { Name = "Kubernetes", Publisher = "CNCF", Cost = "Free" }
                );
                context.SaveChanges();
            }
            else
                Console.WriteLine("-- no data");
        }
    }
}
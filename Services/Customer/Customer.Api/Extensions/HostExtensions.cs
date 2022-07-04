using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Extensions
{
    public static class HostExtensions
    {
        public static void MigrateDatabase<TContext>(this IServiceProvider servicesProvider
            , Action<TContext, IServiceProvider> seeder, int? retry = 0) where TContext : DbContext
        {
            int retryForAvailability = retry.Value;

            using (var scope = servicesProvider.CreateScope())
            {

                var services = scope.ServiceProvider;

                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);

                    if (context.Database.GetPendingMigrations().Count() > 0)
                    {
                        context.Database.Migrate();
                    }

                }
                catch (SqlException ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the databse used on context {DbContextName}", typeof(TContext).Name);

                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase<TContext>(servicesProvider, seeder, retryForAvailability);
                    }
                }
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace tlfame69.DataAccess;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder();

        configurationBuilder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

        var configuration = configurationBuilder.Build();

        DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

        builder.UseSqlServer(configuration.GetConnectionString("Bulky"));

        ApplicationDbContext context = new ApplicationDbContext(builder.Options);

        return context;
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HapChats.Infractucture.DbContexts;

public class ChatDbContextInitializer
{
    private readonly ChatDbContext _context;
    private readonly ILogger _logger;
    public ChatDbContextInitializer(ChatDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsNpgsql())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }
}

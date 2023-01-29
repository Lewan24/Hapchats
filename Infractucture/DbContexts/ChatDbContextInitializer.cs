using Microsoft.EntityFrameworkCore;

namespace HapChats.Infractucture.DbContexts;

public class ChatDbContextInitializer
{
    private readonly ChatDbContext _context;
    public ChatDbContextInitializer(ChatDbContext context)
    {
        _context = context;
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
            throw;
        }
    }
}

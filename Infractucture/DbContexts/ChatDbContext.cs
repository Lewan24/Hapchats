using HapChats.Domain.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HapChats.Infractucture.DbContexts;

public class ChatDbContext : DbContext
{
    private readonly IConfiguration _config;

    public ChatDbContext(DbContextOptions<ChatDbContext> options, IConfiguration config) : base(options)
    {
        _config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var conn = _config.GetConnectionString("DefaultConnection");

        optionsBuilder.UseNpgsql(conn);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UsersProfiles { get; set; }
    public DbSet<UserFriend> UserFriends { get; set; }
    public DbSet<FriendRequest> FriendsRequests { get; set; }
    public DbSet<ChatBox> ChatBoxes { get; set; }
    public DbSet<GroupChatBox> GroupChatBoxes { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}

﻿using HapChats.Domain.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HapChats.Infractucture.DbContexts;

public class ChatDbContext : IdentityDbContext<NewIdentityUser>
{
    public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<NewIdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityUserRole<Guid>> UsersRoles { get; set; }

    public DbSet<UserProfile> UsersProfiles { get; set; }
    public DbSet<UserFriend> UserFriends { get; set; }
    public DbSet<FriendRequest> FriendsRequests { get; set; }
    public DbSet<ChatBox> ChatBoxes { get; set; }
    public DbSet<GroupChatBox> GroupChatBoxes { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<PublicMessages> PublicMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);

        builder.Entity<NewIdentityUser>().ToTable("Users")
            .HasKey(i => i.Id);
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("UsersRoles").HasNoKey();

        builder.Entity<IdentityRole>().HasData(new IdentityRole()
        {
            Id = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            Name = "User",
            NormalizedName = "USER"
        });

        builder.Entity<IdentityRole>().HasData(new IdentityRole()
        {
            Id = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            Name = "Admin",
            NormalizedName = "ADMIN"
        });

        builder.Entity<IdentityRole>().HasData(new IdentityRole()
        {
            Id = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            Name = "Moderator",
            NormalizedName = "MODERATOR"
        });
    }
}

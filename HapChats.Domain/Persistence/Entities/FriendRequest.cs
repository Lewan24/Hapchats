namespace HapChats.Domain.Persistence.Entities;

public record FriendRequest : UserFriend
{
    public bool IsAccepted { get; set; } = false;
}

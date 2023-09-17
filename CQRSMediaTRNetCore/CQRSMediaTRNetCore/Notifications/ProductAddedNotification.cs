using MediatR;

namespace CQRSMediaTRNetCore.Notifications
{
    public record ProductAddedNotification(Product Product) : INotification;
    
}

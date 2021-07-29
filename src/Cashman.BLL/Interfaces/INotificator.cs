using System.Collections.Generic;
using System.Linq;
using Cashman.BLL.Notifications;

namespace Cashman.BLL.Interfaces
{
    public interface INotificator
    {
        public List<Notification> GetNotifications(); 
        public bool HasNotifications(); 
        public void AddNotification(Notification notification); 
    }
}
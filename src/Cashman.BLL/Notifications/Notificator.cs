using System.Collections.Generic;
using System.Linq;
using Cashman.BLL.Interfaces;

namespace Cashman.BLL.Notifications
{
    public class Notificator : INotificator
    {
        public Notificator()
        {
            _notifications = new List<Notification>();
        }
        private List<Notification> _notifications;  
        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification); 
        }

        public List<Notification> GetNotifications()
        {
            return _notifications; 
        }

        public bool HasNotifications()
        {
            return _notifications.Any(); 
        }
    }
}
using Cashman.BLL.Interfaces;
using Cashman.BLL.Notifications;
using FluentValidation.Results;

namespace Cashman.BLL.Services
{
    public abstract class BaseService
    {
        protected INotificator _notificator;

        public BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        public void Notify(ValidationResult results){
            foreach (var failure in results.Errors)
            {
                Notify(failure.ErrorMessage); 
            }
        }

        public void Notify(string message){
            _notificator.AddNotification(new Notification(message)); 
        }

    }
}
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cashman.BLL.Entities;
using Cashman.BLL.Interfaces;
using Cashman.BLL.Validators;

namespace Cashman.BLL.Services
{
    public class MovementService : BaseService, IMovementService
    {
        private IMovementRepository _movementRepository;

        public MovementService(IMovementRepository movementRepository, INotificator notificator) : base(notificator)
        {
            _movementRepository = movementRepository;
        }

        public bool Add(Movement entity)
        {
            if(!Validate(entity)){
                return false; 
            }
            if(!_movementRepository.Add(entity)){
                Notify("There was a problem adding the new movement. "); 
                return false; 
            }
            return true; 
        }

        public IEnumerable<Movement> Get()
        {
            return _movementRepository.Get(); 
        }

        public Movement GetById(int id)
        {
            var movement = _movementRepository.GetById(id); 
            return movement; 
        }
        public bool Update(Movement entity)
        {
            if(_movementRepository.GetById(entity.ID) is null){
                Notify("There is no movement record matching the ID informed in the object. "); 
                return false; 
            }
            if(!Validate(entity)){
                return false; 
            }
            if(!_movementRepository.Update(entity)){
                Notify("A problem ocurred when trying to update the movement record. "); 
                return false; 
            }
            return true; 
        }
        public bool Remove(int id)
        {
            if(_movementRepository.GetById(id) is null){
                Notify("There is no movement record matching the ID informed."); 
                return false; 
            }
            if(!_movementRepository.Remove(id)){
                Notify("A problem ocurred when trying to delete the movement record. "); 
                return false; 
            }
            return true; 
        }

        public bool Validate(Movement entity){
            MovementValidator validator = new MovementValidator();
            var validationResults = validator.Validate(entity);
            if (!validationResults.IsValid)
            {
                Notify(validationResults); 
                return false; 
            }
            return true; 
        }
    }
}
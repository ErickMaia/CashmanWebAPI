using System.Collections.Generic;
using System.Linq;
using Cashman.BLL.Entities;
using Cashman.BLL.Interfaces;
using Cashman.BLL.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Cashman.API.V1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovementController : ControllerBase
    {
        private readonly INotificator _notificator; 
        private readonly IMovementService _movementService; 

        public MovementController(INotificator notificator, IMovementService movementService)
        {
            _notificator = notificator;
            _movementService = movementService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movement>> GetMovements(){
            return Ok(_movementService.Get()); 
        }

        [HttpGet("{id}")]
        public ActionResult<Movement> GetSingleMovement(int id){
            var movement = _movementService.GetById(id); 
            
            if(movement == null){
                return NotFound();
            }else{
                return Ok(movement); 
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]Movement movement){
            if(!_movementService.Add(movement)){
                return ReturnErrors(); 
            }else{
                return CreatedAtAction(nameof(GetSingleMovement), new{movement.ID}, movement); 
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromBody]Movement movement, [FromRoute] int id){
            
            if(movement.ID != id){
                _notificator.AddNotification(new Notification("The ID from the URL and the ID from the movement object informed don't match. ")); 
                return ReturnErrors(); 
            }

            if(!_movementService.Update(movement)){
                return ReturnErrors(); 
            }

            return Ok(movement); 
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            if(!_movementService.Remove(id)){
                return ReturnErrors(); 
            }
            
            return Ok(); 
        }

        public ActionResult ReturnErrors()
        {
            return BadRequest(
                        new
                        {
                            success = false,
                            errors = _notificator.GetNotifications()
                            .Select(notification => notification.Message)
                        }
                    );
        }
    }
}
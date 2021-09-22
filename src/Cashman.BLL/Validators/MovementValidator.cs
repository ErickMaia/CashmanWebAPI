using System.Data;
using Cashman.BLL.Entities;
using Cashman.BLL.Enums;
using FluentValidation;

namespace Cashman.BLL.Validators
{
    public class MovementValidator : AbstractValidator<Movement>
    {
        public MovementValidator()
        {
            RuleFor(x => x.Amount).NotEmpty().WithMessage("The amount must not be empty. "); 
            RuleFor(x => x.Amount).NotNull().WithMessage("The amount must not be null. "); 
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("The amount must be greater than zero. "); 
            
            RuleFor(x => x.Type).NotNull().WithMessage("The movement type must not be null. "); 
            RuleFor(x => x.Type).IsInEnum<Movement, EnumMovementType>().WithMessage("Invalid movement type informed. "); 

        }
    }
}
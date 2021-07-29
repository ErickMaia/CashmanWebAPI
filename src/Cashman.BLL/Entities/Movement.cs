
using System;
using Cashman.BLL.Enums; 

namespace Cashman.BLL.Entities
{
    public class Movement : Entity
    {
        public Movement(EnumMovementType type, string description, string notes, double amount, DateTime dateTime, bool done, int ID) : base(ID)
        {
            Type = type;
            Description = description;
            Notes = notes;
            Amount = amount;
            DateTime = dateTime;
            Done = done;
        }

        public EnumMovementType Type { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public double Amount { get; set; }
        public DateTime DateTime { get; set; }
        public bool Done { get; set; }
    }
}
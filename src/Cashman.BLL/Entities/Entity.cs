using System.ComponentModel.DataAnnotations;

namespace Cashman.BLL.Entities
{
    public abstract class Entity
    {
        [Key]
        public int ID { get; set; }
        
        protected Entity(int id)
        {
            ID = id;
        }
    }   
}
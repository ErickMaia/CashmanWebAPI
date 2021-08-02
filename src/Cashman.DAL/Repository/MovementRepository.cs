using System.Collections.Generic;
using Cashman.BLL.Entities;
using Cashman.BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Dapper; 

namespace Cashman.DAL.Repository
{
    public class MovementRepository : Repository<Movement>, IMovementRepository
    {
        public MovementRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override bool Add(Movement entity)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Movement> Get()
        {
            throw new System.NotImplementedException();
        }

        public override Movement GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public override bool Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public override bool Update(Movement entity)
        {
            throw new System.NotImplementedException();
        }
    }
}